using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace RUN.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowMenuAdmin : Window
    {
        public WindowMenuAdmin()
        {
            InitializeComponent();
        }

        private void BDGUsers_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new WindowListUsers().ShowDialog();
            this.ShowDialog();
        }

        private void IOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BDGProducts_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new WindowListProducts().ShowDialog();
            this.ShowDialog();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void BDGZakaz_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new WindowListZakazov().ShowDialog();
            this.ShowDialog();
        }

        private void BDGWork_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new WindowListWork().ShowDialog();
            this.ShowDialog();
        }
    }
}
