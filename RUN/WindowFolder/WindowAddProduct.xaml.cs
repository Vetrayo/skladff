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
    /// Логика взаимодействия для WindowAddProduct.xaml
    /// </summary>
    public partial class WindowAddProduct : Window
    {
        public WindowAddProduct()
        {
            InitializeComponent();
        }

        private void IAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbNameProduct.Text))
            {
                ClassMB.Information("Заполните поле продукта");
                TbNameProduct.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Database.ExecuteSqlCommand($"insert into Product(Name) values ('{TbNameProduct.Text}');");
                   ClassMB.Information("Вы добавили продукт");
                    this.Close();
                }
                catch(Exception ex)
                {
                    ClassMB.Error(ex.Message);
                }
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
