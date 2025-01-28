using System.Globalization;
using System.Text;

namespace AICalculator;

public class Program
{
    private static string _name;
    private static int _num;
    private static DateTime _birthday;

    private static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Console.Title = "Умный ИИ калькулятор";

        _name = GetName();
        _num = GetFavNum();
        _birthday = GetBirthday();

        Console.WriteLine($"Привет, {_name}! Ваше любимое число: {_num}. Ваша дата рождения: {_birthday.ToShortDateString()}.");

        var futureDate = _birthday.AddYears(10);
        Console.WriteLine($"Через 10 лет ваша дата рождения будет условно: {futureDate.ToShortDateString()}.");
    }

    private static int GetFavNum()
    {
        Console.Write("Введите любимое число, от 0 до 9: ");
        var num = Console.ReadLine();
        if (int.TryParse(num, out var number) && number >= 0 && number <= 9)
        {
            return number;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ошибка: введите число от 0 до 9.");
            return GetFavNum();
        }
    }

    private static DateTime GetBirthday()
    {
        Console.Write("Введите вашу дату рождения (в формате ГГГГ-ММ-ДД): ");
        var input = Console.ReadLine();
        if (DateTime.TryParseExact(input, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var birthDate))
        {
            return birthDate;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Ошибка: неверный формат даты. Попробуйте снова.");
            return GetBirthday();
        }
    }

    private static string GetName()
    {
        Console.Write("Введите своё имя: ");
        var name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.Clear();
            Console.WriteLine("Ввод был пустым!");
            return GetName();
        }

        return name;
    }
}
