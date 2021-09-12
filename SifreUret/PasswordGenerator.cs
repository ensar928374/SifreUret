using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SifreUret
{
    internal class PasswordGenerator
    {
        private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string digits = "0123456789";
        private const string specChar = "!#$%&*+-/;<=?@_|~.";

        private static string[] Shuffle(string[] wordArray)
        {
            Random random = new Random();
            for (int i = wordArray.Length - 1; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                string temp = wordArray[i];
                wordArray[i] = wordArray[swapIndex];
                wordArray[swapIndex] = temp;
            }
            return wordArray;
        }

        public static string GeneratePassword(int length, bool isSpecialCharacter = true, bool isCaseSensitive = true)
        {
            if (length < 8) length = 8;

            ArrayList passwordArray = new ArrayList();

            int numberOfCharacters = (int)Math.Round(length * (isSpecialCharacter ? 0.5 : 0.7));
            int numberOfDigits = (int)Math.Round(length * 0.3);
            int numberOfSpecialCharters = (int)Math.Round(length * 0.2);

            for (int j = 0; j < numberOfCharacters; j++)
            {
                string randomLetter = letters.ToCharArray()[new Random().Next(0, letters.Length - 1)].ToString();
                passwordArray.Add(isCaseSensitive ? (new Random().Next() % 2 == 0 ? randomLetter.ToLower() : randomLetter.ToUpper()) : randomLetter);

            }
            for (var k = 0; k < numberOfDigits; k++)
            {
                passwordArray.Add(digits.ToCharArray()[new Random().Next(0, digits.Length - 1)].ToString());
            }

            if (isSpecialCharacter)
            {
                for (int z = 0; z < numberOfSpecialCharters; z++)
                {
                    passwordArray.Add(specChar.ToCharArray()[new Random().Next(0, specChar.Length - 1)].ToString());
                }
            }


            return string.Join("", Shuffle((string[])passwordArray.ToArray(typeof(string))));
        }
    }
}
