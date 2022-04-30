namespace Smart.Forms.Interactivity;

using System.Reflection;

using Smart.Forms.Messaging;

using Xamarin.Forms;

public sealed class ResolveMethodAction : ActionBase<BindableObject, ResultEventArgs>
{
    public static readonly BindableProperty TargetObjectProperty = BindableProperty.Create(
        nameof(TargetObject),
        typeof(object),
        typeof(ResolveMethodAction));

    public static readonly BindableProperty MethodNameProperty = BindableProperty.Create(
        nameof(MethodName),
        typeof(string),
        typeof(ResolveMethodAction),
        string.Empty);

    public object? TargetObject
    {
        get => GetValue(TargetObjectProperty);
        set => SetValue(TargetObjectProperty, value);
    }

    public string MethodName
    {
        get => (string)GetValue(MethodNameProperty);
        set => SetValue(MethodNameProperty, value);
    }

    private MethodInfo? cachedMethod;

    protected override void Invoke(BindableObject associatedObject, ResultEventArgs parameter)
    {
        var target = TargetObject ?? associatedObject;
        var methodName = MethodName;
        if (String.IsNullOrEmpty(methodName))
        {
            return;
        }

        if ((cachedMethod is null) ||
            (cachedMethod.DeclaringType != target.GetType() ||
             (cachedMethod.Name != methodName)))
        {
            cachedMethod = target.GetType().GetRuntimeMethods().FirstOrDefault(m =>
                m.Name == methodName &&
                (m.GetParameters().Length == 0));
            if (cachedMethod is null)
            {
                return;
            }
        }

        parameter.Result = cachedMethod.Invoke(target, null);
    }
}
