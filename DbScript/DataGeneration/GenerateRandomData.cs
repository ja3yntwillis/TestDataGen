using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DbScript.DataGeneration;

namespace DbScript.DataGeneration
{
    internal class GenerateRandomData
    {
        public static String GetRandomData(String type, int size, String format)
        {
            string result = "";

            switch (type.ToLower().Trim())
            {
                case "int":
            
                    switch (format.ToLower().Trim()) // long /float
                    {
                        case "long":
                            result = RandomDataGeneration.RandomDigits(size).ToString();
                            break;
                        case "float":
                            result = RandomDataGeneration.RandomFloatingNumber(size).ToString();
                            break;
                    }
                    break;
                case "string":

                    switch (format.ToLower().Trim())
                    // [lowercase/uppercase] /
                    // [lowercasealphanumeric/uppercasealphanumeric/bothcasealphanumeric] /
                    // [lowercasenumericwithspecialchar/uppercasenumericwithspecialchar/bothcasenumericwithspecialchar]
                    {
                        case "lowercase":
                            result = ConfigurationManager.AppSettings["QAidentifier"] +RandomDataGeneration.RandomAlphabates(size, "lowercase");
                            break;
                        case "uppercase":
                            result = ConfigurationManager.AppSettings["QAidentifier"] +RandomDataGeneration.RandomAlphabates(size, "uppercase");
                            break;
                        case "lowercasealphanumeric":
                            result = ConfigurationManager.AppSettings["QAidentifier"] + RandomDataGeneration.RandomAlphanumericString(size, "lowercasealphanumeric");
                            break;
                        case "uppercasealphanumeric":
                            result = ConfigurationManager.AppSettings["QAidentifier"] + RandomDataGeneration.RandomAlphanumericString(size, "uppercasealphanumeric");
                            break;
                        case "bothcasealphanumeric":
                            result = ConfigurationManager.AppSettings["QAidentifier"] + RandomDataGeneration.RandomAlphanumericString(size, "bothcasealphanumeric");
                            break;
                        case "lowercasenumericwithspecialchar":
                            result = ConfigurationManager.AppSettings["QAidentifier"] + RandomDataGeneration.RandomAlphanumericWithSpecialChracterString(size, "lowercasenumericwithspecialchar");
                            break;
                        case "uppercasenumericwithspecialchar":
                            result = ConfigurationManager.AppSettings["QAidentifier"] + RandomDataGeneration.RandomAlphanumericWithSpecialChracterString(size, "uppercasenumericwithspecialchar");
                            break;
                        case "bothcasenumericwithspecialchar":
                            result = ConfigurationManager.AppSettings["QAidentifier"] +         RandomDataGeneration.RandomAlphanumericWithSpecialChracterString(size, "bothcasenumericwithspecialchar");
                            break;
                    }
                    break;
                case "boolean":
                    result = RandomDataGeneration.RandomBoolean().ToString();
                    break;

                case "bit":
                    result = RandomDataGeneration.RandomBit().ToString();
                    break;

               case "date":
                    result = RandomDataGeneration.GetRandomDateTime(format);
                    break;

                case "guid":
                    result = RandomDataGeneration.RandomGUID();
                    break;
                default: break;

            }
            return result;
        }
        }
}
