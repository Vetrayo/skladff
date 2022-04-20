using RUN.Data;
using RUN.WindowFolder;
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

namespace RUN
{
    /// <summary>
    /// Логика взаимодействия для WindowEditUser.xaml
    /// </summary>
    public partial class WindowEditUser : Window
    {
        string name;
        public WindowEditUser(Zakaz zakaz)
        {
            InitializeComponent();
            name = zakaz.Surname;
            DataContext = zakaz;
        }

        private void IOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void IEdit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbName.Text))
            {
                ClassMB.Information("Введите Имя");
                TbName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbSurname.Text))
            {
                ClassMB.Information("Введите Фамилию");
            }
            else
            {
                DBEntities.GetContext().Zakaz.FirstOrDefault(z => z.Surname == name).Surname = TbSurname.Text;
                DBEntities.GetContext().Zakaz.FirstOrDefault(z => z.Surname == name).Name = TbName.Text;
                DBEntities.GetContext().Zakaz.FirstOrDefault(z => z.Surname == name).Patronymic = TbMiddleName.Text;
                DBEntities.GetContext().SaveChanges();
                ClassMB.Information("Успешно изменено");
                this.Close();
            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }
}
