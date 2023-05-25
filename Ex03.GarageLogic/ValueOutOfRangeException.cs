using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MinValue { get; }
        public float MaxValue { get; }
        public float Value { get; }

        public ValueOutOfRangeException(float value, float minValue, float maxValue) : base($"The value {value} is out of range. Valid range: {minValue} to {maxValue}")
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Value = value;
        }

        public ValueOutOfRangeException(string message)
            : base(message)
        {
        }

        public ValueOutOfRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}