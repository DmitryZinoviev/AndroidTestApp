using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ServiceTest
{
    [Service]
    class MyIntentService:IntentService
    {
        public const string Tag = "MyIntentService";

        private void write(int id, string text)
        {
            Log.Info(Tag, "{0} {1}:{2}  {3}", DateTime.Now, Tag, id, text);
        }

        private void write(string text)
        {
            Log.Info(Tag, "{0} {1}    {2}", DateTime.Now, Tag, text);
        }


        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnCreate()
        {
            base.OnCreate();
            write("OnCreate");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            write("OnDestroy");
        }
        protected override void OnHandleIntent(Intent intent)
        {
            write("OnStartCommand");
            Task.Delay(TimeSpan.FromSeconds(5)).GetAwaiter().GetResult();
            
        }
    }
}