using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamToDoList2018
{
    [Activity(Label = "ToDo List")]
    public class AddItem : Activity
    {
        Button btnAdd;
        EditText txtItemDescription;
        EditText txtItemTitle;
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddItem);

            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            txtItemTitle = FindViewById<EditText>(Resource.Id.txtItemTitle);
            txtItemDescription = FindViewById<EditText>(Resource.Id.txtItemDescription);
                
                //(EditText)myDoList.Details; //FindViewById<EditText> (Resource.Id.txtItemDescription);

            btnAdd.Click += OnBtnAddClick;
        }

        private void OnBtnAddClick(object sender, EventArgs e)
        {
            if (txtItemTitle.Text != "" && txtItemDescription.Text != "")
            {
                DataManager.AddItem(txtItemTitle.Text, txtItemDescription.Text);
                Toast.MakeText(this, "Note Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
        }
    }
}

