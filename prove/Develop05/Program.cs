using System;

class Program
{
    static void Main(string[] args)
    {
        Goals.LoadGoals();  // Load saved goals at the start
        Goals.LoadTotalScore();  // Load the saved total score

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. Create Goal\n2. Complete Goal\n3. Display All Goals\n4. Display Total Score\n5. Redeem Points\n6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Goals.CreateGoal();  // Call to create a new goal
                    break;
                case "2":
                    Console.Write("Enter goal name to complete: ");
                    string goalName = Console.ReadLine();
                    Goals goalToComplete = Goals.GetAllGoals().Find(g => g.GoalName == goalName);
                    if (goalToComplete != null)
                        goalToComplete.CompleteGoal();  // Call to complete the goal
                    else
                        Console.WriteLine("Goal not found.");
                    break;
                case "3":
                    Goals.DisplayAllGoals();  // Display all goals
                    break;
                case "4":
                    Console.WriteLine($"Total Score: {Goals.GetTotalScore()}");  // Display total score
                    break;
                case "5":
                    Goals.RedeemPoints();  // Redeem points logic
                    break;
                case "6":
                    running = false;  // Exit the program
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
