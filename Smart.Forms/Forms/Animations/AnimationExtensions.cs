namespace Smart.Forms.Animations
{
    using System;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    public static class AnimationExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Ignore")]
        public static async Task<bool> Animate(this VisualElement visualElement, AnimationBase animation)
        {
            try
            {
                animation.Target = visualElement;

                await animation.Begin();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Task<bool> ColorTo(this VisualElement self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
        {
            Color Transform(double x) => Color.FromRgba(
                fromColor.R + (x * (toColor.R - fromColor.R)),
                fromColor.G + (x * (toColor.G - fromColor.G)),
                fromColor.B + (x * (toColor.B - fromColor.B)),
                fromColor.A + (x * (toColor.A - fromColor.A)));
            return ColorAnimation(self, "ColorTo", Transform, callback, length, easing);
        }

        private static Task<bool> ColorAnimation(VisualElement element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
        {
            var tcs = new TaskCompletionSource<bool>();
            element.Animate(name, transform, callback, 16, length, easing ?? Easing.Linear, (_, c) => tcs.SetResult(c));
            return tcs.Task;
        }
    }
}
