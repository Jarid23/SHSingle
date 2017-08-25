using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer =-1;
            int playerGuess;
            string playerInput;
            string UserName;
            int NumberOfGuesses = 0;
            string GameDifficulty;

            do
            {
                Console.WriteLine("Enter desired game difficulty : easy, medium or hard ");
                GameDifficulty = Console.ReadLine();

                if (GameDifficulty == "easy")
                {
                    Random r = new Random();
                    theAnswer = r.Next(1, 6);
                }
                else if (GameDifficulty == "medium")
                {
                    Random r = new Random();
                    theAnswer = r.Next(1, 21);
                }
                else if (GameDifficulty == "hard")
                {
                    Random r = new Random();
                    theAnswer = r.Next(1, 51);
                }
            }
            while (theAnswer == -1);

            Console.WriteLine("What's your name ? : ");
            UserName = Console.ReadLine();

            do
            {
                // get player input
                Console.Write(UserName + " Enter your guess (1-5 for easy, 1-20 for medium, 1-50 for hard): ");
                NumberOfGuesses++;
                playerInput = Console.ReadLine();
              

                
                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                
                    if ((playerGuess > 20) || (playerGuess < 1))
                    {
                        Console.WriteLine("You entered an invaled number. Keep it 1-20 - try again");
                    }
                    if ((playerGuess == theAnswer) && (NumberOfGuesses == 1))
                    {
                        Console.WriteLine(UserName + $" {theAnswer} was the number and you guessed it in one try");
                        break;
                    }
                    if (playerGuess == theAnswer)
                    {
                        Console.WriteLine(UserName + $" {theAnswer} was the number.  You Win! BTW it took you this many guesses : "+ NumberOfGuesses);
                        break;
                    }
                  
                    else
                    {
                        if (playerGuess > theAnswer)
                        {
                            Console.WriteLine(UserName + " Your guess was too High!");
                        }
                        else
                        {
                            Console.WriteLine(UserName + " Your guess was too low!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(UserName + " That wasn't a number!");
                }

            } while (true);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
