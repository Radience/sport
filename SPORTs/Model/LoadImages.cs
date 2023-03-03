using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SPORTs.Model
{
    class LoadImages
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-DHMQJ5P;Initial Catalog=Sport;Integrated Security=True");
        private static string photos = "";

        public static void loadImages()
        {
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                string currentPath = Directory.GetCurrentDirectory();
                string activePath = "";
                for (int i = 0; i < currentPath.Length - 9; i++)
                {
                    activePath += currentPath[i];
                }
                activePath += @"Resources\Image";
                SqlCommand cmd = new SqlCommand($"SELECT image_ FROM Product WHERE image_ IS NOT NULL", connection);
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    photos = row["image_"].ToString();
                    string betwenPath = activePath;
                    for (int i = photos.Length - 1; i > 0; i--)
                    {
                        if (photos[i] == '\\')
                        {
                            for (int j = i; j < photos.Length; j++)
                            {
                                betwenPath += photos[j];
                            }
                            cmd = new SqlCommand($"UPDATE Product SET image_ = '{betwenPath}' WHERE image_ = '{photos}'", connection);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            break;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
