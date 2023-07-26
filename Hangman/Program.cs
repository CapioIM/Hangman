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
                List<char> pressedKeys = new List<char>();                          //new list initiated with every game, list of pressed keys
               
                int wordRandomFromList = RNG.Next(LISTOFWORDS.Count);                    // choose random number
                string wordToGuess = LISTOFWORDS[wordRandomFromList];                    //assign random number to word and store in a string

                char[] arrayLettersGuessed = new char[wordToGuess.Length];                    //create array with info which will be shown to player
                for (int c = 0; c < arrayLettersGuessed.Length; c++)                    //assign amount of dashes with amount of characters in secret word
                {
                    arrayLettersGuessed[c] = PLACEHOLDER;
                }

                //place random character in word for easier guess, would be probabaly more usefull for longer words
                Console.WriteLine(" 1 Random position letter has been revealed, however that letter might still be in the word");
                int revealIndex = RNG.Next(wordToGuess.Length);
                arrayLettersGuessed[revealIndex] = wordToGuess[revealIndex];

                int triesLeft = TRIES;                // on every start of game takes value from constant

                while (triesLeft > 0 && arrayLettersGuessed.Contains(PLACEHOLDER))              //game loop, as long as there are tries AND letters to be guessed
                {
                    Console.WriteLine($"Guess random word letter by letter within {triesLeft} attempts!");           // little discription of game
                    Console.Write("You have pressed : ");                               //shows pressed characters in a list 
                    foreach (char c in pressedKeys)
                    {
                        Console.Write(c);
                    }
                    Console.WriteLine();

                    Console.WriteLine(arrayLettersGuessed);

                    char userLetter = Console.ReadKey().KeyChar;           // keypress 
                    pressedKeys.Add(userLetter);                            //adds pressed character to list of pressed characters

                    if (wordToGuess.Contains(userLetter))               // if secret word contains key pressed than replace char in word to assemble
                    {
                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuess[i] == userLetter)
                            {
                                arrayLettersGuessed[i] = userLetter;
                            }
                        }
                    }
                    else
                    {
                        triesLeft--;
                    }
                    Console.Clear();
                }    //end of game loop

                if (arrayLettersGuessed.Contains(PLACEHOLDER))              //if array still contains placeholders , write text
                {
                    Console.WriteLine("You have run out of tries ! Better luck next time");
                    Console.WriteLine($"Word you were trying to guess was :  {wordToGuess}");
                }
                else
                {
                    Console.WriteLine($"You have sucessfully guessed word: {wordToGuess} !");
                }

                // play again loop
                Console.WriteLine("If you want to play again press Y for yes, or any key for No ");
                if (Console.ReadKey(true).Key.ToString().ToLower() == "y")
                {
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
