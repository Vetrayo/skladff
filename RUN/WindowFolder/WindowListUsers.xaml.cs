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
    /// Логика взаимодействия для WindowListUsers.xaml
    /// </summary>
    public partial class WindowListUsers : Window
    {

        public WindowListUsers()
        {
            InitializeComponent();
            DgClient.ItemsSource = DBEntities.GetContext().User.ToList().Where(u => u.Role.Name == "Пользователь");
        }

        private void updateDataGrid()
        {
            DgClient.ItemsSource = DBEntities.GetContext().User.ToList().Where(u => u.Role.Name == "Пользователь");
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DgClient.ItemsSource = DBEntities.GetContext().User.Where
                    (c => c.Surname.StartsWith(tbSearch.Text)
                    || c.Name.StartsWith(tbSearch.Text)).ToList();

                if (DgClient.Items.Count < 1)
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

        private void DgClient_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new WindowEditUser(DgClient.SelectedItem as User).ShowDialog();
        }

        private void IAdd_Click(object sender, MouseButtonEventArgs e)
        {
            new WindowAddUser().ShowDialog();
            updateDataGrid();
        }

        private void IDel_Click(object sender, MouseButtonEventArgs e)
        {
            if (DgClient.SelectedItem == null)
                return;
            DBEntities.GetContext().Database.ExecuteSqlCommand($"delete from [User] where IdUser = ('{(DgClient.SelectedItem as User).IdUser}')");
            updateDataGrid();
            ClassMB.Information("Вы успешно удалили пользователя");
        }
    }
}
