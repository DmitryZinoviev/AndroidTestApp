using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FragmentTest
{
    [Activity(Label = "FragmentTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            if (bundle == null)
            {
                var fr = new FirstFragment();
                var tr = FragmentManager.BeginTransaction();
                tr.Add(Resource.Id.myFrameLayout, fr, FirstFragment.Tag);
                //tr.Add(Resource.Id.myFirstFragment, fr, FirstFragment.Tag);
                tr.Commit();


                var secondFragmentConteiner = FindViewById(Resource.Id.mySecondFragment);
                if (secondFragmentConteiner == null)
                {
                    //var ff = FragmentManager.FindFragmentByTag<FirstFragment>(FirstFragment.Tag);
                    fr.OnButtonClick += MainActivity_OnButtonClick;
                    //ff.OnButtonClick += MainActivity_OnButtonClick;
                }
                else
                {
                    FragmentManager.FindFragmentById<SecondFragment>(Resource.Id.mySecondFragment).OnTextChange +=
                        MainActivity_OnTextChange;
                }

            }

        }


        private void MainActivity_OnButtonClick(object sender, EventArgs e)
        {
            var sf = new SecondFragment();
            sf.OnTextChange += MainActivity_OnTextChange;
            var tr = FragmentManager.BeginTransaction();
            var ff = FragmentManager.FindFragmentByTag<FirstFragment>(FirstFragment.Tag);
            //tr.Hide(ff);
            tr.Add(Resource.Id.myFrameLayout, sf, SecondFragment.Tag);
            tr.AddToBackStack(null);
            
            tr.Commit();
        }

        private void MainActivity_OnTextChange(object sender, string e)
        {
            FragmentManager.FindFragmentById<FirstFragment>(Resource.Id.myFirstFragment).FirstFragmentText=e;

        }
    }
}

