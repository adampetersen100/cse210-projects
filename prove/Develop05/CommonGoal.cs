class CommonGoal : Goals
{
    public CommonGoal(string goalName, int score)
        : base(goalName, "Common", false, score) { }

    public override void CompleteGoal()
    {
        // Mark as completed and update the score
        if (!_isCompleted)
        {
            _isCompleted = true;
            totalScore += _score;  

            Console.WriteLine($"{_goalName} completed! You gained {_score} points.");

            // Remove the goal from the list
            Goals.GetAllGoals().Remove(this);

            SaveTotalScore(); 
            SaveGoals();  // Save the updated goals list without this goal
        }
        else
        {
            Console.WriteLine("Goal already completed.");
        }
    }
}
