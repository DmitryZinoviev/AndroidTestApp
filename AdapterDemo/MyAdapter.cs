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

namespace AdapterDemo
{
    class MyAdapter: BaseAdapter<Model>
    {
        private readonly Activity _activity;
        private readonly IList<Model> _list;

        public MyAdapter(Activity activity, IList<Model> list)
        {
            _activity = activity;
            _list = list;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = _activity.LayoutInflater.Inflate(Resource.Layout.Item, null);

            var text1 = view.FindViewById<TextView>(Resource.Id.itemTextView1);
            text1.Text = this[position].Id.ToString();

            var text2 = view.FindViewById<EditText>(Resource.Id.itemEditText1);
            text2.Text = this[position].Time.ToString();

            var text3 = view.FindViewById<TextView>(Resource.Id.itemTextView2);
            text3.Text = this[position].Text;

            return view;
        }

        public override int Count
        {
            get { return _list.Count; } 
        }

        public override Model this[int position]
        {
            get
            {
                return _list[position];
            }
        }
    }
    
}