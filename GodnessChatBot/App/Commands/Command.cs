﻿using System;
using GodnessChatBot.Domain;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GodnessChatBot.App.Commands
{
    public abstract class Command
    {
        public IRepository repository;
        public Command(IRepository repository)
        {
            this.repository = repository;
        }
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Equals(string command) =>
            string.Equals(command, Name, StringComparison.CurrentCultureIgnoreCase);
    }
}