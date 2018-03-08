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
    [Activity(Label = "EditItem")]
    public class EditItem : Activity
    {
        int ListId;
        string Title;
        string Details;

        TextView txtTitle;
        TextView txtDetails;
        Button btnEdit;
        Button btnDelete;
        //  DatabaseManager objDb;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EditItem);

            txtTitle = FindViewById<TextView>(Resource.Id.txtEditTitle);
            txtDetails = FindViewById<TextView>(Resource.Id.txtEditDescription);

            btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);

            btnEdit.Click += OnBtnEditClick;
            btnDelete.Click += OnBtnDeleteClick;

            ListId = Intent.GetIntExtra("ListID", 0); //0 is default
            Details = Intent.GetStringExtra("Details");
            Title = Intent.GetStringExtra("Title");

            txtTitle.Text = Title;
            txtDetails.Text = Details;

            //  objDb = new DatabaseManager();
        }

        public void OnBtnEditClick(object sender, EventArgs e)
        {
            try
            {
                DataManager.EditItem(txtTitle.Text, txtDetails.Text, ListId);
                Toast.MakeText(this, "Note Edited", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred:" + ex.Message);
            }
        }

        public void OnBtnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                DataManager.DeleteItem(ListId);
                Toast.MakeText(this, "Note Deleted", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred:" + ex.Message);
            }
        }
    }
}

