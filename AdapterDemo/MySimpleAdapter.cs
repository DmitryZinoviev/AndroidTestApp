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
    public class MySimpleAdapter:BaseAdapter<Model>
    {
        private readonly IList<Model> _models;
        private readonly Activity _activity;

        public override long GetItemId(int position)
        {
            return position;
        }

        public MySimpleAdapter(IList<Model> models, Activity activity)
        {
            _models = models;
            _activity = activity;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = _activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

            var text1 = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            text1.Text = this[position].Text;

            var text2 = view.FindViewById<TextView>(Android.Resource.Id.Text2);
            text2.Text = this[position].Id.ToString();

            return view;
        }

        public override int Count
        {
            get { return _models.Count; }
        }

        public override Model this[int position]
        {
            get { return _models[position]; }
        }
    }
}