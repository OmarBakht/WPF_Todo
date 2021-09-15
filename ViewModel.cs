using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.IO;

namespace WPF_Test
{
    class Entry : INotifyPropertyChanged
    {
        static string[] EntryToString(ObservableCollection<Entry> entries)
        {
            string[] strEntries = new string[entries.Count];
            string[] parts = new string[3];
            for (int i = 0; i < entries.Count; i++)
            {
                parts[0] = entries[i].IsChecked.ToString();
                parts[1] = entries[i].Project;
                parts[2] = entries[i].Task;

                strEntries[i] = parts[0] + "," + parts[1] + "," + parts[2];
            }

            return strEntries;
        }
        
        private bool _ischecked;
        public bool IsChecked
        {
            get { return _ischecked; }
            set
            {
                _ischecked = value;
                RaisePropertyChanged();
            }
        }

        private string _project;
        public string Project
        {
            get { return _project; }
            set
            {
                _project = value;
                RaisePropertyChanged();
            }
        }

        private string _task;
        public string Task
        {
            get { return _task; }
            set
            {
                _task = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(
            [CallerMemberName] String caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public static Entry ReadEntry(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            bool ischecked = bool.Parse(parts[0]);
            string project = parts[1];
            string task = parts[2];

            return new Entry { IsChecked = ischecked, Project = project, Task = task };
        }

        public static ObservableCollection<Entry> GetEntries()
        {
            var entries = new ObservableCollection<Entry>();

            using (StreamReader sr = new StreamReader("todo.txt"))
            {
                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    entries.Add(ReadEntry(csvLine));
                }
            }

            File.WriteAllLines("todo.txt", EntryToString(entries));
            return entries;

            //entries.Add(new Entry() { IsChecked = true, Project = "Quick Tasks", Task = "do the dishes" });
            //entries.Add(new Entry() { IsChecked = true, Project = "Quick Tasks", Task = "work" });
            //entries.Add(new Entry() { IsChecked = false, Project = "Quick Tasks", Task = "eat" });
            //entries.Add(new Entry() { IsChecked = false, Project = "Quick Tasks", Task = "gym" });
            //entries.Add(new Entry() { IsChecked = false, Project = "Quick Tasks", Task = "sleep" });
            //return entries;
        }

    }
}
