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

namespace ActivityLifecycleDemo
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Second);
            var log = FindViewById<TextView>(Resource.Id.SecondText);
            

            log.Text = Intent.GetStringExtra(MainActivity.TEXT_KEY);
            // Create your application here
            //Android.Util.Log

        }
    }
}
