﻿using System.Threading.Tasks;

namespace PackIT.SharedAbstractions.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }
}