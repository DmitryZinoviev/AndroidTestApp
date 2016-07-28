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

namespace FragmentTest
{
    public class SecondFragment : BaseFragment
    {
        private Button _button;
        private TextView _text;
        public event EventHandler<string> OnTextChange;
        public const string Tag = "SF";



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.SecondFragment, container, false);
            _button = view.FindViewById<Button>(Resource.Id.secondFragmentButton);
            _button.Click += _button_Click2;
            _text = view.FindViewById<TextView>(Resource.Id.secondFragmentText);
            return view;
        }

        private void _button_Click(object sender, EventArgs e)
        {
            var handler = OnTextChange;
            if (handler != null)
            {
                handler(this,_text.Text );
            }
        }

        private void _button_Click2(object sender, EventArgs e)
        {
            var ff = this.FragmentManager.FindFragmentByTag<FirstFragment>(FirstFragment.Tag);
            ff.FirstFragmentText = _text.Text;
        }

        public SecondFragment() : base("SF")
        {
        }
    }
}