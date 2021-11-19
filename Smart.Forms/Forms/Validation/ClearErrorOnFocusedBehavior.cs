namespace Smart.Forms.Validation;

using Smart.Forms.Interactivity;

using Xamarin.Forms;

public sealed class ClearErrorOnFocusedBehavior : BehaviorBase<Entry>
{
    public static readonly BindableProperty TargetProperty = BindableProperty.Create(
        nameof(Target),
        typeof(IValidationResult),
        typeof(ClearErrorOnFocusedBehavior));

    public IValidationResult? Target
    {
        get => (IValidationResult)GetValue(TargetProperty);
        set => SetValue(TargetProperty, value);
    }

    protected override void OnAttachedTo(Entry bindable)
    {
        base.OnAttachedTo(bindable);

        bindable.Focused += OnFocused;
    }

    protected override void OnDetachingFrom(Entry bindable)
    {
        bindable.Focused -= OnFocused;

        base.OnDetachingFrom(bindable);
    }

    private void OnFocused(object sender, FocusEventArgs e)
    {
        if (e.IsFocused && (Target is not null))
        {
            Target.HasError = false;
        }
    }
}
