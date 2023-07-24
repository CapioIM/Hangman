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
                    int wordRandomFromList = RNG.Next(RNGMIN, LISTOFWORDS.Count);
                    //assign random letter to word and store in a string
                    string wordToGuess = LISTOFWORDS[wordRandomFromList];
                    //create array with info which will be shown to player
     ////char[] arrayToGuess = new char[wordToGuess.Length];
                    char[] arrayToGuess = new char[LISTOFWORDS.Count];
                    //assign amount of dashes with amount of characters in secret word
                    for (int c = 0; c < arrayToGuess.Length; c++)
                    {
                        arrayToGuess[c] = '-';
                    }
                    int triesLeft = TRIES;
                    //game loop
                    while (triesLeft > 0)
                    {
                        Console.WriteLine($"Guess word below within {triesLeft} attempts");
                        Console.WriteLine(arrayToGuess);
                        // keypress 
                        char userLetter = Console.ReadKey().KeyChar;
                        // if secret word contains key pressed than replace char in word to assemble
                        if (wordToGuess.Contains(userLetter))
                        {
                            for (int i = 0; i < wordToGuess.Length; i++)
                            {
                                if (wordToGuess[i] == userLetter)
                                {
                                    arrayToGuess[i] = userLetter;
                                }
                            }
                        }
                        Console.Clear();
                        //Check if array still has placeholders
                        if (arrayToGuess.Contains('-') == false)
                        {
                            Console.WriteLine("Win");
                            break;
                        }
                        //deduct attempts with wrong character guess
                        if (wordToGuess.Contains(userLetter) == false)
                        {
                            triesLeft--;
                        }
                        Console.WriteLine($"You have {triesLeft} attempts left");
                    }
                    //if array still contains placeholders and amount of tries run out , write text
                    if (arrayToGuess.Contains('-') == true || triesLeft == 0)
                    {
                        Console.WriteLine($"Word you were trying to guess was {wordToGuess}");
                    }
                    // play again loop
                    Console.WriteLine("If you want to play again press Y for yes, or N for No ");
                    if (Console.ReadLine().ToLower().Equals("y"))
                    {
                        Console.Clear();
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
