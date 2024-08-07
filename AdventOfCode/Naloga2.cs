using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Naloga2
    {
        /* You play several games and record the information from each game (your puzzle input). Each game is listed with its ID number (like the 11 in Game 11: ...) followed by a semicolon-separated list of subsets of cubes that were revealed from the bag (like 3 red, 5 green, 4 blue).
         * Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes. What is the sum of the IDs of those games? */

        public static void Resitev1()
        {
            string path = "input2.txt";
            string[] readText = File.ReadAllLines(path);
            char[] delimiters = [',', ';', ':'];
            int sum = 0;
            foreach (string game in readText)
            {
                // Calculate the info for every game (line of input)
                string[] substrings = game.Split(delimiters);
                int gameID = 0;
                int maxReds = 0;
                int maxBlues = 0;
                int maxGreens = 0;
                foreach (string substring in substrings)
                {
                    // Determine the game ID
                    if (substring.Contains("Game"))
                    {
                        gameID = int.Parse(substring.Replace("Game ", ""));
                    }

                    // Determine the highest number of blue cubes shown during this game
                    if (substring.Contains("blue"))
                    {
                        int blues = int.Parse(substring.Replace(" blue", ""));
                        if (blues > maxBlues)
                        {
                            maxBlues = blues;
                        }
                    }

                    // Determine the highest number of red cubes shown during this game
                    if (substring.Contains("red"))
                    {
                        int reds = int.Parse(substring.Replace(" red", ""));
                        if (reds > maxReds)
                        {
                            maxReds = reds;
                        }

                    }

                    // Determine the highest number of green cubes shown during this game
                    if (substring.Contains("green"))
                    {
                        int greens = int.Parse(substring.Replace(" green", ""));
                        if (greens > maxGreens)
                        {
                            maxGreens = greens;
                        }
                    }
                }
                if (maxReds <= 12 && maxGreens <= 13 && maxBlues <= 14)
                {
                    sum += gameID;
                }
            }
            Console.WriteLine("The sum of the IDs of all games you can play is " + sum);
        }

        public static void Resitev2()
        {
            /* As you continue your walk, the Elf poses a second question: in each game you played, what is the fewest number of cubes of each color that could have been in the bag to make the game possible?
             * The power of a set of cubes is equal to the numbers of red, green, and blue cubes multiplied together.
             * For each game, find the minimum set of cubes that must have been present. What is the sum of the power of these sets? */

            string path = "input2.txt";
            string[] readText = File.ReadAllLines(path);
            char[] delimiters = [',', ';', ':'];
            int sum = 0;
            foreach (string game in readText)
            {
                // Calculate the info for every game (line of input)
                string[] substrings = game.Split(delimiters);
                int maxReds = 0;
                int maxBlues = 0;
                int maxGreens = 0;
                foreach (string substring in substrings)
                {
                    // Determine the highest number of blue cubes shown during this game
                    if (substring.Contains("blue"))
                    {
                        int blues = int.Parse(substring.Replace(" blue", ""));
                        if (blues > maxBlues)
                        {
                            maxBlues = blues;
                        }
                    }

                    // Determine the highest number of red cubes shown during this game
                    if (substring.Contains("red"))
                    {
                        int reds = int.Parse(substring.Replace(" red", ""));
                        if (reds > maxReds)
                        {
                            maxReds = reds;
                        }

                    }

                    // Determine the highest number of green cubes shown during this game
                    if (substring.Contains("green"))
                    {
                        int greens = int.Parse(substring.Replace(" green", ""));
                        if (greens > maxGreens)
                        {
                            maxGreens = greens;
                        }
                    }
                }
                int power = maxBlues * maxGreens * maxReds;
                sum += power;
            }
            Console.WriteLine("The sum of the powers of all sets is " + sum);
        }
    }
}
