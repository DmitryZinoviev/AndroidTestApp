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
    public class Fragment1 : Fragment
    {
        public const string TextKey = "TextKey";

        public static Fragment1 CreateInstance(string text)
        {
            Fragment1 fragment1 = new Fragment1();
            Bundle args = new Bundle();
            args.PutString(TextKey, text);
            fragment1.Arguments = args;
            return fragment1;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string text = Arguments.GetString(TextKey);
        }
    }
}