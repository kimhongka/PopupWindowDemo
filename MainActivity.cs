using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PopupWindowDemo
{
    [Activity(Label = "PopupWindowDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button popupWindowButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            popupWindowButton = FindViewById<Button>(Resource.Id.PopUpWindow_Button);
            popupWindowButton.Click += OnPopupWinowButtonClicked;
         
        }

        private void OnPopupWinowButtonClicked(object sender, EventArgs e)
        {
            popupWindowButton.Enabled = false;

            LayoutInflater inflater = (LayoutInflater)this.GetSystemService(LayoutInflaterService);
            View popup = inflater.Inflate(Resource.Layout.PopupWindowContent,null);
            PopupWindow window = new PopupWindow(popup, ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            window.ShowAtLocation(popup, GravityFlags.Center, 0, 0);
            window.ShowAsDropDown(popupWindowButton);

            Button closeButton = popup.FindViewById<Button>(Resource.Id.CloseButton);
            closeButton.Click += delegate {
                window.Dismiss();
            };
            popupWindowButton.Enabled = true;
        }
    }
}

