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
    /// Логика взаимодействия для WindowListProducts.xaml
    /// </summary>
    public partial class WindowListProducts : Window
    {
        public WindowListProducts()
        {
            InitializeComponent();
            DgProducts.ItemsSource = DBEntities.GetContext().Product.ToList().OrderBy(u => u.Name);
        }

        private void updateDataGrid()
        {
            DgProducts.ItemsSource = DBEntities.GetContext().Product.ToList().OrderBy(u => u.Name);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DgProducts.ItemsSource = DBEntities.GetContext().Product.Where
                    (c => c.Name.StartsWith(tbSearch.Text)).ToList();

                if (DgProducts.Items.Count < 1)
                    ClassMB.Error("Не найдено");
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
        }

        private void IOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IAdd_Click(object sender, RoutedEventArgs e)
        {
            new WindowAddProduct().ShowDialog();
            updateDataGrid();
        }

        private void IDel_Click(object sender, RoutedEventArgs e)
        {
            if (DgProducts.SelectedItem == null)
                return;
            DBEntities.GetContext().Database.ExecuteSqlCommand($"delete from Product where IdProduct = ('{(DgProducts.SelectedItem as Product).IdProduct}')");
            updateDataGrid();
            ClassMB.Information("Вы успешно удалили строчку");
        }

        private void DgProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new WindowEditProduct(DgProducts.SelectedItem as Product).ShowDialog();
            updateDataGrid();
        }
    }
}
