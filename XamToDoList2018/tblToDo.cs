using SQLite;
using System;
using System.Collections;
using System.Linq;

namespace XamToDoList2018
{
    public class tblToDo
    {
        [PrimaryKey, AutoIncrement]  //These are attributes that define the property below it
        public int Id { get; set; }

        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }

        public tblToDo()
        {
        }

    }
}