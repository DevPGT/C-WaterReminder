using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace WaterPGBot
{
    // 713149816
    class Listener
    {
       static ITelegramBotClient botClient = new TelegramBotClient("1048456622:AAG2j2o0aNjv_YRykcePDqq1knVMr-xFh7g");
       static void Main(string[] args)
        {
            var me = botClient.GetMeAsync().Result;
            StartRemind();
            Console.WriteLine(
              $"Entrando em contato com os satelites [ {me.Id} ] Identificado bot: {me.FirstName}."
            );
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static int _DELAY = ((1000) * 60) * 20;
        static int _TESTDELAY = 5000;

        static string[] Messages =
            {
                "Hora de tomar água !",
                "Bora beber agua colega !",
                "Ta com sede ?",
                "Hmm, receio que esteja passando da hora de tomar água !",
                "Sua lingua ta seca cara, toma agua vai",
                "H2OOOOOOOOOH",
                "Lets Drink Water!",
                "Hey, A . G . U . A AAAAAA",
                "Levanta a porra da bunda e vai beber agua filha da puta :)",
                "Se você não se hidratar vai morrer !",
                "Aproveita que tem agua por perto, da uma bebida!!",
                "70% do nosso corpo é agua, e 70% da particula de àgua é vacuo, então, fodasse tudo toma agua logo ou vacuo não sei",
                "UARER JA TOMOU ?"
            };

        static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"[{e.Message.Chat.Id} - {e.Message.Chat.FirstName}] : {e.Message.Text}.");
            }
        }
        public static string getMessage()
        {
            Random number = new Random();
            return Messages[number.Next(0, Messages.Length)];
        }

        public static async void StartRemind()
        {
            await botClient.SendTextMessageAsync(
                chatId: 713149816,
                text: getMessage() + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second
            );
            Thread.Sleep( _DELAY );
            StartRemind();
        }
    }
}
