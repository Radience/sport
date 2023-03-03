using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SPORTs.Model
{
    class Authoriz
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-DHMQJ5P;Initial Catalog=Sport;Integrated Security=True");
        private static SqlDataAdapter adapter;
        private static DataTable dataTable = new DataTable();
        public static bool auth(string login, string password)
        {
            try
            {
                adapter = new SqlDataAdapter($"SELECT second_name, name_, patronymic, role FROM User_, Role WHERE login = '{login}' and password = '{password}' and User_.id_role = Role.id_role", connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count == 1)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Role.role = row["role"].ToString();
                        Role.second_name = row["second_name"].ToString();
                        Role.name = row["name_"].ToString();
                        Role.patronymic = row["patronymic"].ToString();
                    }
                    return true;
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
            return false;
        }
    }
}
