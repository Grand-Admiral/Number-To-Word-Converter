using System;
using ConverterLibrary;

namespace ConverterLibrary
{
    public static class Class1
    {
        //Input: “123.45”
        //Output: “ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS”

        public static string ConvertNumbersToWords(string NumberString)
        {
            string[] a = ToNums(NumberString);
            return ToWords(a); //return ToWords(output)
        }

        public static string[] ToNums(string NumberString) //to numbers 100 20 3 = 123
        {
            string[] output = new string[100];

            float NumberInt = float.Parse(NumberString); //convert string to int

            float floattimes = 0;
            float value = 100;

            int round = 0;
            while (value > 0)
            {
                floattimes = NumberInt / value; //get number of hundreds
                int times = 0;

                while (floattimes >= 1) //find whole number of hundreds
                {
                    times += 1;
                    floattimes -= 1;
                }
                floattimes = (floattimes * value); //convert the remainder to a whole number
                NumberInt = floattimes;

                NumberInt = Convert.ToSingle(Math.Round(floattimes, 2, MidpointRounding.AwayFromZero)); //round to two decimal place

                output[round] = Math.Round(times * value, 2, MidpointRounding.AwayFromZero).ToString(); // convert to numbers
                round++;

                if (value == 100)
                {
                    value -= 90;
                } else if (value == 10)
                {
                    value -= 9;
                }
                else if (value <= 1)
                {
                    value -= Convert.ToSingle(0.90); //have 99 for cents to be joined
                } else
                {
                    value = -100;
                }
            }
            
            output[round] = Math.Round(NumberInt, 2, MidpointRounding.AwayFromZero).ToString(); // add NumInt to arr
            return output; //returns array or numbers split up {100,20,4} = 124
        }

        public static string ToWords(string[] Numbers)
        {
            string[] oneToNine = {
                "ONE", "TWO",
                "THREE", "FOUR",
                "FIVE", "SIX",
                "SEVEN", "EIGHT",
                "NINE","TEN",

                "ELEVEN", "TWELVE",
                "THIRTEEN", "FOURTEEN",
                "FIFTEEN", "SIXTEEN",
                "SEVENTEEN", "EIGHTEEN",
                "NINETEEN"
            };

            string[] tens = {
                "TEN", "TWENTY",
                "THIRTY", "FORTY",
                "FIFTY", "SIXTY",
                "SEVENTY", "EIGHTTY",
                "NINETY"
            };
            string output = "";

            int track = 0;

            if (Int32.Parse(Numbers[track]) / 100 > 0)
            {
                int a = Int32.Parse(Numbers[0]) / 100;
                output += oneToNine[a - 1] + " HUNDRED";//convert to word
                if (Int32.Parse(Numbers[1]) != 0) //check if need - for next number
                {
                    output += " AND ";
                }
            }
            track++;
            
            if (Int32.Parse(Numbers[track]) / 10 >= 2) //convert the ty's like twen(ty)
            {
                int a = Int32.Parse(Numbers[1]) / 10;
                output += tens[a - 1];//convert to word

                if (Int32.Parse(Numbers[2]) != 0) //check if need - for next number
                {
                    output += "-";
                }
            }
            
            if (Int32.Parse(Numbers[track]) / 10 == 1) //convert 10-19
            {
                int a = Int32.Parse("1" + Numbers[2]);
                output += oneToNine[a - 1];//convert to word
                track++;
            }
            track++;
            
            if (double.Parse(Numbers[track]) / 1 >= 1 && track == 2) //convert 1-9, track will skip if was used for 10-19
            {
                int a = Int32.Parse(Numbers[2]) / 1;
                output += oneToNine[a - 1];//convert to word
                //output += a;
                
            }
            
            output += " DOLLARS";

            if (track == 2){
                track++; //if track is 2
            }

            if (double.Parse(Numbers[track]) != 0.00) //check if need - for next number
            {
                output += " AND ";
            }
            else if (double.Parse(Numbers[track+1]) != 0.00)
            {
                output += " AND ";
            } else
            {
                return output;
            }


            //CENTS

            
            if ((double.Parse(Numbers[track]) * 100) / 10 >= 2) //convert the ty's like twen(ty)
            {
                double b = double.Parse(Numbers[track])*100;

                int a = Convert.ToInt32(b.ToString()) / 10;
                output += tens[a - 1];//convert to word

                if (double.Parse(Numbers[track+1]) != 0) //check if need - for next number
                {
                    output += "-";
                }
            }

            if ((double.Parse(Numbers[track]) * 100) / 10 == 1) //convert 10-19
            {
                double b = double.Parse(Numbers[track+1]) * 100;

                int a = Convert.ToInt32("1" + b);
                
                output += oneToNine[a - 1];//convert to word
                track++;
            }

            track++;
            if (track == 5)
            {
                return output + " CENTS";
            }

            if ((double.Parse(Numbers[track]) * 100) / 1 >= 1 && track == 4) //convert 1-9, track will skip if was used for 10-19
            {
                double b = double.Parse(Numbers[track]) * 100;
                int a = Convert.ToInt32(b) / 1;
                output += oneToNine[a - 1];//convert to word
                                           //output += a;

            }

            output += " CENTS";

            return output;
        }
    }
}
