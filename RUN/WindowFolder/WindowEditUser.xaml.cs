using RUN.DataFolder;
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
        public WindowEditUser(User user)
        {
            InitializeComponent();
            name = user.Surname;
            DataContext = user;
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
                DBEntities.GetContext().User.FirstOrDefault(z => z.Surname == name).Surname = TbSurname.Text;
                DBEntities.GetContext().User.FirstOrDefault(z => z.Surname == name).Name = TbName.Text;
                DBEntities.GetContext().User.FirstOrDefault(z => z.Surname == name).Patronymic = TbMiddleName.Text;
                DBEntities.GetContext().User.FirstOrDefault(z => z.Surname == name).Login = TbLogin.Text;
                DBEntities.GetContext().User.FirstOrDefault(z => z.Surname == name).Password = TbPassword.Text;
                DBEntities.GetContext().User.FirstOrDefault(z => z.Surname == name).Phone = TbPhone.Text;
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
