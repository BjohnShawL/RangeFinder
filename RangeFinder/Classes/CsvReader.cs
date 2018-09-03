using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeFinder.Classes
{
    class CsvReader
    {
        public CsvReader(string strPath, string intPath)
        {
            this.StrPath = strPath;
            this.IntPath = intPath;
            this.StrCsvList = LoadStrCsv(this.StrPath);
            this.IntCsvList = LoadIntCsv(this.IntPath);
        }

        public List<int> IntCsvList { get; set; }

        public string IntPath { get; set; }

        public string StrPath { get; set; }

        public List<string> StrCsvList { get; set; }


        public List<string> LoadStrCsv(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));
            List<string> searchList = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);
            }

            return searchList;
        } public List<int> LoadIntCsv(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));
            List<int> searchList = new List<int>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
               int intLine = Convert.ToInt32(line);
                searchList.Add(intLine);
            }

            return searchList;
        }
    }
}
