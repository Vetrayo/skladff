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
    /// Логика взаимодействия для WindowListWork.xaml
    /// </summary>
    public partial class WindowListWork : Window
    {
        public WindowListWork()
        {
            InitializeComponent();
            DgWork.ItemsSource = DBEntities.GetContext().Work.ToList().OrderBy(u => u.Patronymic);
        }

        private void IOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void updateDataGrid()
        {
            DgWork.ItemsSource = DBEntities.GetContext().Work.ToList().OrderBy(u => u.Patronymic);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DgWork.ItemsSource = DBEntities.GetContext().Work.Where
                    (c => c.Surname.StartsWith(tbSearch.Text)
                    || c.Name.StartsWith(tbSearch.Text)).ToList();

                if (DgWork.Items.Count < 1)
                    ClassMB.Error("Не найдено");
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
        }

        private void IAdd_Click(object sender, RoutedEventArgs e)
        {
            new WindowAddWork().ShowDialog();
            updateDataGrid();
        }

        private void DgWork_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new WindowEditWork(DgWork.SelectedItem as Work).ShowDialog();
            updateDataGrid();
        }

        private void IDel_Click(object sender, RoutedEventArgs e)
        {
            if (DgWork.SelectedItem == null)
                return;
            DBEntities.GetContext().Database.ExecuteSqlCommand($"delete from Work where IdWork = ('{(DgWork.SelectedItem as Work).IdWork}')");
            updateDataGrid();
            ClassMB.Information("Вы успешно удалили строчку");
        }
    }
}
