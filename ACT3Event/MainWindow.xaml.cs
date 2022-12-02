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

namespace ACT3Event
{
    
    public partial class MainWindow : Window
    {
        int[] Numbers = new int[3];
        DispatcherTimer timer = new DispatcherTimer();
        Class1 class1 = new Class1();
        string type = null;
        public MainWindow()
        {
            InitializeComponent();
           
            A.PreviewTextInput += new TextCompositionEventHandler(VTI);
            B.PreviewTextInput += new TextCompositionEventHandler(VTI);
            C.PreviewTextInput += new TextCompositionEventHandler(VTI);

            calc.MouseEnter += new MouseEventHandler(srvVBtn);
            calc.MouseLeave += new MouseEventHandler(stopSrvVBtn);


        }

        private void Calculer(object sender, MouseButtonEventArgs e)
        {
            class1.trimone(int.Parse(A.Text), int.Parse(B.Text), int.Parse(C.Text), out type);
            Window1 secondpage = new Window1();
            secondpage.txtResultat.Text = type;
            Visibility = Visibility.Hidden;
        }

        private void VTI(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "," && !EstEntier(e.Text))
            {
                e.Handled = true;
            }
            if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
            {
                e.Handled = true;
            }
            else
            {


            }
        }

        private bool EstEntier(string userText)
        {
            return int.TryParse(userText, out _);
        }

        private void srvVBtn(object sender, EventArgs e)
        {
            virtualBtn.Visibility = Visibility.Visible;
            virtualBtn.Background = Brushes.Red;
        }

        private void stopSrvVBtn(object sender, EventArgs e)
        {
            virtualBtn.Visibility = Visibility.Hidden;
        }

    }
}
