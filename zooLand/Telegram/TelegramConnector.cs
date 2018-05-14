using System;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using TeleSharp.TL;
using TLSharp.Core;
using TLSharp.Core.Network;

namespace ConsoleApplication1.Telegram
{
    public class TelegramConnector
    {
        public TelegramConnector() {
            FileSessionStore store = new FileSessionStore();
            telegramClient = new TelegramClient(212720, "d1143df7049379369cb0dcd0ad79f779", store);
        }

        private TelegramClient telegramClient;
        
        public async void connect()
        {
            try
            {
               telegramClient.ConnectAsync();
            }
            catch (FloodException floodException)
            {
                Thread.Sleep(floodException.TimeToWait);
            }

            Thread.Sleep(2000);
            
            if (!telegramClient.IsUserAuthorized())
                auth();
            
        }
        public async void auth()
        {

            var hash = telegramClient.SendCodeRequestAsync("380631147813").Result;
            var code = "34618";
            var me = telegramClient.MakeAuthAsync("380631147813", code, hash);
            
            Thread.Sleep(3000);
        }
        
        public async void sendMessage(int userId, string message)
        {
            var result = telegramClient.GetContactsAsync();
            var user = result.Result.Users
                .Where(x => x.GetType() == typeof (TLUser))
                .Cast<TLUser>()
                .FirstOrDefault(x => x.Phone == "80971847169");
                
            telegramClient.SendMessageAsync(new TLInputPeerUser() {UserId = user.Id}, "privet tebe solnce iz moeygo servera, sladkih snov");
        }

        public void sendMessage(string phone, string message)
        {
            var result = telegramClient.GetContactsAsync();
            var user = result.Result.Users
                .Where(x => x.GetType() == typeof (TLUser))
                .Cast<TLUser>()
                .FirstOrDefault(x => x.Phone == phone);
                
            telegramClient.SendMessageAsync(new TLInputPeerUser() {UserId = user.Id}, message); 
        }
    }
}