﻿using System;
using System.Collections.Generic;
using GodnessChatBot.Domain;
using GodnessChatBot.Domain.Processes;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GodnessChatBot.App.Commands
{
    public class CreateCommand : Command
    {
        public override string Name => "Создать";
        private Dictionary<string, IDialogBranch> dialogs;
        private Func<CreationDialogBranch> createCreationDialogBranch;
        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            dialogs[chatId.ToString()] = createCreationDialogBranch();
            await client.SendTextMessageAsync(chatId, "Выбери название колоды\n\nВАЖНО: для вызова другой команды, заверши эту :)");
        }

        public CreateCommand(Repository repository, Dictionary<string, IDialogBranch> dialogs,
            Func<CreationDialogBranch> createCreationDialogBranch) : base(repository)
        {
            this.dialogs = dialogs;
            this.createCreationDialogBranch = createCreationDialogBranch;
        }
    }
}