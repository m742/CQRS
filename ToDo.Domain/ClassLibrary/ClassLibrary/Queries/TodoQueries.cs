using ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ClassLibrary.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)// todos os ToDo de um usuario
        {
            return x => x.RefUser == user;
        }

        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)// todos os ToDo de um usuario que estiver
        { // finalizado
            return x => x.RefUser == user && x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)// todos os ToDo de um usuario que não estiver
        { // finalizado
            return x => x.RefUser == user && x.Done == false;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        { // retorna todas as tarefas que seja concluidas e a data expecifica
            return x => x.RefUser == user &&
            x.Done == done &&
            x.Date.Date == date.Date;
        }


    }
}
