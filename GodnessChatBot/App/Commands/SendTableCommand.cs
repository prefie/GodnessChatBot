﻿using GodnessChatBot.Domain;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GodnessChatBot.App.Commands
{
    public class SendTableCommand : Command
    {
        protected override string Name => "Получить ссылку на таблицу";
        
        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, Repository.GetSpreadsheetUrl(chatId.ToString()));
        }

        public SendTableCommand(IRepository repository) : base(repository) { }
    }
}