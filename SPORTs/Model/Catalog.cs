using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SPORTs.Model
{
    class Catalog
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-DHMQJ5P;Initial Catalog=Sport;Integrated Security=True");
        private static SqlDataAdapter adapter;
        private static string idProduct;
        private static int priceNow;
        private static int discountNow;

        public static DataView CatalogUser()
        {
            connection.Open();
            SqlDataAdapter adapterSale = new SqlDataAdapter($"SELECT id_product FROM Product WHERE discount_now >= 15 AND color IS NULL", connection);
            DataTable dataTableSale = new DataTable();
            adapterSale.Fill(dataTableSale);
            foreach (DataRow row in dataTableSale.Rows)
            {
                idProduct = row["id_product"].ToString();
                SqlCommand cmd = new SqlCommand($"UPDATE Product SET color = '#7fff00' WHERE id_product = '{idProduct}'", connection);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            adapter = new SqlDataAdapter($"SELECT * FROM Product", connection);
            DataTable dataTable2 = new DataTable();
            adapter.Fill(dataTable2);
            foreach (DataRow row in dataTable2.Rows)
            {
                idProduct = row["id_product"].ToString();
                discountNow = Convert.ToInt32(row["discount_now"].ToString());
                int price = Convert.ToInt32(row["price"].ToString());
                priceNow = price - ((price * discountNow) / 100);
                SqlCommand cmd = new SqlCommand($"UPDATE Product SET price_now = '{priceNow}' WHERE id_product = '{idProduct}'", connection);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            adapter = new SqlDataAdapter($"SELECT * FROM Product", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            connection.Close();
            return dataTable.DefaultView;
        }

        public static DataView SaleCB(int v)
        {
            DataTable dataTable = new DataTable();
            try
            {
                switch (v)
                {
                    case 0:
                        adapter = new SqlDataAdapter($"SELECT * FROM Product WHERE discount_now > 0 and discount_now <= 10", connection);
                        adapter.Fill(dataTable);
                        break;
                    case 1:
                        adapter = new SqlDataAdapter($"SELECT * FROM Product WHERE discount_now > 10 and discount_now <= 15", connection);
                        adapter.Fill(dataTable);
                        break;
                    case 2:
                        adapter = new SqlDataAdapter($"SELECT * FROM Product WHERE discount_now > 15", connection);
                        adapter.Fill(dataTable);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable.DefaultView;
        }

        public static DataView PriceCB(int v)
        {
            DataTable dataTable = new DataTable();
            try
            {
                switch (v)
                {
                    case 0:
                        adapter = new SqlDataAdapter($"SELECT * FROM Product ORDER BY price_now ASC", connection);
                        adapter.Fill(dataTable);
                        break;
                    case 1:
                        adapter = new SqlDataAdapter($"SELECT * FROM Product ORDER BY price_now DESC", connection);
                        adapter.Fill(dataTable);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable.DefaultView;
        }

        public static DataView SearchTB(string search)
        {
            DataTable dataTable = new DataTable();
            try 
            {
                adapter = new SqlDataAdapter($"SELECT * FROM Product WHERE name_product LIKE '{search}'", connection);
                adapter.Fill(dataTable);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataTable.DefaultView;
        }

        public static void CreateOrder(DataTable dataTable)
        {
            foreach(DataRow row in dataTable.Rows)
            {
                idProduct = row["id_product"].ToString();

            }
            MessageBox.Show("Заказ сформирован", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
