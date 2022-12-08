using System;
using System.ComponentModel.DataAnnotations;

namespace EdFi.Ods.Common.Attributes
{
    public class MinMaxAttribute : ValidationAttribute
    {
        /// <summary>
        ///     Gets the min value for the range
        /// </summary>
        public object MinValue { get; private set; }

        /// <summary>
        ///     Gets the max value for the range
        /// </summary>
        public object MaxValue { get; private set; }

        /// <summary>
        ///     Gets the type of the <see cref="MinValue" /> and <see cref="MaxValue" /> values (e.g. int or Decimal)
        ///     type)
        /// </summary>
        public Type OperandType { get; private set; }

        public MinMaxAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            OperandType = typeof(int);
        }

        public MinMaxAttribute(decimal minValue, decimal maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            OperandType = typeof(decimal);
        }

        public override bool IsValid(object value)
        {
            if (value == null || (value as string)?.Length == 0)
            {
                return true;
            }

            if (OperandType == typeof(int))
            {
                int convertedValue = (int) value;
                return convertedValue >= (int)MinValue && convertedValue <= (int)MaxValue;
            }

            if (OperandType == typeof(decimal))
            {
                decimal convertedValue = (decimal)value;
                return convertedValue >= (decimal)MinValue && convertedValue <= (decimal)MaxValue;
            }

            return false;
        }
    }
}
