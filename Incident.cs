using System;

namespace IncidentApp
{
    public class Incident
    {
        public string Title { get; private set; }
        public string Severity { get; private set; }
        public DateTime DateReported { get; private set; }

        public Incident(string title, string severity, DateTime dateReported)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");

            if (!IsValidSeverity(severity))
                throw new ArgumentException("Severity must be Low, Medium or High.");

            if (dateReported > DateTime.Now)
                throw new ArgumentException("Reported date cannot be in the future.");

            Title = title;
            Severity = severity;
            DateReported = dateReported;
        }

        public int CalculateUrgency()
        {
            int baseScore = 0;

            switch (Severity)
            {
                case "Low":
                    baseScore = 1;
                    break;
                case "Medium":
                    baseScore = 2;
                    break;
                case "High":
                    baseScore = 3;
                    break;
            }

            var daysOld = (DateTime.Now - DateReported).Days;

            // Urgency goes up the older the incident gets
            return baseScore + (daysOld / 2);
        }

        private bool IsValidSeverity(string severity)
        {
            return severity == "Low" || severity == "Medium" || severity == "High";
        }

        public override string ToString()
        {
            return $"{Title} ({Severity}) - Reported {DateReported:d}";
        }
    }
}