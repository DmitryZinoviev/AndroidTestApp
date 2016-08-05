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

namespace ServiceTest
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionCameraButton, Intent.ActionScreenOn, Intent.ActionScreenOff })]
    public class MyBroadcastReciever:BroadcastReceiver
    {

        public EventHandler<string> ActionHandler;  
        public override void OnReceive(Context context, Intent intent)
        {
            var handler = ActionHandler;
            if(handler!=null)
                handler.Invoke(this, intent.Action);
        }
    }
}