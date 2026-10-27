using System.Globalization;

namespace Resume.Application.Extensions;

public static class PersianDateExtensions
{
    private static readonly PersianCalendar Pc = new PersianCalendar();

    /// <summary>
    /// Converts a Gregorian DateTime to Jalali / Shamsi string (yyyy/MM/dd).
    /// </summary>
    public static string ToShamsiDate(this DateTime date)
    {
        try
        {
            return $"{Pc.GetYear(date):0000}/{Pc.GetMonth(date):00}/{Pc.GetDayOfMonth(date):00}";
        }
        catch
        {
            return date.ToString("yyyy/MM/dd");
        }
    }

    /// <summary>
    /// Converts a Shamsi / Jalali date string (e.g. 1403/05/20 or 1403-05-20) to Gregorian DateTime.
    /// </summary>
    public static DateTime? ToGregorianDateTime(this string shamsiDate)
    {
        if (string.IsNullOrWhiteSpace(shamsiDate))
            return null;

        shamsiDate = shamsiDate.Trim()
            .Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4")
            .Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9")
            .Replace("-", "/");

        var parts = shamsiDate.Split('/');
        if (parts.Length == 3 &&
            int.TryParse(parts[0], out int year) &&
            int.TryParse(parts[1], out int month) &&
            int.TryParse(parts[2], out int day))
        {
            try
            {
                if (year > 1200 && year < 1500)
                {
                    return Pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                }
                else
                {
                    return new DateTime(year, month, day);
                }
            }
            catch
            {
                return null;
            }
        }

        if (DateTime.TryParse(shamsiDate, out DateTime dt))
            return dt;

        return null;
    }

    /// <summary>
    /// Normalizes numbers in a date string to English digits.
    /// </summary>
    public static string ToEnglishDigits(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;
        return input
            .Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4")
            .Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
    }
}
