using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMathOperations {
    class Program {
        public static int correctCount, incorrectCount, currQuestion;

        static void Main(string[] args) {
            // Keep track of the user's correct and incorrect answers

            // Start the program loop; Repeat until the user wants to stop generating problems
            bool restart = true;

            // Generate the math problems to ask
            String problem1, problem2, problem3, problem4;

            // Create 2 pairs of number slots (4 each) to use for generating the problems
            double[] op1 = new double[4], op2 = new double[4];

            // Randomly generate the numbers involved in the problems, within the operator arrays
            Random numGen = new Random();

            do {
                // Reset/Initialize which question we're currently answering
                currQuestion = 1;

                for (var i = 0; i < 4; i++) {
                    op1[i] = numGen.Next(1, 11);
                    op2[i] = numGen.Next(1, 11);
                }

                // Store the entire equation as a string, so we can ask later
                problem1 = (op1[0] + " + " + op2[0]);
                problem2 = (op1[1] + " - " + op2[1]);
                problem3 = (op1[2] + " * " + op2[2]);
                problem4 = (op1[3] + " / " + op2[3]);

                Console.WriteLine("Solve the 4 math equations:");

                AskQuestion(problem1, op1[0], op2[0]); // Prompt the user about Math Problem #1
                AskQuestion(problem2, op1[1], op2[1]); // Prompt the user about Math Problem #2
                AskQuestion(problem3, op1[2], op2[2]); // Prompt the user about Math Problem #3
                AskQuestion(problem4, op1[3], op2[3]); // Prompt the user about Math Problem #4

                // Linebreak for tidiness
                Console.WriteLine();

                // Keep asking the user if they want to solve more problems until they give a proper answer
                String loopPrompt;
                do {
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

        static void AskQuestion (String problem, double op1, double op2) {
            // Prompt the user about Math Problem
            Console.Write("\n" + problem + " = ");

            // Ask for and validate the user's response
            double userInput;
            while (!double.TryParse(Console.ReadLine(), out userInput))
                Console.Write("Invalid response. Please enter a valid numerical value: ");

            bool isCorrect = false;

            // Calculate the answer internally depending on the question we're currently answering; Set correct flag if the user's guess is correct
            switch (currQuestion) {
                case 1:
                    if (userInput == op1 + op2)
                        isCorrect = true;
                    break;
                case 2:
                    if (userInput == op1 - op2)
                        isCorrect = true;
                    break;
                case 3:
                    if (userInput == op1 * op2)
                        isCorrect = true;
                    break;
                case 4:
                    if (userInput == op1 / op2)
                        isCorrect = true;
                    break;
                default:
                    break;
            }
            currQuestion++;

            // Print correct/incorrect message
            if (isCorrect) {
                Console.WriteLine("Correct!");
                correctCount++;
            } else {
                Console.WriteLine("Incorrect...");
                incorrectCount++;
            }
        }
    }
}