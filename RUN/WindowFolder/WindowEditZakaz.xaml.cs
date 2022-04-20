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
using RUN.DataFolder;

namespace RUN.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для WindowEditZakaz.xaml
    /// </summary>
    public partial class WindowEditZakaz : Window
    {
        int idZakaz;
        public WindowEditZakaz(Zakaz zakaz)
        {
            InitializeComponent();

            CbIdStatus.ItemsSource = DBEntities.GetContext().Status.ToList();

            idZakaz = zakaz.IdZakaz;

            CbIdStatus.SelectedItem = zakaz.IdStatus;
        }

        private void IEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbIdStatus.Text))
            {
                ClassMB.Information("Выберете статус");
                CbIdStatus.Focus();
            }
            else
            {
                DBEntities.GetContext().Zakaz.FirstOrDefault(z => z.IdZakaz == idZakaz).
                    Status = DBEntities.GetContext().
                    Status.FirstOrDefault(s => s.IdStatus == CbIdStatus.SelectedIndex + 1);
                DBEntities.GetContext().SaveChanges();
                ClassMB.Information("Статус успешно изменен");
                this.Close();
            }

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
