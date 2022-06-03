using System;

namespace Parsec.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FixedLengthStringAttribute : Attribute
    {
        public int Length { get; set; }
        
        public FixedLengthStringAttribute(int length)
        {
            Length = length;
        }
    }
}
