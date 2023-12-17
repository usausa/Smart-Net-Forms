namespace Smart.Forms.Data;

using System.Collections.ObjectModel;
using System.Globalization;

using Xamarin.Forms;

public abstract class MapEntry<T>
{
    public object Key { get; set; } = default!;

    public T Value { get; set; } = default!;
}

public abstract class MapToColorEntry : MapEntry<Color>
{
}

public class MapToObjectConverter<T> : IValueConverter
{
    public Collection<MapEntry<T>> Entries { get; } = new(new List<MapEntry<T>>());

    public T DefaultValue { get; set; } = default!;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not null)
        {
            if (value is IComparable comparable)
            {
                var entry = Entries.FirstOrDefault(x => comparable.CompareTo(x.Key) == 0);
                if (entry is not null)
                {
                    return entry.Value;
                }
            }
            else
            {
                var entry = Entries.FirstOrDefault(x => Equals(value, x.Key));
                if (entry is not null)
                {
                    return entry.Value;
                }
            }
        }

        return DefaultValue;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}

public sealed class MapToColorConverter : MapToObjectConverter<Color>
{
    public MapToColorConverter()
    {
        DefaultValue = Color.Default;
    }
}
