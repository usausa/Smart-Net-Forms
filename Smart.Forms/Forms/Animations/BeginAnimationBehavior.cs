namespace Smart.Forms.Animations;

using Smart.Forms.Interactivity;

using Xamarin.Forms;

[ContentProperty("Animation")]
public sealed class BeginAnimationBehavior : BehaviorBase<VisualElement>
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

    protected override async void OnAttachedTo(VisualElement bindable)
    {
        base.OnAttachedTo(bindable);

        if (Animation is not null)
        {
            Animation.Target ??= AssociatedObject;

            await Animation.Begin();
        }
    }
}
