using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Naloga3
    {
        public static void Resitev1()
        {
            /* The engine schematic (your puzzle input) consists of a visual representation of the engine. There are lots of numbers and symbols you don't really understand, but apparently any number adjacent to a symbol, even diagonally, is a "part number" and should be included in your sum. (Periods (.) do not count as a symbol.)
             * What is the sum of all of the part numbers in the engine schematic? */

            string path = "input3.txt";
            string[] readText = File.ReadAllLines(path);
            int sum = 0;
            for (int i = 0; i < readText.Length; i++)
            {
                for (int j = 0; j < readText[i].Length; j++)
                {
                    if (Char.IsDigit(readText[i][j]))
                    {
                        bool isValid = false;
                        string number = "";
                        if (j > 0 && readText[i][j - 1] != '.')
                        {
                            // There's a symbol to the left.
                            isValid = true;
                        }
                        while (j < readText[i].Length && Char.IsDigit(readText[i][j]))
                        {
                            if (i > 0 && j > 0 && readText[i - 1][j - 1] != '.')
                            {
                                // There's a symbol diagonally above to the left.
                                isValid = true;
                            }
                            if (i > 0 && readText[i - 1][j] != '.')
                            {
                                // There's a symbol above.
                                isValid = true;
                            }
                            if (i > 0 && j < readText[i].Length - 1 && readText[i - 1][j + 1] != '.')
                            {
                                // There's a symbol diagonally above to the right.
                                isValid = true;
                            }
                            if (i < readText[i].Length - 1 && j > 0 && readText[i + 1][j - 1] != '.')
                            {
                                // There's a symbol diagonally below to the left.
                                isValid = true;
                            }
                            if (i < readText[i].Length - 1 && readText[i + 1][j] != '.')
                            {
                                // There's a symbol below.
                                isValid = true;
                            }
                            if (i < readText[i].Length - 1 && j < readText[i].Length - 1 && readText[i + 1][j + 1] != '.')
                            {
                                // There's a symbol diagonally below to the right.
                                isValid = true;
                            }

                            number = number + Convert.ToString(readText[i][j]);
                            j++;
                        }
                        if (j < readText[i].Length && readText[i][j] != '.')
                        {
                            // There's a symbol to the right.
                            isValid = true;
                        }
                        int partNumber = Convert.ToInt32(number);
                        if (isValid)
                        {
                            sum += partNumber;
                        }
                    }
                }
            }
            Console.WriteLine("The sum of all of the part numbers is " + sum);
        }

        public static List<char> GetChars()
        {
            string path = "input3.txt";
            string[] readText = File.ReadAllLines(path);
            List<char> chars = new List<char>();
            foreach (string line in readText)
            {
                foreach (char c in line)
                {
                    if (chars.Contains(c) == false && Char.IsDigit(c) == false && c != '.')
                    {
                        chars.Add(c);
                    }
                }
            }
            return chars; // Returns '#', '/', '*', '-', '+', '&', '$', '=', '@', '%'
        }


    }
}
