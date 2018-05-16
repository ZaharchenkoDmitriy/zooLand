using System;
using System.Linq;
using System.Threading;
using ConsoleApplication1.DataBase;
using ConsoleApplication1.server;

namespace ConsoleApplication1
{
    public class TelegramConnector
    {
        private Telegram.Bot.TelegramBotClient botClient;
        private int chatId = -298163036;
        
        public TelegramConnector() {
            // 524727579:AAHZaFNr3S1vUfuPy-wZEIGO3-WxQWodL5s
            botClient = new Telegram.Bot.TelegramBotClient("524727579:AAHZaFNr3S1vUfuPy-wZEIGO3-WxQWodL5s");
            var me = botClient.GetMeAsync();

            Console.WriteLine("Api for bot: " + me.Result.FirstName + " - was connected");            
            Console.WriteLine("Connected to: " + botClient.GetChatAsync(chatId).Result.Title + "chat");

            Thread.Sleep(2000);
        }

        public void sendMessageToUser(User user, string message)
        {
            botClient.SendTextMessageAsync(chatId, message);
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
                            botClient.SendTextMessageAsync(chatId, user.Name + " must to feed the " + animal.Name);
                        }
                    }
                }
                
            }
        }
    }
}