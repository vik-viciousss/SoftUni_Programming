using System;
using System.Collections.Generic;
using System.Text;

namespace Date_Modifier_Problem
{
    public static class DateModifier
    {
        public static int GetDiffBetweenDatesInDays(string dateOneStr, string dateTwoStr)
        {
            DateTime dateOne = DateTime.Parse(dateOneStr);
            DateTime dateTwo = DateTime.Parse(dateTwoStr);

            TimeSpan diff = dateOne - dateTwo;
            return diff.Days;
        }
    }
}
