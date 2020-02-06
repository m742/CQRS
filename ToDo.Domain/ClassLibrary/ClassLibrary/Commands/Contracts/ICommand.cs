using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;

namespace ClassLibrary.Commands.Contracts
{
    public interface ICommand : IValidatable
    {
        //IValidatable já puxa um validate,nesse caso
        // aqui ele busca por herança multipla


    }
}
