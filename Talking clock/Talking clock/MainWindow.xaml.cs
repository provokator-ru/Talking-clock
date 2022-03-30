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
using System.Windows.Threading;
using System.Speech.Synthesis;


namespace Talking_clock
{   /// <summary>
    /// создание часов, вывод времени и синтез речи
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            label.Content = DateTime.Now.ToLongTimeString();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            string text = (string)label.Content; //Перенос времени в другую переменную
            string[] words = text.Split(new char[] { ':' }); //разделение данных переменной до :
            string hours = words[0]; //часы
            string minutes = words[1]; //минуты
            string seconds = words[2]; //секунды
            string ok = "";
            synthesizer.Speak("Время" + hours + "часов" + minutes + "минуты" +ok);
        }

        
        
    }
}
