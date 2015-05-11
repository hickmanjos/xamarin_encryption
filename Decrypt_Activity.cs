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
    [Activity(Label = "Encryption")]
    public class Decryption : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Decryption);

            EditText input = FindViewById<EditText>(Resource.Id.input);
            
        }

    }
}

