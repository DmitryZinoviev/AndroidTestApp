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
    public class MyService:Service
    {
        public const string Tag = "MyService";

        private void write(int id, string text)
        {
            Log.Info(Tag, "{0} {1}:{2}  {3}", DateTime.Now, Tag, id,  text);
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

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            write(startId, "OnStartCommand");
            //Task.Delay(TimeSpan.FromSeconds(5)).GetAwaiter().GetResult();
            Task.Delay(TimeSpan.FromSeconds(5)).ContinueWith(task =>
            {
                write(startId, "stop long running task");
                sendNotification();
                StopSelf(startId);
            });

            return base.OnStartCommand(intent, flags, startId);
        }

        private void sendNotification()
        {
            var notificationManager = (NotificationManager) GetSystemService(NotificationService);
            Notification notification = new Notification.Builder(ApplicationContext).SetContentTitle("MyService")
                .SetContentText("Long task finished")
                .SetSmallIcon(Resource.Drawable.Icon)
                .Build();

            notificationManager.Notify(0, notification);
        }
    }
}