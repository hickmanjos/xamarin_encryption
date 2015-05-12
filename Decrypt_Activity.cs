using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Animation;
using Android.Views.Animations;
using Android.Util;

namespace Encryption
{
    [Activity(Label = "Decryption")]
    public class Decryption : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            string tag = "DECRYPTION";
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Decryption);

            EditText input = FindViewById<EditText>(Resource.Id.input);
            EditText key_view = FindViewById<EditText>(Resource.Id.key);
            EditText decrypted = FindViewById<EditText>(Resource.Id.decrypted_text);
            Button decrypt_btn = FindViewById<Button>(Resource.Id.decrypt_btn);
            Button flip = FindViewById<Button>(Resource.Id.encrypt_switch);

            flip.Click += (sender, e) =>
            {
                StartActivity(typeof(MainActivity));
            };

            decrypt_btn.Click += (sender, e) =>
            {
                Log.Info(tag, "clicked decrypt");
                decrypted.Text = decrypt(key_view.Text, input.Text);

            };
            
        }

        public string decrypt(string key, string input)
        {
            char[] alpha = {'A', 'B' , 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
            char[] plain_text = input.ToUpper().ToCharArray();
            char[] shift = key.ToCharArray();
            char[] cipher_text = new char[plain_text.Length];
            int shift_count = 0;

            for (int i = 0; i < plain_text.Length; i++)
            {
                for(int j = 0; j < alpha.Length; j++)
                {
                    if(plain_text[i] == alpha[j])
                    {
                        if(shift_count == shift.Length) { shift_count = 0; }

                        cipher_text[i] = letter_shift(alpha, Convert.ToInt32(shift[shift_count].ToString()), j);
                        shift_count++;

                        break;
                    }
                }
            }
            string cipher = new string(cipher_text);
            return cipher;
        }

        public char letter_shift(char[] alpha, int shift, int root_num)
        {
            int new_alpha_num = root_num + shift;

            if(new_alpha_num > 26)
            {
                new_alpha_num = new_alpha_num - 26;
            }
            return alpha[new_alpha_num];
        }

    }
}

