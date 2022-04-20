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
    /// Логика взаимодействия для WindowZakaz.xaml
    /// </summary>
    public partial class WindowZakaz : Window
    {
        public WindowZakaz()
        {
            InitializeComponent();
            CbProduct.ItemsSource = DBEntities.GetContext().Product.ToList().OrderBy(r => r.Name);

        }

        private void IZakaz_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbSurname.Text))
            {
                ClassMB.Information("Введите Фамилию");
                TbSurname.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbName.Text))
            {
                ClassMB.Information("Введите Имя");
                TbName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbAmount.Text))
            {
                ClassMB.Information("Введите количество");
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Database.ExecuteSqlCommand($"insert into Zakaz(Surname, Name, Patronymic, Amount, IdProduct, IdStatus) values ('{TbSurname.Text}', '{TbName.Text}','{TbMiddleName.Text}','{TbAmount.Text}','{CbProduct.SelectedIndex}','1');");

                    DBEntities.GetContext().SaveChanges();
                    ClassMB.Information("Вы успешно заказали продукты");
                    this.Close();
                }
                catch (Exception ex)
                {
                    ClassMB.MBError(ex);
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
