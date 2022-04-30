namespace Smart.Forms.Validation;

using System.Globalization;
using System.Text.RegularExpressions;

public sealed class RegexValidator<T> : IValidator<T>
{
    private readonly Regex regex;

    public string ErrorMessage { get; set; } = string.Empty;

    public RegexValidator(Regex regex)
    {
        this.regex = regex;
    }

    public bool Validate(T value)
    {
        if (value is null)
        {
            return true;
        }

        var str = Convert.ToString(value, CultureInfo.CurrentCulture);
        var m = regex.Match(str!);

        return m.Success && (m.Index == 0) && (m.Length == str.Length);
    }
}
