using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Animation;
using Android.Views.Animations;

namespace Encryption
{
    [Activity(Label = "Encryption", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int seconds = 0;
        CountDownTimer timer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            EditText input = FindViewById<EditText>(Resource.Id.input);
            
        }

    }
}

