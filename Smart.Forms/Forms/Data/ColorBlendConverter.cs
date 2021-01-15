namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public sealed class ColorBlendConverter : IValueConverter
    {
        private double raito;

        public Color BlendColor { get; set; }

        public double Raito
        {
            get => raito;
            set
            {
                if ((value < 0d) || (value > 1d))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                raito = value;
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Color))
            {
                return null;
            }

            var color = (Color)value;
            var r = Math.Min((byte)Math.Round(color.R + ((BlendColor.R - color.R) * raito)), (byte)255);
            var g = Math.Min((byte)Math.Round(color.G + ((BlendColor.G - color.G) * raito)), (byte)255);
            var b = Math.Min((byte)Math.Round(color.B + ((BlendColor.B - color.B) * raito)), (byte)255);
            return new Color(r, g, b);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
