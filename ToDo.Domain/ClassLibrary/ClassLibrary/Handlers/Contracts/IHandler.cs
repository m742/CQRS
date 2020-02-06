using ClassLibrary.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand // exigie
    { // que toda manipulação passe por ICommand

        ICommandResult Handle(T command); // passa um commando
        // e então retorna um ICommandResult

    }
}
