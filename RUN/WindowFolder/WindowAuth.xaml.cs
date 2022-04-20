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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using RUN.DataFolder;

namespace RUN.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WindowAuth : Window
    {
        public WindowAuth()
        {
            InitializeComponent();
        }

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) ||
                     string.IsNullOrEmpty(PbPassword.Password))
            {
                ClassMB.Error("Необходимо заполнить все поля");
                return;
            }
            try
            {
                var user = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == TbLogin.Text);
                if (user == null)
                {
                    ClassMB.Error("Логин введен неправильно");
                    return;
                }
                if (user.Password != PbPassword.Password)
                {
                    ClassMB.Error("Пароль введен неверно");
                    return;
                }
                switch (user.IdRole)
                {
                    case 1:
                        this.Hide();
                        new WindowMenuAdmin().ShowDialog();
                        this.ShowDialog();
                        break;

                    case 2:
                        this.Hide();
                        new WindowMenuWork().ShowDialog();
                        this.ShowDialog();
                        break;
                    case 3:
                        this.Hide();
                        new WindowMenuUser().ShowDialog();
                        this.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
        }

        private void BReg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new WindowReg().ShowDialog();
            this.ShowDialog();
        }
    }
}
