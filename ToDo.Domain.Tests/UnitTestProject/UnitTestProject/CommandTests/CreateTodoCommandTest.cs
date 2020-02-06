using ClassLibrary.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTestes
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo", "MatheusMunhoz", DateTime.Now);

        public CreateTodoCommandTestes()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }
        
        [TestMethod]
        public void Dado_um_Comando_Invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false); 
        }

        [TestMethod]
        public void Dado_um_Comando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
