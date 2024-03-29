namespace Smart.Forms.Interactivity;

using Xamarin.Forms;

#pragma warning disable CA1001
public sealed class TimerTrigger : TriggerBase<BindableObject>
{
    public static readonly BindableProperty IntervalProperty = BindableProperty.Create(
        nameof(Interval),
        typeof(TimeSpan),
        typeof(TimerTrigger),
        TimeSpan.FromSeconds(1));

    public static readonly BindableProperty ParameterProperty = BindableProperty.Create(
        nameof(Parameter),
        typeof(object),
        typeof(TimerTrigger));

    public TimeSpan Interval
    {
        get => (TimeSpan)GetValue(IntervalProperty);
        set => SetValue(IntervalProperty, value);
    }

    public object Parameter
    {
        get => GetValue(ParameterProperty);
        set => SetValue(ParameterProperty, value);
    }

    private Timer? timer;

    protected override void OnAttachedTo(BindableObject bindable)
    {
        base.OnAttachedTo(bindable);

        timer = new Timer(Interval, OnTick);
        timer.Start();
    }

    protected override void OnDetachingFrom(BindableObject bindable)
    {
        timer?.Stop();

        base.OnDetachingFrom(bindable);
    }

    private void OnTick()
    {
        InvokeActions(Parameter);
    }
}
#pragma warning restore CA1001
