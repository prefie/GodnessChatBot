﻿using System.Linq;
using GodnessChatBot.Domain;
using GodnessChatBot.Domain.Processes;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GodnessChatBot.App.Commands
{
    public class AdditionCommand : Command
    {
        public override string Name => "/Добавить карту в колоду";
        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var keyboard = TelegramBot.GetButtons(Repository.GetPacksNames(message.From.Id.ToString()).ToList());
            
            TelegramBot.Teachers[chatId.ToString()] = new Teacher(chatId.ToString(), new AdditionProcess());
            await client.SendTextMessageAsync(chatId, "Выбери колоду, в которые будешь добавлять карты", replyMarkup:keyboard);
        }
    }
}