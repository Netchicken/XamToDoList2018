using SQLite;
using System;
using System.Collections.Generic;
using System.IO;


namespace XamToDoList2018
{
    public static class DataManager
    {
        //YOUR CLASS NAME MUST BE YOUR TABLE NAME

        public static SQLiteConnection db;
        public static string databasePath;
        public static string databaseName;

        static DataManager()
        {
            databaseName = "todolist.sqlite";
            databasePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), databaseName);

            db = new SQLiteConnection(databasePath);
        }

        public static List<tblToDoList> ViewAll()
        {
            try
            {
                return db.Query<tblToDoList>("select * from tblToDoList");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }

        public static void AddItem(string title, string details)
        {
            try
            {
                var AddThis = new tblToDoList() { Title = title, Details = details };
                db.Insert(AddThis);
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error:" + e.Message);
            }
        }

        public static void EditItem(string title, string details, int listid)
        {
            try
            {
                // http://stackoverflow.com/questions/14007891/how-are-sqlite-records-updated 

                var EditThis = new tblToDoList() { Title = title, Details = details, Id = listid };

                db.Update(EditThis);

                //or this

                //   db.Execute("UPDATE tblToDoList Set Title = ?, Details =, WHERE ID = ?", title, details, listid);

            }
            catch (Exception e)
            {
                Console.WriteLine("Update Error:" + e.Message);
            }
        }

        public static void DeleteItem(int listid)
        {
            // https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/ 
            try
            {
                db.Delete<tblToDoList>(listid);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Error:" + ex.Message);
            }
        }
    }








}
