using ClassLibrary.Entities;
using ClassLibrary.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject.QueriesTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa1", "UsuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa1", "UsuarioB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa1", "UsuarioC", DateTime.Now));
            _items.Add(new TodoItem("Tarefa1", "UsuarioD", DateTime.Now));
            _items.Add(new TodoItem("Tarefa1", "UsuarioA", DateTime.Now));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_matheusmunhoz()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("UsuarioA"));
            Assert.AreEqual(2, result.Count());
        }
       
    }
}
