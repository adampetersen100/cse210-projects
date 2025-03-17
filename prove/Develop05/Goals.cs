using System;
using System.Collections.Generic;
using System.IO;

class Goals
{
    protected string _goalName;
    protected string _type;
    protected bool _isCompleted;
    protected int _score;
    protected static List<Goals> goals = new List<Goals>();
    protected static int totalScore;

    public string GoalName => _goalName;

    static Goals()
    {
        LoadGoals();
        totalScore = LoadTotalScore(); 
    }

    public Goals(string goalName, string type, bool isCompleted, int score)
    {
        _goalName = goalName;
        _type = type;
        _isCompleted = isCompleted;
        _score = score;
    }

    public static List<Goals> GetAllGoals()
    {
        return goals;
    }

    public virtual void CompleteGoal()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;  // Mark the goal as completed
            totalScore += _score;  // Add points to the total score

            Console.WriteLine($"{_goalName} completed! You gained {_score} points.");

            SaveTotalScore();  // Save the updated total score
            SaveGoals();  // Save updated goals
        }
        else
        {
            Console.WriteLine("Goal already completed.");
        }
    }



    public static int GetTotalScore()
    {
        return totalScore;
    }

    public static void SaveTotalScore()
    {
        File.WriteAllText("score.txt", totalScore.ToString());  // Save the updated score
    }


    public static int LoadTotalScore()
    {
        string scoreFile = "score.txt";

        if (!File.Exists(scoreFile))
        {
            File.WriteAllText(scoreFile, "0");
            return 0;
        }

        string content = File.ReadAllText(scoreFile).Trim();

        if (string.IsNullOrEmpty(content))
        {
            File.WriteAllText(scoreFile, "0");
            return 0;
        }

        if (int.TryParse(content, out int loadedScore))
        {
            return loadedScore;
        }

        Console.WriteLine("Invalid score data found! Resetting score to 0.");
        File.WriteAllText(scoreFile, "0");
        return 0;
    }

    public static void CreateGoal()
    {
        Console.Write("Enter goal name: ");
        string goalName = Console.ReadLine();

        Console.Write("Enter goal type (Common, Eternal, Checklist): ");
        string type = Console.ReadLine().ToLower();

        Console.Write("Enter score value: ");
        int score = Convert.ToInt32(Console.ReadLine());

        if (type == "common")
            goals.Add(new CommonGoal(goalName, score));
        else if (type == "eternal")
            goals.Add(new EternalGoal(goalName, score));
        else if (type == "checklist")
        {
            Console.Write("Enter target count: ");
            int targetCount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter bonus score for completion: ");
            int bonus = Convert.ToInt32(Console.ReadLine());

            goals.Add(new ChecklistGoal(goalName, score, targetCount, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type!");
        }

        SaveGoals();
    }

    public static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goals goal in goals)
            {
                writer.WriteLine($"{goal._goalName}|{goal._type}|{goal._isCompleted}|{goal._score}");
            }
        }
        SaveTotalScore();
    }

    public static void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
            return;

        goals.Clear();  // Clear existing goals before loading new ones

        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4)  
                {
                    string name = parts[0];
                    string type = parts[1];
                    bool isCompleted = bool.Parse(parts[2]);
                    int score = int.Parse(parts[3]);

                    if (type == "Common")
                        goals.Add(new CommonGoal(name, score));
                    else if (type == "Eternal")
                        goals.Add(new EternalGoal(name, score));
                    else if (type == "Checklist")
                    {
                        if (parts.Length >= 6)
                        {
                            int targetCount = int.Parse(parts[4]);
                            int bonus = int.Parse(parts[5]);
                            goals.Add(new ChecklistGoal(name, score, targetCount, bonus));
                        }
                    }
                }
            }
        }

        totalScore = LoadTotalScore();  // Load saved total score
    }

    public static void RedeemPoints()
    {
        Console.Write("Enter reward description: ");
        string reward = Console.ReadLine();

        Console.Write("Enter point cost: ");
        int cost = Convert.ToInt32(Console.ReadLine());

        if (cost > totalScore)
        {
            Console.WriteLine("Not enough points to redeem this reward.");
            return;
        }

        totalScore -= cost;
        SaveTotalScore();

        Console.WriteLine($"Reward '{reward}' redeemed! {cost} points deducted.");
        Console.WriteLine($"Remaining points: {totalScore}");
    }

    public static void DisplayAllGoals()
    {
        foreach (Goals goal in goals)
        {
            Console.WriteLine($"Goal: {goal._goalName}, Type: {goal._type}, Completed: {goal._isCompleted}, Score: {goal._score}");
        }
    }

    public virtual void DisplayGoal()
    {
        Console.WriteLine($"Goal: {_goalName}, Type: {_type}, Completed: {_isCompleted}, Score: {_score}");
    }

    public static void DeleteGoal()
    {
        Console.WriteLine("Enter goal name to delete: ");
        string goalName = Console.ReadLine();

        for (int i = 0; i < goals.Count; i++)
        {
            if (goals[i]._goalName == goalName)
            {
                goals.RemoveAt(i);
                Console.WriteLine("Goal deleted!");
                SaveGoals();
                return;
            }
        }
        Console.WriteLine("Goal not found.");
    }
}