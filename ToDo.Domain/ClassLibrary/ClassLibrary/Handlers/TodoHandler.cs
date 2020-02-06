using ClassLibrary.Commands;
using ClassLibrary.Commands.Contracts;
using ClassLibrary.Entities;
using ClassLibrary.Handlers.Contracts;
using ClassLibrary.Repositories;
using Flunt.Notifications;

namespace ClassLibrary.Handlers
{
    public class TodoHandler : 
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
        
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }


        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Aplicar o Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, 
                 "Ops, parece que sua tarefa " +
                    "esta errada",
                    command.Notifications);

            // Criar um todo

            var todo = new TodoItem(command.Title, command.User, command.Date);

            // Salvar um todo no banco
            _repository.Create(todo);

            // Notificar o usuário

            return new GenericCommandResult(true, "Tarefa Sala", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Aplicar o Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                 "Ops, parece que sua tarefa " +
                    "esta errada",
                    command.Notifications);

            // Recupera o TodoItem (Rehidratação) a partir do repository

            var todo = _repository.GetById(command.Id, command.User);

            //Atualizar o Titulo
            todo.UpdateTitle(command.Title);

            //Confirmar Atualização
            _repository.Update(todo);

            // Notificar o usuário

            return new GenericCommandResult(true, "Tarefa Sala", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                 "Ops, parece que sua tarefa " +
                    "esta errada",
                    command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUnDone();
         

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa Sala", todo);

        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                 "Ops, parece que sua tarefa " +
                    "esta errada",
                    command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _repository.Update(todo);


            return new GenericCommandResult(true, "Tarefa Sala", todo);

        }
    }
}
