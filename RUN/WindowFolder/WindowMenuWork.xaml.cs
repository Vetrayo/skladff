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
    /// Логика взаимодействия для WindowWork.xaml
    /// </summary>
    public partial class WindowMenuWork : Window
    {
        public WindowMenuWork()
        {
            InitializeComponent();
        }

        private void IOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BDGZakazi_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new WindowListZakaz().ShowDialog();
            this.ShowDialog();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

    }
}
