using System;

namespace HM15.Task1.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomCreditCardAttribute : Attribute
    {
        public bool IsValid(string value)
        {
            if (value == null)
            {
                Console.WriteLine("Credit card nubmer must be non empty string.");
                return false;
            }

            value = value.Replace("-", string.Empty);
            value = value.Replace(" ", string.Empty);

            return LuhnAlgorithmCheck(value);
        }

        private static bool LuhnAlgorithmCheck(string value)
        {
            var checksum = 0;
            var evenDigit = false;

            for (var i = value.Length - 1; i >= 0; i--)
            {
                var digit = value[i];
                if (digit < '0' || digit > '9')
                {
                    Console.WriteLine("Credit card nubmer must contain digits.");
                    return false;
                }

                var digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;

                while (digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }

            return (checksum % 10) == 0;
        }
    }
}
