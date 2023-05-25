using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MinValue { get; }
        public float MaxValue { get; }
        public float Value { get; }

        public ValueOutOfRangeException(float i_Value, float i_MinValue, float i_MaxValue) : base($"The value {i_Value} is out of range. Valid range: {i_MinValue} to {i_MaxValue}")
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
            Value = i_Value;
        }

        public ValueOutOfRangeException(string i_Message)
            : base(i_Message)
        {
        }

        public ValueOutOfRangeException(string i_Message, Exception i_InnerException)
            : base(i_Message, i_InnerException)
        {
        }
    }
}