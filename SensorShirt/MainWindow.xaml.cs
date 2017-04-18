using System;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace SensorShirt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort _serialPort;
        public MainWindow()
        {
            _serialPort = new SerialPort("COM4");
            _serialPort.Open();
//            var mamadjavad = esmail.ReadLine();
//            textBox.Text = mamadjavad;
////            Console.WriteLine(mamadjavad);
            InitializeComponent();

        }

        private void ReadData()
        {
            while (true)
            {
//                var chestSensorData = (float)(1 + ((int.Parse(_serialPort.ReadLine())) / -600.0));
                Dispatcher.Invoke(DispatcherPriority.Background,
                    DoStuff());
                //chest.Fill = new SolidColorBrush(Color.FromRgb(baghala, baghala, baghala));
                Thread.Sleep(5);
//                baghala += (byte)10;
            }
        }

        private Action DoStuff()
        {
            return () =>
            {
                var sensorData = _serialPort.ReadLine().ToString().Split('-');
                if (sensorData.Length != 8)
                    return;
                var sensor1 = (float)(1+((int.Parse(sensorData[0]))/-300.0));
                var sensor2 = (float)(1+((int.Parse(sensorData[1]))/-200.0));
                var sensor3 = (float)(1+((int.Parse(sensorData[2]))/-300.0));
                var sensor4 = (float)(1+((int.Parse(sensorData[3]))/-300.0));
                var sensor5 = (float)(1+((int.Parse(sensorData[4]))/-600.0));
                var sensor6 = (float)(1+((int.Parse(sensorData[5]))/-600.0));
                var sensor7 = (float)(1+((int.Parse(sensorData[6]))/-600.0));
                var sensor8 = (float)(1+((int.Parse(sensorData[7]))/-600.0));

                chestUL.Fill = new SolidColorBrush(Color.FromScRgb(sensor1,0,0, 0));
                chestUR.Fill = new SolidColorBrush(Color.FromScRgb(sensor2,0,0, 0));
                chestDL.Fill = new SolidColorBrush(Color.FromScRgb(sensor3,0,0, 0));
                chestDR.Fill = new SolidColorBrush(Color.FromScRgb(sensor4,0,0, 0));
                handUL.Fill = new SolidColorBrush(Color.FromScRgb(sensor5,0,0, 0));
                handDL.Fill = new SolidColorBrush(Color.FromScRgb(sensor6,0,0, 0));
                handUR.Fill = new SolidColorBrush(Color.FromScRgb(sensor7,0,0, 0));
                handDR.Fill = new SolidColorBrush(Color.FromScRgb(sensor8,0,0, 0));
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ReadData();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            ReadData();
        }
    }
}
