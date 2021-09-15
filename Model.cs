using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Test
{
    //class CsvReader
    //{
    //    private string fileName = "todo.txt";

    //    public List<Entry> ReadAllEntries
    //    {
    //        get
    //        {
    //            List<Entry> entries = new List<Entry>();

    //            using (StreamReader sr = new StreamReader(fileName))
    //            {
    //                string csvLine;
    //                while ((csvLine = sr.ReadLine()) != null)
    //                {
    //                    entries.Add(ReadEntry(csvLine));
    //                }
    //            }

    //        }
    //    }

    //    public Entry ReadEntry(string csvLine)
    //    {
    //        string[] parts = csvLine.Split(',');

    //        bool ischecked = bool.Parse(parts[0]);
    //        string project = parts[1];
    //        string task = parts[2];

    //        return new Entry {IsChecked=ischecked, Project=project,Task=task};
    //    }
    //}
}
