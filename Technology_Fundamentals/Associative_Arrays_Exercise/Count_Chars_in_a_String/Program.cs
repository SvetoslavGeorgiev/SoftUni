using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            //Or we can do it this way: 
            var words = Console.ReadLine()                 //   
               .Where(x => x != ' ')                       // comment this for second way!!
               .ToArray();                                 //
            //var words = Console.ReadLine()              // 
            //    .Split()                                //  uncomment this for second way!!
            //    .ToList();                              //
            var chars = new Dictionary<char, int>();

            foreach (var @char in words)                   //
            {                                              //
                if (chars.ContainsKey(@char))              //
                {                                          //
                    chars[@char]++;                        //
                }                                          // comment!!
                else                                       //
                {                                          //
                    chars.Add(@char, 1);                   //
                }                                          //
            }                                              //

            //if (words.Count > 1)                               //
            //{                                                  //
            //    foreach (var word in words)                    //
            //    {                                              //
            //        var listOfchars = word.ToCharArray();      //  
            //
            //        foreach (var @char in listOfchars)         //
            //        {                                          //    uncomment!!
            //            if (chars.ContainsKey(@char))          //
            //            {                                      //
            //                chars[@char]++;                    //
            //            }                                      //
            //            else                                   //
            //            {                                      //
            //                chars.Add(@char, 1);               //
            //            }                                      //
            //        }                                          //
            //    }                                              //
            //}                                                  //   uncomment!!
            //else                                               //
            //{                                                  //
            //    var word = words[0];                           //
            //    var listOfchars = word.ToCharArray();          //
            //
            //    foreach (var @char in listOfchars)             //
            //    {                                              //
            //        if (chars.ContainsKey(@char))              //
            //        {                                          //
            //            chars[@char]++;                        //
            //        }                                          //     uncomment!!
            //        else                                       //
            //        {                                          //
            //            chars.Add(@char, 1);                   //
            //        }                                          //
            //    }                                              //
            //}                                                  //

            foreach (var kvp in chars)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
