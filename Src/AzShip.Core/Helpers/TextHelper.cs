using System;
using System.Collections.Generic;
using System.Text;

namespace AzShip.Core.Helpers
{
    public static class TextHelper
    {
        public static string GenerateRandomString(int length)
        {
            var possibleChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = possibleChars[random.Next(possibleChars.Length)];
            }

            return new String(stringChars);
        }
    }
}
