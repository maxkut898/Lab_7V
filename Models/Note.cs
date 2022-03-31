using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab7.Models
{
    public class Note : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Note(string f, string gr1, string gr2, string gr3, string gr4, string gr5,string gr6, string gr7, bool ch)
        {
            Fio = f;
            Grade1 = gr1;
            Grade2 = gr2;
            Grade3 = gr3;
            Grade4 = gr4;
            Grade5 = gr5;
            Grade6 = gr6;
            Grade7 = gr7;
            Check = ch;
            ChangeAverage();
        }

        string fio;
        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }
        string[] grade=new string[9]; 
        public string Grade1
        {
            get { return grade[1]; }
            set {
                if (value == "0" || value == "1" || value == "2") grade[1] = value;
                else grade[1] = "#ERROR";
                ChangeAverage();
            }
        }
        public string Grade2
        {
            get { return grade[2]; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade[2] = value;
                else grade[2] = "#ERROR";
                ChangeAverage();
            }
        }
        public string Grade3
        {
            get { return grade[3]; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade[3] = value;
                else grade[3] = "#ERROR";
                ChangeAverage();
            }
        }
        public string Grade4
        {
            get { return grade[4]; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade[4] = value;
                else grade[4] = "#ERROR";
                ChangeAverage();
            }
        }
        public string Grade5
        {
            get { return grade[5]; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade[5] = value;
                else grade[5] = "#ERROR";
                ChangeAverage();
            }
        }
        public string Grade6
        {
            get { return grade[6]; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade[6] = value;
                else grade[6] = "#ERROR";
                ChangeAverage();
            }
        }
        public string Grade7
        {
            get { return grade[7]; }
            set
            {
                if (value == "0" || value == "1" || value == "2") grade[7] = value;
                else grade[7] = "#ERROR";
                ChangeAverage();
            }
        }


        bool check;
        public bool Check
        {
            get { return check; } 
            set { check = value; NotifyPropertyChanged(); }
        }

        string average;
        public string Average
        {
            get { return average; }
            set {  average = value; NotifyPropertyChanged(); }
        }

        ISolidColorBrush brush;
        public ISolidColorBrush MyBrush
        {
            get { return brush; }
            set
            {
                brush = value;
                NotifyPropertyChanged();
            }
        }

        
        private void ChangeAverage()
        {
            double gradeint;
            double sum=0;
            for(int i=1;i<8;i++)
            {
                if (double.TryParse(grade[i], out gradeint)) sum += gradeint;
                else { Average = "#ERROR"; MyBrush = Brushes.White; return; }
            }
            sum /= 7;
            Average = sum.ToString("N2");
            if (sum < 1) MyBrush = Brushes.Red;
            if (sum >= 1 && sum < 1.5) MyBrush = Brushes.Yellow;
            if (sum >= 1.5 && sum <= 2) MyBrush = Brushes.Green;

        }


        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public string Capital { get; private set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
