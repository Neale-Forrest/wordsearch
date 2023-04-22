using System;
using System.Data;

namespace WordSearch
{
    class Program
    {
        static char[,] Grid = new char[,] {
            {'C', 'P', 'K', 'X', 'O', 'I', 'G', 'H', 'S', 'F', 'C', 'H'},
            {'Y', 'G', 'W', 'R', 'I', 'A', 'H', 'C', 'Q', 'R', 'X', 'K'},
            {'M', 'A', 'X', 'I', 'M', 'I', 'Z', 'A', 'T', 'I', 'O', 'N'},
            {'E', 'T', 'W', 'Z', 'N', 'L', 'W', 'G', 'E', 'D', 'Y', 'W'},
            {'M', 'C', 'L', 'E', 'L', 'D', 'N', 'V', 'L', 'G', 'P', 'T'},
            {'O', 'J', 'A', 'A', 'V', 'I', 'O', 'T', 'E', 'E', 'P', 'X'},
            {'C', 'D', 'B', 'P', 'H', 'I', 'A', 'W', 'V', 'X', 'U', 'I'},
            {'L', 'G', 'O', 'S', 'S', 'B', 'R', 'Q', 'I', 'A', 'P', 'K'},
            {'E', 'O', 'I', 'G', 'L', 'P', 'S', 'D', 'S', 'F', 'W', 'P'},
            {'W', 'F', 'K', 'E', 'G', 'O', 'L', 'F', 'I', 'F', 'R', 'S'},
            {'O', 'T', 'R', 'U', 'O', 'C', 'D', 'O', 'O', 'F', 'T', 'P'},
            {'C', 'A', 'R', 'P', 'E', 'T', 'R', 'W', 'N', 'G', 'V', 'Z'}
        };

        static string[] Words = new string[] 
        {
            "CARPET",
            "CHAIR",
            "DOG",
            "BALL",
            "DRIVEWAY",
            "FISHING",
            "FOODCOURT",
            "FRIDGE",
            "GOLF",
            "MAXIMIZATION",
            "PUPPY",
            "SPACE",
            "TABLE",
            "TELEVISION",
            "WELCOME",
            "WINDOW"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Word Search");

            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    Console.Write(Grid[y, x]);
                    Console.Write(' ');
                }
                Console.WriteLine("");

            }

            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

            FindWords();

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        private static void FindWords()
        {
            // Loop through each word in the list of words.
            for (int word = 0; word < Words.Length; word++)
            {
                // Loop through each row in the grid.
                for (int row = 0; row < Grid.GetLength(0); row++)
                {
                    // Loop through each col in the grid.
                    for (int col = 0; col < Grid.GetLength(1); col++)
                    {
                        // Loop through each possible direction (8 total).
                        for (int directionX = -1; directionX <= 1; directionX++)
                        {
                            for (int directionY = -1; directionY <= 1; directionY++)
                            {
                                // Skip the case where both dx and dy are 0, as this represents no movement.
                                if (directionX != 0 || directionY != 0)
                                {
                                    // run through each letter around the current work and see if there is a match
                                    for (int letter = 0; letter < Words[word].Length && 
                                                row + letter*directionX >= 0 && row + letter*directionX < Grid.GetLength(0) && // check we are in the x grid
                                                col + letter*directionY >= 0 && col + letter*directionY < Grid.GetLength(1) && // check we are int the y grid
                                                Grid[row + letter*directionX, col + letter*directionY] == Words[word][letter]; // does the word match 
                                        letter++)
                                    {
                                        // i have found the word.  print the cordinates
                                        if (letter == Words[word].Length - 1)
                                            Console.WriteLine($"Found {Words[word]} at ({row},{col}) to ({row + letter*directionX},{col + letter*directionY})");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
