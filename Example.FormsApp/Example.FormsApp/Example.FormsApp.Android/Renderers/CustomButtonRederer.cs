﻿[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.Button), typeof(Example.FormsApp.Droid.Renderers.CustomButtonRederer))]

namespace Example.FormsApp.Droid.Renderers
{
    using Android.Content;
    using Android.Graphics;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class CustomButtonRederer : ButtonRenderer
    {
        public CustomButtonRederer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            var fontFamily = e.NewElement.FontFamily?.ToLower();
            if (fontFamily != null && (fontFamily.EndsWith(".otf") || fontFamily.EndsWith(".ttf")))
            {
                Control.Typeface = Typeface.CreateFromAsset(Context.Assets, e.NewElement.FontFamily);
            }
        }
    }
}
