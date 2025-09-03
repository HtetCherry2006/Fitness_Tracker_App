using System;

namespace Fitness_Tracker
{
    public class Add_Activity
    {
        public string ActivityType { get; set; }
        public string MeritType { get; set; }
        public float Weight { get; set; } 
        public int TimeSpent { get; set; } 

        public Add_Activity(string activityType, string meritType, float weight, int timeSpent)
        {
            ActivityType = activityType;
            MeritType = meritType;
            Weight = weight;
            TimeSpent = timeSpent;
        }

        public float CalculateCalories()
        {
            float met = GetMET();
            return (met * Weight * TimeSpent) / 60f; 
        }

        private float GetMET()
        {
            
            if (ActivityType == "Walking")
            {
                switch (MeritType)
                {
                    case "Slow": return 2.5f;
                    case "Normal": return 3.5f;
                    case "Fast": return 4.5f;
                }
            }
            else if (ActivityType == "Running")
            {
                switch (MeritType)
                {
                    case "Jogging": return 6.0f;
                    case "Medium": return 7.5f;
                    case "Sprint": return 9.0f;
                }
            }
            else if (ActivityType == "Cycling")
            {
                switch (MeritType)
                {
                    case "Leisure": return 3.5f;
                    case "Normal": return 5.0f;
                    case "Intense": return 7.0f;
                }
            }
            else if (ActivityType == "Swimming")
            {
                switch (MeritType)
                {
                    case "Leisure": return 3.0f;
                    case "Moderate": return 5.5f;
                    case "Vigorous": return 7.0f;
                }
            }
            else if (ActivityType == "Weightlifting")
            {
                switch (MeritType)
                {
                    case "Light": return 3.0f;
                    case "Moderate": return 5.0f;
                    case "Vigorous": return 6.0f;
                }
            }
            else if (ActivityType == "Yoga")
            {
                switch (MeritType)
                {
                    case "Gentle": return 2.0f;
                    case "Power": return 4.0f;
                }
            }
           
            return 3.0f;
        }
    }
}