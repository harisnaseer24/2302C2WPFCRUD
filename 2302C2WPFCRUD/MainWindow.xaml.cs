using System.Data;
using System.Windows;
using Microsoft.Data.SqlClient;

namespace _2302C2WPFCRUD
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        SqlConnection Conn = new SqlConnection("Data Source=.;Initial Catalog=2302C2WPFCRUD;User ID=sa;Password=aptech;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


       

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

        private bool isValid()
        {
            if (pname.Text == string.Empty || desc.Text == string.Empty || price.Text == string.Empty || qty.Text == string.Empty || cat.Text == string.Empty) {


                MessageBox.Show("All fields are required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            else
            {
                return true;
            }

        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            if (isValid())
            {
                SqlCommand addprod = new SqlCommand("Insert into products values (@pname, @desc, @price, @qty,@cat);", Conn);

                addprod.CommandType = CommandType.Text;
                Conn.Open();
                addprod.Parameters.AddWithValue("@pname", pname.Text);
                addprod.Parameters.AddWithValue("@desc", desc.Text);
                addprod.Parameters.AddWithValue("@price", price.Text);
                addprod.Parameters.AddWithValue("@qty", qty.Text);
                addprod.Parameters.AddWithValue("@cat", cat.Text);
                addprod.ExecuteNonQuery();

                Conn.Close();
                MessageBox.Show("Product inserted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearData();

            }
        }
    }
}