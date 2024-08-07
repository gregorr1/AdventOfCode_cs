using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Naloga1
    {
        public static void Resitev1()
        {
            /* The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover. On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.
              Consider your entire calibration document. What is the sum of all of the calibration values? */

            string path = "input1.txt";
            string[] readText = File.ReadAllLines(path);
            int sum = 0;
            for (int i = 0; i < readText.Length; i++)
            {
                string line = readText[i];
                int coordinate = 0;
                for (int j = 0; j < line.Length; j++)
                {
                    if (Char.IsDigit(line, j))
                    {
                        int firstCoordinate = (int)(line[j] - '0');
                        coordinate += firstCoordinate * 10;
                        break;
                    }
                }
                for (int j = line.Length - 1; j >= 0; j--)
                {
                    if (Char.IsDigit(line, j))
                    {
                        int secondCoordinate = (int)(line[j] - '0');
                        coordinate += secondCoordinate;
                        break;
                    }
                }
                sum += coordinate;
            }
            Console.WriteLine("The answer is " + sum);   
        }

        public static void Resitev2()
        {
            /* Your calculation isn't quite right. It looks like some of the digits are actually spelled out with letters: one, two, three, four, five, six, seven, eight, and nine also count as valid "digits".
              Equipped with this new information, you now need to find the real first and last digit on each line.
              What is the sum of all of the calibration values? */

            Dictionary<string, int> dict = new()
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            string path = "input1.txt";
            string[] readText = File.ReadAllLines(path);
            string[] textNumbers = dict.Keys.ToArray();
            int sum = 0;
            for (int i = 0; i < readText.Length; i++)
            {
                string line = readText[i];
                int coordinate = 0;

                // Finding min index of a dictionary key
                int minIndex = -1;
                string minKey = "";
                foreach (string num in textNumbers)
                {
                    int index = line.IndexOf(num);
                    if (index > -1)
                    {
                        if (minIndex == -1 || minIndex > index)
                        {
                            minIndex = index;
                            minKey = num;
                        }
                    }
                }
                string minIndexReplaced = line;
                if (dict.ContainsKey(minKey))
                {
                    minIndexReplaced = line.Remove(minIndex, minKey.Length).Insert(minIndex, Convert.ToString(dict[minKey]));
                }

                // Finding max index of a dictionary key
                int maxIndex = -1;
                string maxKey = "";
                foreach (string num in textNumbers)
                {
                    int index = line.LastIndexOf(num);
                    if (index > -1)
                    {
                        if (maxIndex < index)
                        {
                            maxIndex = index;
                            maxKey = num;
                        }
                    }
                }
                string maxIndexReplaced = line;
                if (dict.ContainsKey(maxKey))
                {
                    maxIndexReplaced = line.Remove(maxIndex, maxKey.Length).Insert(maxIndex, Convert.ToString(dict[maxKey]));
                }

                // Calculating the first coordinate from the line with the first instance of a dictionary key replaced by its value
                for (int j = 0; j < minIndexReplaced.Length; j++)
                {
                    if (Char.IsDigit(minIndexReplaced, j))
                    {
                        int firstCoordinate = (int)(minIndexReplaced[j] - '0');
                        coordinate += firstCoordinate * 10;
                        break;
                    }
                }

                // Calculating the second coordinate from the line with the last instance of a dictionary key replaced by its value
                for (int j = maxIndexReplaced.Length - 1; j >= 0; j--)
                {
                    if (Char.IsDigit(maxIndexReplaced, j))
                    {
                        int secondCoordinate = (int)(maxIndexReplaced[j] - '0');
                        coordinate += secondCoordinate;
                        break;
                    }
                }
                sum += coordinate;
            }
            Console.WriteLine("The answer is " + sum);
        }
    }
}
