using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DbScript.DataGeneration
{
    internal class RandomDataGeneration
    {
        // Instantiate random number generator
        public static Random random = new Random();

        // Generate Random Number in Min to Max Range
        // Returns a random number between the min and the max range
        public int RandomNumberWithinMinToMaxRange(int min, int max)
        {
            int finalNumber = random.Next(min, max);
            return finalNumber;
        }

        // Generate a random integer that is less than the specified maximum value
        // Returns a non-negative integer with max value as the argument provided by the user
        public int RandomNumberInRange(int range)
        {
            int finalNumber = random.Next(range);
            return finalNumber;

        }

        // Generate random digits with any specified length

        /* public string RandomDigits(int length)
         {
             //var random = new Random();
             string finalstring = string.Empty;
             for (int i = 0; i < length; i++)
                 finalstring = String.Concat(finalstring, random.Next(10).ToString());
             //Console.WriteLine(finalstring);
             return finalstring;
         }*/

        // Generate random digits with any specified length
        public static long RandomDigits(int length)
        {
            string finalstring = string.Empty;
            for (int i = 0; i < length; i++)
                finalstring = String.Concat(finalstring, random.Next(1,10).ToString());
            long finalValue = Convert.ToInt64(finalstring);
            return finalValue;
        }

        // Generate Random Floating Point Number Between 0 and 1
        // Returns a random float value between 0 and 1
        public static double RandomFloatingNumber(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("Length must be greater than or equal to 1", nameof(length));
            }

            Random random = new Random();
            double minValue = Math.Pow(10, length - 1);
            double maxValue = Math.Pow(10, length);

            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        // Generate Random Floating Point Number Without a Range
        public double RandomFloatingNumberWithoutRange()
        {
            double range = (double)float.MaxValue - (double)float.MinValue;
            return range;
        }

        // Generate Random Floating Point Number Within a Specific Range

        // The precision of double is 15 decimal digits
        public double RandomdoubleWithinSpecifiedRange(double min, double max)
        {
            double range = max - min;
            double sample = random.NextDouble();
            double scaled = (sample * range) + min;
            float finalNumber = (float)scaled;
            return finalNumber;
        }
        // The precision of float is only six or seven decimal digits
        public float RandomFloatWithinSpecifiedRange(float min, float max)
        {
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }

        // Generates a random string with a given size
        public string RandomString(int size, bool lowerCase)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase

            // char is a single Unicode character
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26

            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public static string RandomAlphabates(int size, String caseType) { 
        // String of alphabets  
        String lowerCharacters = "abcdefghijklmnopqrstuvwxyz";
        String upperCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
       // String bothCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            // Initializing the empty string 
            String randomValue = "";

            for (int i = 0; i<size; i++) 
        { 
  
            // Selecting a index randomly 
            int index = random.Next(26);

                // Appending the character at the  
                // index to the random string. 
                if (caseType.ToUpper().Trim() == "LOWERCASE")
                {
                    randomValue = randomValue + lowerCharacters[index];
                }
                else if (caseType.ToUpper().Trim() == "UPPERCASE")
                {
                    randomValue = randomValue + upperCharacters[index];
                }
                /*else if (caseType.ToUpper().Trim() == "BOTHCASE")
                {
                    randomValue = randomValue + bothCharacters[index];
                }*/
            }
            return randomValue;

        }


        // Generates a random alphanumeric string with a given size
        public static string RandomAlphanumericString(int size, String caseType)
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var lowerCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";
            var upperCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var Charsize = new char[size];

          for (int i = 0; i< Charsize.Length; i++) {
                if (caseType.ToUpper().Trim() == "LOWERCASEALPHANUMERIC")
                {
                    Charsize[i] = lowerCharacters[random.Next(lowerCharacters.Length)];
                }
                else if (caseType.ToUpper().Trim() == "UPPERCASEALPHANUMERIC")
                {
                    Charsize[i] = upperCharacters[random.Next(lowerCharacters.Length)];
                }
                else if(caseType.ToUpper().Trim() == "BOTHCASEALPHANUMERIC")
                {
                    Charsize[i] = characters[random.Next(characters.Length)];
                }
          }
            var resultString = new String(Charsize);
            return resultString;
    }

        // Generates a Random Date Value With a Given Format (e.g.- ("yyyy-mm-dd HH:mm:ss.ff"), ("yyyy-mm-dd"))
        public static String GetRandomDateTime(string outputdateformat)
        {
            Random random = new Random();
            int days = random.Next(0, 365 * 10);
            DateTime currentDate = DateTime.Now;
            DateTime randomDate = currentDate.AddDays(-days);
            return randomDate.ToString(outputdateformat);
        }

        // Generates a random alphanumeric + Special Character string with a given size
        public static string RandomAlphanumericWithSpecialChracterString(int length, String caseType)
        {
            String lowerCase = "abcdefghijklmnopqrstuvwxyz0123456789";
            String upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            String bothCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            String specialCharacter = "!@#$%^&*~";
            String randomValue = "";

            if (caseType.ToUpper().Trim() == "LOWERCASENUMERICWITHSPECIALCHAR") 
            {
                for (int i = 0; i < length; i++)
                {
                    int stringLength = random.Next(lowerCase.Length);
                    randomValue = randomValue + lowerCase.ElementAt(stringLength);
                }
            }

            else if(caseType.ToUpper().Trim() == "UPPERCASENUMERICWITHSPECIALCHAR")
            {
                for (int i = 0; i < length; i++)
                {
                    int stringLength = random.Next(upperCase.Length); 
                    randomValue = randomValue + upperCase.ElementAt(stringLength);
                }

            }

            else if (caseType.ToUpper().Trim() == "BOTHCASENUMERICWITHSPECIALCHAR")
            {
                for (int i = 0; i < length; i++)
                {
                    int stringLength = random.Next(bothCase.Length); 
                    randomValue = randomValue + bothCase.ElementAt(stringLength);
                }

            }
            for (int j = 0; j < 2; j++)
            {
                int stringLength = random.Next(specialCharacter.Length);
                randomValue = randomValue + specialCharacter.ElementAt(stringLength);
            }

            return randomValue;
        }

        // Generates a random boolean value
        public static Boolean RandomBoolean()
        {
            bool randomBool = random.Next(2) == 1;
            return randomBool;
        }
        // Generates a random bit value
        public static int RandomBit()
        {
            int result = random.Next(0, 2);
            return result;
        }
        public static string RandomGUID()
        {
            return Guid.NewGuid()+"";
        }
    }
}
