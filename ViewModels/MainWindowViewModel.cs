using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ReactiveUI;
using System.Reactive;
using Lab7.Models;
using Avalonia.Media;

namespace Lab7.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Notes = BuildAllNotes();
            foreach (var note in Notes)
                note.PropertyChanged += ContentCollectionChanged;

            ChangeAverage();


        }
        string[] control = new string[9];
        public string Control1
        {
            get { return control[1]; }
            set { this.RaiseAndSetIfChanged(ref control[1], value); }
        }
        public string Control2
        {
            get { return control[2]; }
            set { this.RaiseAndSetIfChanged(ref control[2], value); }
        }
        public string Control3
        {
            get { return control[3]; }
            set { this.RaiseAndSetIfChanged(ref control[3], value); }
        }
        public string Control4
        {
            get { return control[4]; }
            set { this.RaiseAndSetIfChanged(ref control[4], value); }
        }
        public string Control5
        {
            get { return control[5]; }
            set { this.RaiseAndSetIfChanged(ref control[5], value); }
        }
        public string Control6
        {
            get { return control[6]; }
            set { this.RaiseAndSetIfChanged(ref control[6], value); }
        }
        public string Control7
        {
            get { return control[7]; }
            set { this.RaiseAndSetIfChanged(ref control[7], value); }
        }
        public string Control8
        {
            get { return control[8]; }
            set { this.RaiseAndSetIfChanged(ref control[8], value); }
        }

        public void ChangeAverage()
        {
            double[] sum = new double[9];
            for (int i = 1; i < sum.Length; i++) sum[i] = 0;
            bool[] er = new bool[9];
            for (int i = 1; i < er.Length; i++) er[i] = false;
            string[] con = new string[8];
            ISolidColorBrush[] col = new ISolidColorBrush[8];
            double count = 0;
            double gradeint;
            foreach (var note in Notes)
            {
                count++;
                if (double.TryParse(note.Grade1, out gradeint)) sum[1] += gradeint;
                else { er[1] = true; Control1 = "#ERROR"; Color1 = Brushes.White; er[8] = true; }
                if (double.TryParse(note.Grade2, out gradeint)) sum[2] += gradeint;
                else { er[2] = true; Control2 = "#ERROR"; Color2 = Brushes.White; er[8] = true; }
                if (double.TryParse(note.Grade3, out gradeint)) sum[3] += gradeint;
                else { er[3] = true; Control3 = "#ERROR"; Color3 = Brushes.White; er[8] = true; }
                if (double.TryParse(note.Grade4, out gradeint)) sum[4] += gradeint;
                else { er[4] = true; Control4 = "#ERROR"; Color4 = Brushes.White; er[8] = true; }
                if (double.TryParse(note.Grade5, out gradeint)) sum[5] += gradeint;
                else { er[5] = true; Control5 = "#ERROR"; Color5 = Brushes.White; er[8] = true; }
                if (double.TryParse(note.Grade6, out gradeint)) sum[6] += gradeint;
                else { er[6] = true; Control6 = "#ERROR"; Color6 = Brushes.White; er[8] = true; }
                if (double.TryParse(note.Grade7, out gradeint)) sum[7] += gradeint;
                else { er[7] = true; Control7 = "#ERROR"; Color7 = Brushes.White; er[8] = true; }
            }
            for (int i = 1; i < 8; i++)
            {
                if (!er[i])
                {
                    con[i] = (sum[i] / count).ToString("N2");
                    if (sum[i] / count < 1) col[i] = Brushes.Red;
                    else if (sum[i] / count < 1.5) col[i] = Brushes.Yellow;
                    else col[i] = Brushes.Green;
                }
            }
            if (!er[1]) { Control1 = con[1]; Color1 = col[1]; }
            if (!er[2]) { Control2 = con[2]; Color2 = col[2]; }
            if (!er[3]) { Control3 = con[3]; Color3 = col[3]; }
            if (!er[4]) { Control4 = con[4]; Color4 = col[4]; }
            if (!er[5]) { Control5 = con[5]; Color5 = col[5]; }
            if (!er[6]) { Control6 = con[6]; Color6 = col[6]; }
            if (!er[7]) { Control7 = con[7]; Color7 = col[7]; }
            if (!er[8])
            {
                for (int i = 1; i < 8; i++)
                {
                    sum[8] += sum[i];
                }
                Control8 = (sum[8] / (7 * count)).ToString("N2");
                if ((sum[8] / (7 * count)) < 1) Color8 = Brushes.Red;
                else if (sum[8] / (7 * count) < 1.5) Color8 = Brushes.Yellow;
                else Color8 = Brushes.Green;
            }
            else { Control8 = "#ERROR"; Color8 = Brushes.White; }

        }

        ObservableCollection<Note> notes;
        public ObservableCollection<Note> Notes
        {
            get
            {
                return notes;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref notes, value);
                ChangeAverage();
            }
        }


        public void ContentCollectionChanged(object? sender, PropertyChangedEventArgs e)
        {
            ChangeAverage();
        }

        private ObservableCollection<Note> BuildAllNotes()
        {
            return new ObservableCollection<Note>
            {
                new Note("Кутышкин Максим Игоревич","0","1","2","1","2","1","2",false),
                new Note("Могутова Софья Олеговна","2","2","2","2","1","2","2",false),
                new Note("Гончаров Александр Романович","2","0","1","2","2","2","1",false),
                new Note("Костин Андрей Викторович","1","2","1","2","2","1","1",false),
            };
        }
        ISolidColorBrush[] color = new ISolidColorBrush[9];
        public ISolidColorBrush Color1
        {
            get { return color[1]; }
            set { this.RaiseAndSetIfChanged(ref color[1], value); }
        }
        public ISolidColorBrush Color2
        {
            get { return color[2]; }
            set { this.RaiseAndSetIfChanged(ref color[2], value); }
        }
        public ISolidColorBrush Color3
        {
            get { return color[3]; }
            set { this.RaiseAndSetIfChanged(ref color[3], value); }
        }
        public ISolidColorBrush Color4
        {
            get { return color[4]; }
            set { this.RaiseAndSetIfChanged(ref color[4], value); }
        }
        public ISolidColorBrush Color5
        {
            get { return color[5]; }
            set { this.RaiseAndSetIfChanged(ref color[5], value); }
        }
        public ISolidColorBrush Color6
        {
            get { return color[6]; }
            set { this.RaiseAndSetIfChanged(ref color[6], value); }
        }
        public ISolidColorBrush Color7
        {
            get { return color[7]; }
            set { this.RaiseAndSetIfChanged(ref color[7], value); }
        }
        public ISolidColorBrush Color8
        {
            get { return color[8]; }
            set { this.RaiseAndSetIfChanged(ref color[8], value); }
        }
        public ReactiveCommand<Unit, Unit> Create { get; }

    }
}