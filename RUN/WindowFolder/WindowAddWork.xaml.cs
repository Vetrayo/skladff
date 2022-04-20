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
    /// Логика взаимодействия для WindowAddWork.xaml
    /// </summary>
    public partial class WindowAddWork : Window
    {
        public WindowAddWork()
        {
            InitializeComponent();
        }

        private void IAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbSurname.Text))
            {
                ClassMB.Information("Заполните поле фамилии");
                TbSurname.Focus();
            }
            else if (string.IsNullOrWhiteSpace(TbName.Text))
            {
                ClassMB.Information("Заполните поле имени");
                TbName.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Database.ExecuteSqlCommand($"insert into Work(Surname, Name, Patronymic) values ('{TbSurname.Text}', '{TbName.Text}','{TbMiddleName.Text}');");
                    ClassMB.Information("Вы добавили работника");
                    this.Close();
                }
                catch (Exception ex)
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
