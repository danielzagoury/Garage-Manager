using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }
        public ValueOutOfRangeException(float minValue, float maxValue)
            : base($"Value is out of range. Allowed range is [{minValue}, {maxValue}].")
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}
