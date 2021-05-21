using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class Validator
    {
        public static void ThrowIfNumberIsNotInRange(int minValue, int maxValue, int number, string exceptionMessage)
        {
            if (number < minValue || number > maxValue)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static void ThrowIfValueIsNotAllowed(HashSet<string> allowedValues, string value, string exceptionMessage)
        {
            if (!allowedValues.Contains(value))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
