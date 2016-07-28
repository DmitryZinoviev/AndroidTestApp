using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AdapterDemo
{
    public class ModelDialogFragment : DialogFragment
    {
        public EventHandler<Model> OnAddModel;
        private Button _button;
        private EditText _text;

        public const string EventLogTags = "MDF";

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.ModelDialog, container, false);
            _button = view.FindViewById<Button>(Resource.Id.AddDialogButton);
            _button.Click += _button_Click;
            _text = view.FindViewById<EditText>(Resource.Id.dialogTextView);
            return view;
        }

        private void _button_Click(object sender, EventArgs e)
        {
            var handler = OnAddModel;
            if (handler != null)
            {
                handler(this, new Model
                {
                    Id = Guid.NewGuid(),
                    Time = DateTime.Now,
                    Text = _text.Text
                });
            }
            Dismiss();
        }
    }
}