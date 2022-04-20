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
    /// Логика взаимодействия для WindowEditProduct.xaml
    /// </summary>
    public partial class WindowEditProduct : Window
    {
        string nameProduct;
        public WindowEditProduct(Product product)
        {
            InitializeComponent();
            DataContext = product;
            nameProduct = product.Name;
        }

        private void IEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbProduct.Text))
            {
                ClassMB.Information("Заполните поле продукта");
                TbProduct.Focus();
            }
            else
            {
                DBEntities.GetContext().Product.FirstOrDefault(z => z.Name == nameProduct).Name = TbProduct.Text;
                DBEntities.GetContext().SaveChanges();
                ClassMB.Information("Название успешно изменено");
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
