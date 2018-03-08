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
    class DataAdapter : BaseAdapter<tblToDo>
    {
        private readonly Activity context;

        private readonly List<tblToDo> items;

        public DataAdapter(Activity context, List<tblToDo> items)
        {
            this.context = context;
            if (items.Count != 0)
            {
                this.items = items;
            }
            else
            {


            }


        }


        public override tblToDo this[int position] {
            get { return items[position]; }
        }

        public override int Count {
            get {
                return items.Any() ? items.Count : 0;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

            view.FindViewById<TextView>(Resource.Id.lbltitle).Text = item.Title;
            view.FindViewById<TextView>(Resource.Id.lbldescription).Text = item.Details;
            return view;
        }

    }
}