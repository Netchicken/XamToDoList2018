using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace XamToDoList2018
{
    [Activity(Label = "XamToDoList2018", MainLauncher = true)]

    public class MainActivity : Activity
    {
        ListView lstToDoList;
        List<tblToDo> myList;

        //  string dbName = "ToDoList.sqlite";
        //  String dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            lstToDoList = FindViewById<ListView>(Resource.Id.listView1);
            CopyTheDB();


            myList = DataManager.ViewAll();
            lstToDoList.Adapter = new DataAdapter(this, myList);
            lstToDoList.ItemClick += OnLstToDoListClick;
        }

        //Adds Add to the Menu in the top right of your screen.
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Add");
            return base.OnPrepareOptionsMenu(menu);
        }

        private void CopyTheDB()
        {
            // Check if your DB has already been extracted. If the file does not exist move it. 
            //WARNING!!!!!!!!!!! If your DB changes from the first time you install it, ie: you change the tables, and you get errors then comment out the if wrapper so that it is FORCED TO UPDATE. Otherwise you spend hours staring at code that should run OK but the db, that you can’t see inside of on your phone, is diffferent from the db you are coding to.   
            if (!File.Exists(DataManager.databasePath))
            {
                using (BinaryReader br = new BinaryReader(Assets.Open(DataManager.databaseName)))
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(DataManager.databasePath, FileMode.Create)))
                {
                    byte[] buffer = new byte[2048];
                    int len = 0;
                    while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bw.Write(buffer, 0, len);
                    }
                }
            }
        }
        } //this is just to save space should inflate out when run.

        void OnLstToDoListClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var ToDoItem = myList[e.Position];

            var edititem = new Intent(this, typeof(EditItem));
            edititem.PutExtra("Title", ToDoItem.Title);
            edititem.PutExtra("Details", ToDoItem.Details);
            edititem.PutExtra("ListID", ToDoItem.Id);

            StartActivity(edititem);
        }

        //When you choose Add from the Menu run the Add Activity. Good to know to add more options
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var itemTitle = item.TitleFormatted.ToString();

            switch (itemTitle)
            {
                case "Add":
                    StartActivity(typeof(AddItem));
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
        //Basically reload stuff when the app resumes operation after being pauused
        protected override void OnResume()
        {
            base.OnResume();
            myList = DataManager.ViewAll();
            lstToDoList.Adapter = new DataAdapter(this, myList);
        }
    }

}

