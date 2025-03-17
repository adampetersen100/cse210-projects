    class EternalGoal : Goals
{
    public EternalGoal(string goalName, int score)
        : base(goalName, "Eternal", false, score) { }

    public override void CompleteGoal()
    {
        // Add points for completing the eternal goal
        if (!_isCompleted)
        {
            _isCompleted = true;  // Mark it as completed temporarily
            totalScore += _score;  // Add the score to the total

            Console.WriteLine($"{_goalName} completed! You gained {_score} points.");

            // Reset the goal, making it available to complete again
            _isCompleted = false;

            SaveTotalScore();  // Save the updated total score
            SaveGoals();  // Save the goals, keeping this one for future completions
        }
        else
        {
            Console.WriteLine("Goal already completed. You can complete it again.");
        }
    }
}

