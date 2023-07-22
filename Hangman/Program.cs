using System;
namespace Hangman
{
    internal class Program
    {
        public static List<string> LISTOFWORDS = new List<string>(){"staff","woozy","twelfth","wizard",
                                                    "ivy","walkway","glyph","croquet","jazzy","lengths",                          //List of Words to play from
                                                    "cozy","joyful","swivel","yachtsman","curacao","kazoo",
                                                    "pizazz","kilobyte","blitz","affix",
                                                    "fishhook","myth","quips","jovial","zigzag",
                                                    };
        public static Random RNG = new Random();                                                                                   // random number function
        public const int RNGMIN = 0;
        public const int TRIES = 10;
        static void Main(string[] args)
        {
            {
                while (true)
                {
                    // choose random number
                    int wordChoiceFromList = RNG.Next(RNGMIN, LISTOFWORDS.Count);
                    //assign random letter to word and store in a string
                    string wordToGuess = LISTOFWORDS[wordChoiceFromList];
                    //create array with info which will be shown to player
                    char[] arrayToGuess = new string('-', wordToGuess.Length).ToCharArray();
                    //assign amount of dashes as amount of letters in secret word 
                    //for (int c = 0; c < arrayToGuess.Length; c++)
                    //{
                    //    arrayToGuess[c] = '-';
                    //}
                    //game loop
                    int triesLeft = TRIES;
                    while (triesLeft>0)
                    {
                        Console.WriteLine("Guess word below");
                        Console.WriteLine(arrayToGuess);
                        char userLetter = Console.ReadKey().KeyChar;
                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuess[i] == userLetter)
                            {
                                arrayToGuess[i] = userLetter;
                            }
                        }
                        Console.Clear();
                        if (wordToGuess == new string(arrayToGuess))
                        {
                            Console.WriteLine("Win");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"You have {triesLeft-1} attempts left");
                            triesLeft--;
                        }
                    }
                    Console.WriteLine($"Word you were trying to guess was {wordToGuess}");
                    Console.WriteLine("If you want to play again press Y for yes, or N for No ");
                    if (Console.ReadLine() != null && Console.ReadLine().ToLower() == "y")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
