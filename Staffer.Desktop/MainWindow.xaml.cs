using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Windows;

namespace Staffer.Desktop
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Lib.Staffer> Staffers { get; set; }

        public MainWindow()
        {
            Staffers = new ObservableCollection<Lib.Staffer>(InitStaffers());
            
            InitializeComponent();
        }
        
        private List<Lib.Staffer> InitStaffers()
        {
            var url = File.ReadAllText("urls.txt");
            using var webStream = WebRequest.Create(url).GetResponse().GetResponseStream();
            using var stream = new StreamReader(webStream);
            var json = stream.ReadToEnd();
            return JsonSerializer.Deserialize<List<Lib.Staffer>>(json);
        }
    }
}