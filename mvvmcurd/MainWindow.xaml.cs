using mvvmcurd.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using mvvmcurd.views;
using mvvmcurd.model;

namespace mvvmcurd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentsViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new StudentsViewModel();
            this.DataContext = ViewModel;
           
        }
    }
}