using System;

namespace SifreUret
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Üretilecek şifrenin uzunluğunu giriniz: ");
            int length = int.Parse(Console.ReadLine());
            
            Console.Write("Özel karakter olsun mu (e/h)?: ");
            bool isSpecialChars = Console.ReadLine() == "e";

            Console.Write("Büyük/küçük harf olsun mu (e/h)?: ");
            bool isCaseSensitive = Console.ReadLine() == "e";

            Console.Write($"\n\nÜretilen şifre: {PasswordGenerator.GeneratePassword(length, isSpecialChars, isCaseSensitive)}\n");

            Console.Read();

        }
    }
}
