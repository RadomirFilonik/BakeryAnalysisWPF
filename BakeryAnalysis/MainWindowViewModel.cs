using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis
{
    public class MainWindowViewModel
    {
        public ObservableCollection<User> AllUsers{ get; set; }

        public MainWindowViewModel()
        {
        }
    }
}
