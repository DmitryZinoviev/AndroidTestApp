using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Environment = System.Environment;

namespace ActivityLifecycleDemo
{
    [Activity(Label = "ActivityLifecycleDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity//, View.IOnClickListener
    {
        private TextView _logTextView;

        private int _number;
        private Button _button;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _logTextView = FindViewById<TextView>(Resource.Id.log);

            //if (bundle != null)
            //{
            //    _logTextView.Text = bundle.GetString(TEXT_KEY);
            //    _number = bundle.GetInt(NUMBER_KEY);
            //}

            writeLog("OnCreate");

            _button = FindViewById<Button>(Resource.Id.ButtonShowSecondActivity);
            _button.Click += _button_Click;
        }



        #region Button
        private void _button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));
            StartActivity(intent);
        }

        public void OnClick(View v)
        {
            _button_Click(null, null);
        }



        #endregion

        #region Lifecycle

        private void writeLog(string text)
        {

            _logTextView.Text +=
                String.Format("{3} {0:T}: {1}{2}", DateTime.Now, text, Environment.NewLine, _number++);

        }

        protected override void OnStart()
        {
            base.OnStart();
            writeLog("OnStart");
        }

        protected override void OnResume()
        {
            base.OnResume();
            writeLog("OnResume");

        }

        protected override void OnPause()
        {
            base.OnPause();
            writeLog("OnPause");

        }

        protected override void OnStop()
        {
            base.OnStop();
            writeLog("OnStop");

        }

        protected override void OnRestart()
        {
            base.OnRestart();
            writeLog("OnRestart");

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            writeLog("OnDestroy");
        }



        #endregion

#region Save State

        public const String NUMBER_KEY = "NUMBER_KEY";

        public const String TEXT_KEY = "TEXT_KEY";

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutString(TEXT_KEY, _logTextView.Text);
            outState.PutInt(NUMBER_KEY, _number);
            base.OnSaveInstanceState(outState);
        }

        #endregion


    }
}

