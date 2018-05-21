﻿using System;
using System.Linq;
using System.Threading;
using ConsoleApplication1.DataBase;
using ConsoleApplication1.server;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace ConsoleApplication1
{
    public class TelegramConnector
    {
        private delegate void messageHandler(object sender, MessageEventArgs args);
        
        private Telegram.Bot.TelegramBotClient botClient;
        private int chatId = -298163036;
        private string token = "524727579:AAHZaFNr3S1vUfuPy-wZEIGO3-WxQWodL5s";
        
        public TelegramConnector() {
            botClient = new Telegram.Bot.TelegramBotClient("524727579:AAHZaFNr3S1vUfuPy-wZEIGO3-WxQWodL5s");
            var me = botClient.GetMeAsync();

            Console.WriteLine("Api for bot: " + me.Result.FirstName + " - was connected");            
            Console.WriteLine("Connected to: " + botClient.GetChatAsync(chatId).Result.Title + "chat");

            botClient.OnMessage += onMessage;
            
            
            botClient.StartReceiving(Array.Empty<UpdateType>());
            Thread.Sleep(2000);
        }

        public void sendMessageToUser(User user, Animal animal)
        {
            botClient.SendTextMessageAsync(
                user.ChatId != 0 ? user.ChatId : chatId,
                user.ChatId == 0 ? user.Name + " must to feed the " + animal.Name : "You must feed the: " + animal.Name); 
        }
        
        public void sendMessagesToStuff()
        {
            foreach (Animal animal in DB.animals)
            {
                if (animal.Hungry || animal.FeedDate == DateFormatter.getCurrentDate())
                {
                    foreach (User user in DB.users)
                    {
                        if (user.isAppointed(animal))
                        {
                            botClient.SendTextMessageAsync(
                                user.ChatId != 0 ? user.ChatId : chatId,
                                user.ChatId == 0 ? user.Name + " must to feed the " + animal.Name : "You must feed the: " + animal.Name);     
                        }
                    }
                }
                
            }
        }

        public void onMessage(object sender, MessageEventArgs args)
        {
            long chatId = args.Message.Chat.Id;
            String text = args.Message.Text;
            
            User user = DB.findUserByChat(chatId);
            if (user != null)
            {
                botClient.SendTextMessageAsync(user.ChatId, user.getAppointedAnimalsMessage());
            }
            else
            {
                if (text.Length > 0)
                {
                    if (text[0] == '/')
                    {
                        text = text.Substring(1, text.Length - 1);
                        user = DB.findUserByName(text);
                        if(user != null)
                            user.ChatId = chatId;
                        botClient.SendTextMessageAsync(chatId,
                            user == null
                                ? "Ask your administrator about adding you to system"
                                : "Thanks, now we know about you, write any message to get your animal that must be feeded");
                    }
                    else
                    {   
                        botClient.SendTextMessageAsync(chatId, "You should add yourself to this bot by command /<name>");
                    }
                }
            }
        }
    }
}