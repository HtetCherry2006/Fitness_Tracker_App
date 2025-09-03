using System;

public class SetGoal
{
    public int GoalID { get; set; }
    public string Username { get; set; }
    public double TargetWeight { get; set; }
    public double CurrentWeight { get; set; }
    public int TargetCalories { get; set; }
    public DateTime DateSet { get; set; }
    public SetGoal(string username, double targetWeight, double currentWeight, int targetCalories) { Username = username; TargetWeight = targetWeight; CurrentWeight = currentWeight; TargetCalories = targetCalories; DateSet = DateTime.Now; }
}
