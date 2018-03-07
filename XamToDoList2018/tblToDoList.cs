using SQLite;
using System;

namespace XamToDoList2018
{
    public class tblToDoList
    {
        [PrimaryKey, AutoIncrement]  //These are attributes that define the property below it
        public int Id { get; set; }

        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }

        public tblToDoList()
        {
        }


    }
}