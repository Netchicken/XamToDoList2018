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
    [Activity(Label = "ToDoList", MainLauncher = true)]

    public class MainActivity : Activity
    {
        ListView lstToDoList;
        List<tblToDo> myList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            lstToDoList = FindViewById<ListView>(Resource.Id.listView1);

            //if the DB is not there copy it to the Assets folder place
            //DataManager.CopyTheDB();


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

