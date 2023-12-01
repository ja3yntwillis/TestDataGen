using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbScript.DataGeneration;

namespace DbScript.DataGeneration
{
    internal class GenerateRandomData
    {
        public static void GetRandomData(String type, int size, String format)
        {
            //string TypeofNumeric = "integer";

            switch (type.ToLower().Trim())
            {
                case "int":
                    Console.WriteLine("This is a part of integer switch");
               
                    switch (format.ToLower().Trim()) // long /float
                    {
                        case ("long"):
                            RandomDataGeneration.RandomDigits(size);
                            Console.WriteLine("Random Test Data Genaration For Long Done Here");
                            break;
                        case ("float"):
                            RandomDataGeneration.RandomFloatingNumber(size);
                            Console.WriteLine("Random Test Data Genaration For Long Done Here");
                            break;
                    }
                    break;
                case "string":

                    switch (format.ToLower().Trim())
                    // [lowercase/uppercase] /
                    // [lowercasealphanumeric/uppercasealphanumeric/bothcasealphanumeric] /
                    // [lowercasenumericwithspecialchar/uppercasenumericwithspecialchar/bothcasenumericwithspecialchar]
                    {
                        case ("lowercase"):
                            RandomDataGeneration.RandomAlphabates(size, "lowercase");
                            Console.WriteLine("Random Test Data Genaration For Lowercase Done Here");
                            break;
                        case ("uppercase"):
                            RandomDataGeneration.RandomAlphabates(size, "uppercase");
                            Console.WriteLine("Random Test Data Genaration For Uppercase Done Here");
                            break;
                        case ("lowercaseAlphanumeric"):
                            RandomDataGeneration.RandomAlphanumericString(size, "lowercasealphanumeric");
                            Console.WriteLine("Random Test Data Genaration For LowercaseAlphanumeric Done Here");
                            break;
                        case ("uppercaseAlphanumeric"):
                            RandomDataGeneration.RandomAlphanumericString(size, "uppercasealphanumeric");
                            Console.WriteLine("Random Test Data Genaration For UppercaseAlphanumeric Done Here");
                            break;
                        case ("bothCaseAlphanumeric"):
                            RandomDataGeneration.RandomAlphanumericString(size, "bothcasealphanumeric");
                            Console.WriteLine("Random Test Data Genaration For BothCaseAlphanumeric Done Here");
                            break;
                        case ("lowercasenumericwithspecialchar"):
                            RandomDataGeneration.RandomAlphanumericWithSpecialChracterString(size, "lowercasenumericwithspecialchar");
                            Console.WriteLine("Random Test Data Genaration For Lowercasenumericwithspecialchar Done Here");
                            break;
                        case ("uppercasenumericwithspecialchar"):
                            RandomDataGeneration.RandomAlphanumericWithSpecialChracterString(size, "uppercasenumericwithspecialchar");
                            Console.WriteLine("Random Test Data Genaration For Uppercasenumericwithspecialchar Done Here");
                            break;
                        case ("bothcasenumericwithspecialchar"):
                            RandomDataGeneration.RandomAlphanumericWithSpecialChracterString(size, "bothcasenumericwithspecialchar");
                            Console.WriteLine("Random Test Data Genaration For Bothcasenumericwithspecialchar Done Here");
                            break;


                    }
                    break;
                default: break;
            }
        }
        }
}
