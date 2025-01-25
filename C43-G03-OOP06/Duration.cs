using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_OOP06
{
    public class Duration
    {
        public Duration(int hours, int minutes, int seconds)
        {
            if (seconds < 0) seconds = 0;
            if (minutes < 0) minutes = 0;
            if (hours < 0) hours = 0;

            if (seconds >= 60)
            {
                minutes += seconds / 60;
                seconds %= 60;
            }

            if  (minutes >= 60)
            {
                hours += minutes / 60;
                minutes %= 60;
            }

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

        public static Duration operator +(Duration dur1, Duration dur2)
        {
            int hours = dur1.Hours + dur2.Hours;
            int minutes = dur1.Minutes + dur2.Minutes;
            int seconds = dur1.Seconds + dur2.Seconds;

            if (seconds >= 60)
            {
                minutes++;
                seconds -= 60;
            }
            if (minutes >= 60)
            {
                hours++;
                minutes -= 60;
            }
            return new Duration(hours, minutes, seconds);
        }

        public static Duration operator +(Duration duration, int seconds)
        {
            return duration + new Duration(seconds);
        }

        public static Duration operator +(int seconds, Duration duration)
        {
            return new Duration(seconds) + duration;
        }

        public static Duration operator ++(Duration duration)
        {
            return new Duration(duration.Hours, duration.Minutes + 1, duration.Seconds);
        }

        public static Duration operator --(Duration duration)
        {
            return new Duration(duration.Hours, duration.Minutes - 1, duration.Seconds);
        }

        public static Duration operator -(Duration dur1, Duration dur2)
        {
            int hours = dur1.Hours - dur2.Hours;
            int minutes = dur1.Minutes - dur2.Minutes;
            int seconds = dur1.Seconds - dur2.Seconds;

            if (seconds < 0)
            {
                minutes--;
                seconds += 60;
            }
            if (minutes < 0)
            {
                hours--;
                minutes += 60;
            }

            return new Duration(hours, minutes, seconds);
        }

        public static bool operator >(Duration dur1, Duration dur2)
        {
            if (dur1.Hours > dur2.Hours)
                return true;

            if (dur1.Hours == dur2.Hours && dur1.Minutes > dur2.Minutes)
                return true;

            if (dur1.Hours == dur2.Hours &&
                dur1.Minutes == dur2.Minutes &&
                dur1.Seconds > dur2.Seconds)
                return true;

            return false;
        }

        public static bool operator <(Duration dur1, Duration dur2)
        {
            if (dur1.Hours < dur2.Hours)
                return true;

            if (dur1.Hours == dur2.Hours && dur1.Minutes < dur2.Minutes)
                return true;

            if (dur1.Hours == dur2.Hours &&
                dur1.Minutes == dur2.Minutes &&
                dur1.Seconds < dur2.Seconds)
                return true;

            return false;
        }

        public static bool operator >=(Duration dur1, Duration dur2)
        {
            return dur1 > dur2 || dur1 == dur2;
        }

        public static bool operator <=(Duration dur1, Duration dur2)
        {
            return dur1 < dur2 || dur1 == dur2;
        }

        public static bool operator true(Duration duration)
        {
            return duration.Hours > 0 || duration.Minutes > 0 || duration.Seconds > 0;
        }

        public static bool operator false(Duration duration)
        {
            return duration.Hours == 0 && duration.Minutes == 0 && duration.Seconds == 0;
        }

        public static implicit operator DateTime(Duration duration)
        {
            return new DateTime(1, 1, 1, duration.Hours, duration.Minutes, duration.Seconds);
        }
    }
}
