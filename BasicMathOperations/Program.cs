using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Keep track of the user's correct and incorrect answers
            int correctCount = 0, incorrectCount = 0;

            // Start the program loop; Repeat until the user wants to stop generating problems
            bool restart = true;
            do
            {
                // Generate the math problems to ask
                String problem1, problem2, problem3, problem4;

                // Create 2 pairs of number slots (4 each) to use for generating the problems
                double[] op1 = new double[4], op2 = new double[4];
                double userInput;

                // Randomly generate the numbers involved in the problems, within the operator arrays
                Random numGen = new Random();
                for (var i = 0; i < 4; i++)
                {
                    op1[i] = numGen.Next(1, 11);
                    op2[i] = numGen.Next(1, 11);
                }

                // Store the entire equation as a string, so we can ask later
                problem1 = (op1[0] + " + " + op2[0]);
                problem2 = (op1[1] + " - " + op2[1]);
                problem3 = (op1[2] + " * " + op2[2]);
                problem4 = (op1[3] + " / " + op2[3]);

                Console.WriteLine("Solve the 4 math equations:");

                // Prompt the user about Math Problem #1
                Console.Write("\n" + problem1 + " = ");

                // Ask for and validate the user's response
                while (!double.TryParse(Console.ReadLine(), out userInput))
                    Console.Write("Invalid response. Please enter a valid numerical value: ");

                if (userInput == op1[0] + op2[0])
                {
                    Console.WriteLine("Correct!");
                    correctCount++;
                }
                else
                {
                    Console.WriteLine("Incorrect...");
                    incorrectCount++;
                }

                // Prompt the user about Math Problem #2
                Console.Write("\n" + problem2 + " = ");

                // Ask for and validate the user's response
                while (!double.TryParse(Console.ReadLine(), out userInput))
                    Console.Write("Invalid response. Please enter a valid numerical value: ");

                if (userInput == op1[1] - op2[1])
                {
                    Console.WriteLine("Correct!");
                    correctCount++;
                }
                else
                {
                    Console.WriteLine("Incorrect...");
                    incorrectCount++;
                }

                // Prompt the user about Math Problem #3
                Console.Write("\n" + problem3 + " = ");

                // Ask for and validate the user's response
                while (!double.TryParse(Console.ReadLine(), out userInput))
                    Console.Write("Invalid response. Please enter a valid numerical value: ");

                if (userInput == op1[2] * op2[2])
                {
                    Console.WriteLine("Correct!");
                    correctCount++;
                }
                else
                {
                    Console.WriteLine("Incorrect...");
                    incorrectCount++;
                }

                // Prompt the user about Math Problem #4
                Console.Write("\n" + problem4 + " = ");

                // Ask for and validate the user's response
                while (!double.TryParse(Console.ReadLine(), out userInput))
                    Console.Write("Invalid response. Please enter a valid numerical value: ");

                if (userInput == op1[3] / op2[3])
                {
                    Console.WriteLine("Correct!");
                    correctCount++;
                }
                else
                {
                    Console.WriteLine("Incorrect...");
                    incorrectCount++;
                }

                // Linebreak for tidiness
                Console.WriteLine();

                // Keep asking the user if they want to solve more problems until they give a proper answer
                String loopPrompt;
                do
                {
                    Console.Write("Would you like to solve 4 more problems? Y/N: ");
                    loopPrompt = Console.ReadLine();
                    if (loopPrompt.Equals("Y") ||
                        loopPrompt.Equals("N") ||
                        loopPrompt.Equals("y") ||
                        loopPrompt.Equals("n"))
                        break;
                    else
                        Console.Write("\nPlease type a suitable reply. ");
                } while (true);

                // End the program (break out of the while loop) if the user answers with a "N" or "n"
                if (loopPrompt.Equals("N") || loopPrompt.Equals("n"))
                    restart = false;
            } while (restart);

            // Print the results and wait for user input before closing the program
            Console.Write("Correctly answered problems: " + correctCount
                + "\nIncorrectly answered problems: " + incorrectCount
                + "\n\nPress any key to exit");
            Console.ReadKey();
        }
    }
}