using System;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ServiceTest
{
    [Activity(Label = "ServiceTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int _count = 1;
        private Timer _timer;
        private TextView _text;
        private MyBroadcastReciever _mybroadcast;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var startButton = FindViewById<Button>(Resource.Id.StartButton);

            startButton.Click += StartButtonOnClick;

            var stopButton = FindViewById<Button>(Resource.Id.StopButton);

            stopButton.Click += StopButtonOnClick;

            _text = FindViewById<TextView>(Resource.Id.Timer);

            _timer = new Timer();
            _timer.Interval = TimeSpan.FromSeconds(1).TotalMilliseconds;
            _timer.AutoReset = true;
            _timer.Elapsed -= _timer_Elapsed;
            _timer.Elapsed += _timer_Elapsed;

            _mybroadcast = new MyBroadcastReciever();
            RegisterReceiver(_mybroadcast, new IntentFilter(Intent.ActionScreenOff));
            RegisterReceiver(_mybroadcast, new IntentFilter(Intent.ActionScreenOn));
            _mybroadcast.ActionHandler+=ActionHandler;

        }

        private void ActionHandler(object sender, string s)
        {
            RunOnUiThread(() =>
            {
                FindViewById<TextView>(Resource.Id.Action).Text += s +System.Environment.NewLine;
            });
        }


        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var t = TimeSpan.FromSeconds(_count++).ToString("c");
                this.RunOnUiThread(() =>
                {
                    _text.Text = t;
                });
            }
            catch (Exception ex)
            {
                
            }

        }

        private void StartButtonOnClick(object sender, EventArgs eventArgs)
        {
            _timer.Start();
            StartService(new Intent(this, typeof(MyService)));
            //StartService(new Intent(this, typeof(MyIntentService)));

        }

        private void StopButtonOnClick(object sender, EventArgs eventArgs)
        {
            _text.Text =Resources.GetString(Resource.String.zero);
            _count = 0;
            _timer.Stop();
            StopService(new Intent(this, typeof(MyService)));
        }



    }
}

