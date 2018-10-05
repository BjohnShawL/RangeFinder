using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeFinder.Classes
{
    class Range
    {
        public Range(long rangeNumber)
        {
            this.RangeNumber = Convert.ToInt32(rangeNumber.ToString().Substring(4));
            this.Length = Convert.ToInt32(rangeNumber.ToString().Length);
            this.Prefix = rangeNumber.ToString().Substring(0, 4);
            this.RangeList = RangeBuilder(RangeNumber, Length, Prefix);
        }

        public string Prefix { get; set; }

        public int Length { get; set; }

        public int RangeNumber { get; set; }

        public List<long> RangeList { get; set; }

        public List<long> RangeBuilder(int num, int length, string prefix)
        {
            List<int> rangeList = new List<int>();
            List<long> fullNumberList =new List<long>();
            long fullNumber;
            int upperBound;

            //switch on the initial range length, before sub-stringing down to the short form

            switch (length)
            {   
                case 8:
                    //create the list of 6 digit numbers in the current range
                    
                    num = num * 100;
                    upperBound = num + 99;
                    while (num <= upperBound)
                    {
                        rangeList.Add(num);
                        num++;
                    }

                    // re-attach the substring
                    foreach (var x in rangeList)
                    {
                        var y = x.ToString();
                        var z = prefix + y;
                        fullNumber = Convert.ToInt64(z);
                        fullNumberList.Add(fullNumber);
                    }

                    return fullNumberList;
                case 9:
                    //create the list of 6 digit numbers in the current range
                    num = num * 10;
                    upperBound = num + 9;
                    while (num <= upperBound)
                    {
                        rangeList.Add(num);
                        num++;
                    }

                    foreach (var x in rangeList)
                    {
                        var y = x.ToString();
                        var z = prefix + y;
                        fullNumber = Convert.ToInt64(z);
                        fullNumberList.Add(fullNumber);
                    }

                    return fullNumberList;
                case 10:
                    //anything with a ten digit length is already six digits - just add it to the range
                    
                        rangeList.Add(num);
                    
                    foreach (var x in rangeList)
                    {
                        var y = x.ToString();
                        var z = prefix + y;
                        fullNumber = Convert.ToInt64(z);
                        fullNumberList.Add(fullNumber);
                    }

                    return fullNumberList;
            }

            return fullNumberList;
        }

    }
}
