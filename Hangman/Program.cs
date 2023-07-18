using System;
namespace Hangman
{
    internal class Program
    {
        public static List<string> wordList = new List<string>(){"staff","woozy","twelfth","wizard",
                                                    "ivy","walkway","glyph","croquet","jazzy","lengths",                          //List of Words to play from
                                                    "cozy","joyful","swivel","yachtsman","curacao","kazoo",
                                                    "pizazz","kilobyte","blitz","affix",
                                                    "fishhook","myth","quips","jovial","zigzag",
                                                    };
        public static Random rng = new Random();                                                                                   // random number function
        public static int rngMin = 0;
        public static int rngMax = wordList.Count;
        static void Main(string[] args)
        {
            //Hangman
            // random number to choose from list of words
            int wordChoiceFromList = rng.Next(rngMin, rngMax + 1);
            //assign string holding word from list of words
            string guessWord = wordList[wordChoiceFromList];               
            //
            char userGuessLetter = Convert.ToChar(Console.ReadKey());
            foreach (char letter in guessWord)
            {
                if (letter == userGuessLetter)
                {
                    Console.WriteLine(guessWord[letter]);
                }
            }
        }
    }
}