using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Entities
{
    public class TodoItem : Entities
    {
        public TodoItem()
        {

        }

        public TodoItem(string title, string user, DateTime date)
        {
            Title = title;
            Done = false;
            Date = date;
            RefUser = user;
        }
        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string RefUser { get; private set; }

        public void MarkAsDone()
        {
            Done = true;
        }

        public void MarkAsUnDone()
        {
            Done = false;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }


    }
}
