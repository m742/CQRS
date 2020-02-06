using ClassLibrary.Entities;
using ClassLibrary.Queries;
using ClassLibrary.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _context.Todos.AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _context.Todos.AsNoTracking()
                 .Where(TodoQueries.GetAllDone(user))
                 .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _context.Todos.AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string user)
        {

           return  _context.Todos.Where(x => x.Id == id 
                    && x.RefUser == user)
                .FirstOrDefault();
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Todos.AsNoTracking().
                Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);
        }

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges(); // Cria 2 versões em memoria, uma antiga e outra nova
        }
    }
}
