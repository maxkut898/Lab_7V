using System;
using System.IO;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Interactivity;
using Lab7.ViewModels;
using Lab7.Models;
using Avalonia.Controls;

namespace Lab7.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.FindControl<Button>("Add").Click += async delegate
            {
                var context = (this.DataContext as MainWindowViewModel);
                Note newnote = new Note("Студент", "0", "0", "0", "0", "0", "0", "0", false);
                newnote.PropertyChanged += context.ContentCollectionChanged;
                context.Notes.Add(newnote);
                context.Notes[context.Notes.Count - 1].Grade1 = "1";
                context.Notes[context.Notes.Count - 1].Grade1 = "0";
            };


            this.FindControl<Button>("Delete").Click += async delegate
            {
                var context = (this.DataContext as MainWindowViewModel);
                var items = context.Notes;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Check) { items.Remove(items[i]); i--; };
                }
                context.ChangeAverage();
            };

            this.FindControl<MenuItem>("About").Click += async delegate
            {
                await new About().ShowDialog((Window)this.VisualRoot);
            };

            this.FindControl<MenuItem>("Exit").Click += async delegate
            {
                this.Close();
            };

            this.FindControl<MenuItem>("Save").Click += async delegate
            {
                string? path;
                var taskPath = new SaveFileDialog()
                {
                    Title = "Save",
                    Filters = null
                };

                path = await taskPath.ShowAsync((Window)this.VisualRoot);
                if (path is not null)
                {
                    var items = (this.DataContext as MainWindowViewModel).Notes;
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(items.Count.ToString());
                        foreach (var item in items)
                        {
                            sw.WriteLine(item.Fio);
                            sw.WriteLine(item.Grade1);
                            sw.WriteLine(item.Grade2);
                            sw.WriteLine(item.Grade3);
                            sw.WriteLine(item.Grade4);
                            sw.WriteLine(item.Grade5);
                            sw.WriteLine(item.Grade6);
                            sw.WriteLine(item.Grade7);

                        }
                    }
                }
            };
            this.FindControl<MenuItem>("Load").Click += async delegate
            {
                string? path;
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open file",
                    Filters = null
                };

                string[]? pathArray = await taskPath.ShowAsync((Window)this.VisualRoot);
                path = pathArray is null ? null : string.Join(@"\", pathArray);
                if (pathArray != null) path = string.Join(@"\", pathArray);

                if (path is not null)
                {
                    var items = (this.DataContext as MainWindowViewModel).Notes;
                    items.Clear();
                    using (StreamReader sr = File.OpenText(path))
                    {
                        int count;
                        if (!Int32.TryParse(sr.ReadLine(), out count)) return;
                        for (int i = 0; i < count; i++)
                        {
                            items.Add
                                (new Note(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), false));
                        }
                        foreach (var item in items)
                        {
                            item.PropertyChanged +=
                                (this.DataContext as MainWindowViewModel).ContentCollectionChanged;
                        }
                    }
                    var contex = (this.DataContext as MainWindowViewModel);
                    contex.ChangeAverage();
                }
            };
        }

    }


}