using RUN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RUN.WindowFolder
{
	class ClassMB
	{
        public static void Error(string text)
        {
            MessageBox.Show(text, "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void MBError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void Information(string text)
        {
            MessageBox.Show(text, "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void QuestionExit()
        {
            if (MessageBox.Show("Вы действительно хотите выйти?",
                "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes) App.Current.Shutdown();
        }
    }
}
