namespace Odontosoft.Frontend.Helpers;

public static class DateHelper
{
    public static int GetAge(DateTime birthDate)
    {
        var today = DateTime.Today;

        var age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}