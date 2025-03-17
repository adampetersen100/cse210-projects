using System;

class ChecklistGoal : Goals
{
    private int targetCount;
    private int bonus;
    private int completedCount = 0;  // Track the number of completions

    public ChecklistGoal(string goalName, int score, int targetCount, int bonus)
        : base(goalName, "Checklist", false, score)
    {
        this.targetCount = targetCount;
        this.bonus = bonus;
    }

    public override void CompleteGoal()
    {
        if (!_isCompleted)
        {
            completedCount++;  // Increment completed count when goal is completed

            // Add base score every time the goal is completed
            totalScore += _score;

            if (completedCount >= targetCount)
            {
                totalScore += bonus;  // Add bonus points when target is reached
                Console.WriteLine($"{_goalName} completed! You gained {_score + bonus} points (including bonus). Nice work!");
            }
            else
            {
                Console.WriteLine($"{_goalName} completed! You gained {_score} points. Keep going to earn the bonus!");
            }

            _isCompleted = true;  // Mark the goal as completed
            SaveTotalScore();  // Save updated score
            SaveGoals();  // Save all goals
        }
        else
        {
            Console.WriteLine("Goal already completed.");
        }
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();  // Display basic goal information
        Console.WriteLine($"Target Count: {targetCount}, Bonus: {bonus}");
    }
}
