using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RangeFinder.Classes
{
    class CsvReader
    {
        public CsvReader(string strPath, string intPath)
        {
            StrPath = strPath;
            IntPath = intPath;
            StrCsvList = LoadStrCsv(StrPath);
            IntCsvList = LoadIntCsv(IntPath);
        }

        public List<long> IntCsvList { get; set; }

        public string IntPath { get; set; }

        public string StrPath { get; set; }

        public Dictionary<string,long> StrCsvList { get; set; }


        public Dictionary<string, long> LoadStrCsv(string path)
        {   List<string> jList = new List<string>();
            Dictionary<string,long> dlist = new Dictionary<string, long>();          
            var reader = new StreamReader(File.OpenRead(path));
            List<string> searchList = new List<string>();

            string headLine = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);
            }

            foreach (var user in searchList)
            {
                string[] jSplit = user.Split(',');
                string pattern = Regex.Escape("+44");
                
                if (Regex.IsMatch(jSplit[1], pattern))
                {
                    var index = Regex.Match(jSplit[1], pattern).Index;
                    index = index + 3;
                    jSplit[1] = jSplit[1].Substring(index);
                    dlist.Add(jSplit[0], Convert.ToInt64(jSplit[1]));
                }
                else { dlist.Add(jSplit[0], Convert.ToInt64(jSplit[1]));}
            }
            return dlist;
        }
        public List<long> LoadIntCsv(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));
            List<long> searchList = new List<long>();

            while (!reader.EndOfStream)
            {
                
                var line = reader.ReadLine();
               long intLine = Convert.ToInt64(line);
                searchList.Add(intLine);
            }

            return searchList;
        }
    }
}
