using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Nfc;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FragmentTest
{
    [Register("fragmenttest.FirstFragment")]
    public class FirstFragment : BaseFragment
    {
        private Button _button;
        private TextView _text;
        private string _firstFragmentText = String.Empty;
        public event EventHandler OnButtonClick;
        public const string Tag = "FF";

        public string FirstFragmentText
        {
            get { return _firstFragmentText; }
            set { _text.Text = _firstFragmentText = value; }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            // Use this to return your custom view for this Fragment
            //var view = inflater.Inflate(Resource.Layout.FirstFragment, container, false);
            var view = inflater.Inflate(Resource.Layout.FirstFragment, container, false);
            _button = view.FindViewById<Button>(Resource.Id.firstFragmentButton);
            _button.Click += _button_Click;
            _text = view.FindViewById<TextView>(Resource.Id.firstFragmentText);
            _text.Text = _firstFragmentText;
            return view;
        }

        private void _button_Click(object sender, EventArgs e)
        {
            var handler = OnButtonClick;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public FirstFragment() : base(Tag)
        {
        }
    }
}