using System;

namespace Parsec.Attributes
{
    public class FixedLengthStringAttribute : Attribute
    {
        public int Length { get; set; }
        
        public FixedLengthStringAttribute(int length)
        {
            Length = length;
        }
    }
}
