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
    public class BaseFragment : Fragment
    {
        protected string _logTag;

        protected void write(string text)
        {
            Log.Info(_logTag, "{0} {1} {2}", DateTime.Now, _logTag, text);
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            write("OnCreate");
        }

        public BaseFragment(string logTag)
        {
            _logTag = logTag;
        }

        public override void OnResume()
        {
            base.OnResume();
            write("OnResume");

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            write("OnActivityCreated");

        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            write("OnDestroyView");
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            write("OnViewCreated");

        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            write("OnAttach");

        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            write("OnDestroy");

        }

        public override void OnDetach()
        {
            base.OnDetach();
            write("OnDetach");

        }

        public override void OnPause()
        {
            base.OnPause();
            write("OnPause");

        }

        public override void OnStart()
        {
            base.OnStart();
            write("OnStart");

        }

        public override void OnStop()
        {
            base.OnStop();
            write("OnStop");

        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            write("OnCreateView");

            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}