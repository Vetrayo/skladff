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
using RUN.Data;

namespace RUN.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для WindowUser.xaml
    /// </summary>
    public partial class WindowMenuUser : Window
    {
        public WindowMenuUser()
        {
            InitializeComponent();
        }

        private void BZakaz_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new WindowZakaz().ShowDialog();
            this.ShowDialog();
        }

        private void IOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }
}
