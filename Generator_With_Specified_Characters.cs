using System;
using System.Text;

class Generator_With_Specified_Characters
{
    const string Digits = "0123456789";
    const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    const string Symbols = " ~`@#$%^&*()_+-=[]{};'\\:\"|,./<>?";

    [Flags]
    public enum PasswordChars //enum - перечисление
    {
        Digits = 0b0001,
        Alphabet = 0b0010,
        Symbols = 0b0100
    }

    static void Main(string[] args)
    {
        Console.Write("Вероятность взлома (P): ");
        double P = Convert.ToDouble(Console.ReadLine());

        Console.Write("Cкорость взлома (V): ");
        int V = Convert.ToInt32(Console.ReadLine());

        Console.Write("Время действия пароля (T): ");
        int T = Convert.ToInt32(Console.ReadLine());

        Console.Write("Число парольных символов (А): ");
        double A = Convert.ToDouble(Console.ReadLine());

        double S = V * T * 60 * 24 * 12 / P; // расчет S

        Console.WriteLine("Число возможных паролей S: {0}", Math.Round(S, 2));
        double lenghtA = 1;
        int L = 0;

        //Пока длина А меньше числа возможных паролей формировать L
        while (lenghtA < S)
        {
            L++;
            lenghtA = lenghtA * A;
        }
        Console.WriteLine("Длина пароля составила: {0}", L);

        Console.OutputEncoding = Encoding.UTF8;
        int passwordLength = L;
        Console.WriteLine("Из чего будет состоять пароль: ");
        Console.WriteLine("1.Цифр");
        Console.WriteLine("2.Букв");
        Console.WriteLine("3.Цифр и букв");
        Console.WriteLine("4.Спец. символов");
        Console.WriteLine("5.Цифр и спец. символов");
        Console.WriteLine("6.Букв и спец. символов");
        Console.WriteLine("7.Букв, цифр и спец. символов");
        Console.Write("Какой из наборов хотите использовать: ");
        int charSet = int.Parse(Console.ReadLine());
        Console.WriteLine("Ваш пароль: {0}", GeneratePassword((PasswordChars)charSet, passwordLength));
        Console.ReadLine();
    }

    private static string GeneratePassword(PasswordChars passwordChars, int length)
    {
        var random = new Random();
        var resultPassword = new StringBuilder(length);
        var passwordCharSet = string.Empty;
        if (passwordChars.HasFlag(PasswordChars.Alphabet))
        {
            passwordCharSet += Alphabet + Alphabet.ToUpper();
        }
        if (passwordChars.HasFlag(PasswordChars.Digits))
        {
            passwordCharSet += Digits;
        }
        if (passwordChars.HasFlag(PasswordChars.Symbols))
        {
            passwordCharSet += Symbols;
        }
        for (var i = 0; i < length; i++)
        {
            resultPassword.Append(passwordCharSet[random.Next(0, passwordCharSet.Length)]);
        }
        return resultPassword.ToString();
    }
}



