namespace Smart.Forms.Animations;

using Smart.Forms.Interactivity;

using Xamarin.Forms;

[ContentProperty("Animation")]
public sealed class BeginAnimationAction : ActionBase<VisualElement>
{
    public static readonly BindableProperty AnimationProperty = BindableProperty.Create(
        nameof(Animation),
        typeof(AnimationBase),
        typeof(BeginAnimationBehavior));

    public AnimationBase? Animation
    {
        get => (AnimationBase)GetValue(AnimationProperty);
        set => SetValue(AnimationProperty, value);
    }

    protected override async void Invoke(VisualElement associatedObject, object? parameter)
    {
        if (Animation is not null)
        {
            Animation.Target ??= associatedObject;

            await Animation.Begin();
        }
    }
}
