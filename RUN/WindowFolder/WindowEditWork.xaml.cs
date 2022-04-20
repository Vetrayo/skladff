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
using RUN.Data;
using System.Windows.Shapes;

namespace RUN.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для WindowEditWork.xaml
    /// </summary>
    public partial class WindowEditWork : Window
    {
        string name;

        public WindowEditWork(Work work)
        {
            InitializeComponent();
            name = work.Surname;
            DataContext = work;
        }

        private void IEdit_Click(object sender, RoutedEventArgs e)
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
                DBEntities.GetContext().Work.FirstOrDefault(z => z.Surname == name).Surname = TbSurname.Text;
                DBEntities.GetContext().Work.FirstOrDefault(z => z.Surname == name).Name = TbName.Text;
                DBEntities.GetContext().Work.FirstOrDefault(z => z.Surname == name).Patronymic = TbMiddleName.Text;
                DBEntities.GetContext().SaveChanges();
                ClassMB.Information("Успешно изменено");
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
