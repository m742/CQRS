using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Commands;
using ClassLibrary.Entities;
using ClassLibrary.Handlers;
using ClassLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("v1/All")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create( // converte automaticamente em JSON, por causa do FromBody (ModelBind)
            [FromBody]CreateTodoCommand command,
            [FromServices] TodoHandler handler) // From services vem do startup, ve o que tem dentro do AddTransient e instancia a dependencia
        {
            command.User = "matheusmunhoz";
            return (GenericCommandResult) handler.Handle(command); // retorna se O.K ou não
        }



        [Route("")]
        [HttpPut]
        public GenericCommandResult Update( // converte automaticamente em JSON, por causa do FromBody (ModelBind)
            [FromBody]UpdateTodoCommand command,
            [FromServices] TodoHandler handler) // From services vem do startup, ve o que tem dentro do AddTransient e instancia a dependencia
        {
            command.User = "matheusmunhoz";
            return (GenericCommandResult)handler.Handle(command); // retorna se O.K ou não
        }

        [Route("mask-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone( // converte automaticamente em JSON, por causa do FromBody (ModelBind)
            [FromBody]MarkTodoAsDoneCommand command,
            [FromServices] TodoHandler handler) // From services vem do startup, ve o que tem dentro do AddTransient e instancia a dependencia
        {
            command.User = "matheusmunhoz";
            return (GenericCommandResult)handler.Handle(command); // retorna se O.K ou não
        }

        [Route("mask-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUnDone( // converte automaticamente em JSON, por causa do FromBody (ModelBind)
           [FromBody]MarkTodoAsUndoneCommand command,
           [FromServices] TodoHandler handler) // From services vem do startup, ve o que tem dentro do AddTransient e instancia a dependencia
        {
            command.User = "matheusmunhoz";
            return (GenericCommandResult)handler.Handle(command); // retorna se O.K ou não
        }


        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
            [FromServices] ITodoRepository repository) // só passa pelo Handler quando for fazer command, para
        { // só trazer a informação usar repository
            return repository.GetAll("matheusmunhoz");
            
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
          [FromServices] ITodoRepository repository) // só passa pelo Handler quando for fazer command, para
        { // só trazer a informação usar repository


            return repository.GetAllDone("matheusmunhoz");

        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDone(
         [FromServices] ITodoRepository repository) // só passa pelo Handler quando for fazer command, para
        { // só trazer a informação usar repository


            return repository.GetAllUndone("matheusmunhoz");

        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
         [FromServices] ITodoRepository repository) // só passa pelo Handler quando for fazer command, para
        { // só trazer a informação usar repository

            return repository.GetByPeriod(
                "matheusmunhoz",
                DateTime.Now.Date,
                true);

        }


        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetInactiveForToday(
         [FromServices] ITodoRepository repository) // só passa pelo Handler quando for fazer command, para
        { // só trazer a informação usar repository

            return repository.GetByPeriod(
                "matheusmunhoz",
                DateTime.Now.Date,
                false);

        }


        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
        [FromServices] ITodoRepository repository) // só passa pelo Handler quando for fazer command, para
        { // só trazer a informação usar repository

            return repository.GetByPeriod(
                "matheusmunhoz",
                DateTime.Now.Date.AddDays(1),
                true);

        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForTomorrow(
        [FromServices] ITodoRepository repository) // só passa pelo Handler quando for fazer command, para
        { // só trazer a informação usar repository

            return repository.GetByPeriod(
                "matheusmunhoz",
                DateTime.Now.Date.AddDays(1),
                false);

        }




    }
}