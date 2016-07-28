using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AdapterDemo
{
    [Activity(Label = "AdapterDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ObservableCollection<Model> _list = new ObservableCollection<Model>();
        private EditText _editText;
        private Button _addButton;
        private Button _showButton;
        private ListView _listView;
        private BaseAdapter _adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            _addButton = FindViewById<Button>(Resource.Id.AddButton);

            _editText = FindViewById<EditText>(Resource.Id.EditText);
            _editText.TextChanged += _editText_TextChanged;
            _addButton.Click += AddButtonOnClick;

            _showButton = FindViewById<Button>(Resource.Id.ShowDialogButton);
            _showButton.Click += _showButton_Click;


            _listView = FindViewById<ListView>(Resource.Id.MyListView);
            string[] models = Resources.GetStringArray(Resource.Array.Models);

            //_adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, models);

            //_adapter = new MySimpleAdapter(_list, this);

            _adapter = new MyAdapter(this, _list);

            _list.CollectionChanged += _list_CollectionChanged;
            _listView.Adapter = _adapter;
        }

        private void _list_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _adapter.NotifyDataSetChanged();
        }

        private void _showButton_Click(object sender, EventArgs e)
        {
            var d = new ModelDialogFragment();
            d.OnAddModel+=OnAddModel;
            
            d.Show(FragmentManager, d.Tag);
            
        }

        private void OnAddModel(object sender, Model model)
        {
            _list.Add(model);
        }

        private void _editText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            _addButton.Enabled = !string.IsNullOrEmpty(_editText.Text);
        }

        private void AddButtonOnClick(object sender, EventArgs eventArgs)
        {
            _list.Add(new Model
            {
                Id = Guid.NewGuid(),
                Text = _editText.Text,
                Time = DateTime.Now
            });
        }
    }
}

