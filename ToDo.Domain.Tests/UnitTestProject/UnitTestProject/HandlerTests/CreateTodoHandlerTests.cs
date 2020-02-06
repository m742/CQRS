using ClassLibrary.Commands;
using ClassLibrary.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject.Repositories;

namespace UnitTestProject.HandlerTests
{

    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo", "MatheusMunhoz", DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository()); // Criando Repository com Mock, Fake Repository
        private  GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public void Dado_um_Comando_Invalido_deve_interromper_a_execucao()
        {
            var command = new CreateTodoCommand("", "", DateTime.Now);

            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Sucess, false);
        }

        [TestMethod]
        public void Dado_um_Comando_valido_deve_executar()
        {
            var command = new CreateTodoCommand("Titulo da Tarefa", "MatheusMunhoz", DateTime.Now);

            _result = (GenericCommandResult) _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Sucess, true);
       
        }
    }
}
