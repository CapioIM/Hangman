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
        const int TRIES = 10;
        const char PLACEHOLDER = '-';
        static void Main(string[] args)
        {

            while (true)
            {
                int wordRandomFromList = RNG.Next(LISTOFWORDS.Count);                    // choose random number
                string wordToGuess = LISTOFWORDS[wordRandomFromList];                    //assign random letter to word and store in a string

                char[] arrayToGuess = new char[wordToGuess.Length];                    //create array with info which will be shown to player
                for (int c = 0; c < arrayToGuess.Length; c++)                    //assign amount of dashes with amount of characters in secret word
                {
                    arrayToGuess[c] = PLACEHOLDER;
                }

                int triesLeft = TRIES;

                while (triesLeft > 0)                    //game loop
                {
                    Console.WriteLine($"Guess random word letter by letter within {triesLeft} attempts!");                        // little discription of game
                    Console.WriteLine(arrayToGuess);
                    char userLetter = Console.ReadKey().KeyChar;                     // keypress 

                    if (wordToGuess.Contains(userLetter))               // if secret word contains key pressed than replace char in word to assemble
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

                    if (arrayToGuess.Contains(PLACEHOLDER) == false)                        //Check if array still has placeholders
                    {
                        Console.WriteLine("You have sucessfully guessed word!");
                        break;
                    }
                    else                        //deduct attempts with wrong character guess
                    {
                        triesLeft--;
                    }
                }
                if (triesLeft == 0)              //if array still contains placeholders and amount of tries run out , write text
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
