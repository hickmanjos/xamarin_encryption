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
    [Activity(Label = "Encryption", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        string tag = "ENCRYPTION";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Random r = new Random();
            int key = r.Next(10000, 99999);

            EditText input = FindViewById<EditText>(Resource.Id.input);
            EditText key_view = FindViewById<EditText>(Resource.Id.key);
            EditText encrypted = FindViewById<EditText>(Resource.Id.encrypted_text);
            Button key_btn = FindViewById<Button>(Resource.Id.key_btn);
            Button encrypt_btn = FindViewById<Button>(Resource.Id.encrypt_btn);
            Button flip = FindViewById<Button>(Resource.Id.decrypt_switch);

            key_view.Text = key.ToString();

            flip.Click += (sender, e) =>
            {
                StartActivity(typeof(Decryption));
            };


            key_btn.Click += (sender, e) =>
            {
                key = r.Next(10000, 99999);
                key_view.Text = key.ToString();
            };

            encrypt_btn.Click += (sender, e) =>
            {
                Log.Info(tag, "clicked encrypt");
                encrypted.Text = encrypt(key_view.Text, input.Text);

                //encrypted.Text = test(input.Text);
                //encrypted.Text = test2(key_view.Text);
            };
            
        }

        public string encrypt(string key, string input)
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
            int new_alpha_num = root_num - shift;

            if(new_alpha_num < 0)
            {
                new_alpha_num = 26 + new_alpha_num;
            }
            return alpha[new_alpha_num];
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~TEST FUNCTION BELOW~~~~~~~~~~~~~~~~~~~~~~

        public string test(string input)
        {
            char[] plain_text = input.ToUpper().ToCharArray();
            char[] alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] cipher_text = new char[plain_text.Length];

            for (int i = 0; i < plain_text.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (plain_text[i] == alpha[j])
                    {
                        cipher_text[i] = alpha[j + 1];
                        break;
                    }
                }
            }

            string cipher = new string(cipher_text);
            return cipher;
        }

        public string test2(string input)
        {
            char[] plain_text = input.ToCharArray();
            char[] cipher_text = new char[plain_text.Length];

            for (int i = 0; i < plain_text.Length; i++)
            {
                cipher_text[i] = plain_text[i];
            }

            string cipher = new string(cipher_text);
            return cipher;
        }

    }
}

