using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AsyncAwaitToDataBase
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source =CR4-00\SQLEXPRESS;Initial Catalog=Library;Integrated Security=true;";
        SqlConnection sqlConnection = null;
        DataTable dataTable = null;
        public Form1()
        { 
            InitializeComponent();
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                string sql = "waitfor delay '00:00:10';";
                sql += textBox1.Text;
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                dataTable = new DataTable();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                int line = 0;
                do
                {
                    while (await sqlDataReader.ReadAsync())
                    {
                        if(line++ == 0) {
                            for (int i = 0; i < sqlDataReader.FieldCount; i++)
                            {
                                dataTable.Columns.Add(sqlDataReader.GetName(i));
                            }
                        }

                        DataRow dataRow = dataTable.NewRow();
                        for (int i = 0; i < sqlDataReader.FieldCount; i++)
                        {
                            //dataRow[i] = sqlDataReader[i];
                            dataRow[i] = await sqlDataReader.GetFieldValueAsync<Object>(i);
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                } while (await sqlDataReader.NextResultAsync());
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataTable;
        }
    }
}
