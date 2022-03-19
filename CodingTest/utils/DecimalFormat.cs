using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace CodingTest.utils
{
    interface Format
    {
    }
    public abstract class NumberFormat : Format
    {
        public abstract string format(double number);
        public abstract StringBuilder format(double number, StringBuilder toAppendTo);
        public abstract string format(long number);
        public abstract StringBuilder format(long number, StringBuilder toAppendTo);
        public abstract double parseDouble(string source);
        public abstract long parseLong(string source);
    }

    public class DecimalFormat : NumberFormat
    {
        private string _format;

        public DecimalFormat()
        {
            _format = "##########0";
        }

        public DecimalFormat(string pattern)
            : this()
        {
            _format = pattern;
        }

        public DecimalFormat(DecimalFormat Other)
            : this(Other._format)
        {
        }

        public override string format(double number)
        {
            return number.ToString(_format);
            //return string.Format(_format, number);
        }

        public override StringBuilder format(double number, StringBuilder toAppendTo)
        {
            string s = format(number);
            toAppendTo.Append(s);
            return toAppendTo;
        }

        public override string format(long number)
        {
            return string.Format(_format, number);
        }

        public override StringBuilder format(long number, StringBuilder toAppendTo)
        {
            string s = format(number);
            toAppendTo.Append(s);
            return toAppendTo;
        }

        public override double parseDouble(string source)
        {
            return Double.Parse(source);
        }

        public override long parseLong(string source)
        {
            return long.Parse(source);
        }

        public int parseInt(string source)
        {
            return (int)parseLong(source);
        }
    }
}
