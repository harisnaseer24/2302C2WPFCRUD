using System.Windows;

namespace _2302C2WPFCRUD
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearData()
        {
            pname.Clear();
            desc.Clear();
            price.Clear();
            qty.Clear();
            cat.Clear();
        }

        private void ClearFeilds(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
    }
}