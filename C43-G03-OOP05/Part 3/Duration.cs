using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_OOP05
{
    public class Duration
    {
        public Duration(int hours, int minutes, int seconds)
        {
            SetDurationParts(hours, minutes, seconds);
        }

        public Duration(int seconds)
        {
            int minutes = seconds / 60;
            int hours = minutes / 60;

            seconds = seconds % 60 == 0 ? 0 : seconds - minutes * 60;
            minutes = minutes % 60 == 0 ? 0 : minutes - hours * 60;

            SetDurationParts(hours, minutes, seconds);
        }

        private void SetDurationParts(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int Hours { get; private set; }

        public int Minutes { get; private set; }

        public int Seconds { get; private set; }

        public override bool Equals(object? obj)
        {
            if (obj is null or not Duration)
                return false;

            Duration secondObject = (Duration)obj;

            return Hours == secondObject.Hours
                && Minutes == secondObject.Minutes
                && Seconds == secondObject.Seconds;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds, base.GetHashCode());
        }

        public override string? ToString()
        {
            string hoursPart = string.Empty;
            string minutesPart = string.Empty;

            if (Hours > 0)
                hoursPart = $"Hours: {Hours}, ";

            if (Minutes > 0 || hoursPart != string.Empty)
                minutesPart = $"Minutes: {Minutes}, ";

            return $"{hoursPart}{minutesPart}Seconds: {Seconds}";
        }
    }
}
