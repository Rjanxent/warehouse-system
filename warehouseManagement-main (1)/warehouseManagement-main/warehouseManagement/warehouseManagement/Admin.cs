using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace warehouseManagement
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (MySqlCommand cmd = new MySqlCommand(selectQuery, con))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost; user id=root;password=;database=inventory";
            string query = "DELETE FROM record";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item deleted successfully");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost; user id=root;password=;database=inventory";
            string query = "UPDATE record SET itemName=@itemName, itemNum=@itemNum WHERE id=@id";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    
                    cmd.Parameters.AddWithValue("@itemName", this.textBox1.Text);
                    // Assuming textBox3 is for itemNum
                    cmd.Parameters.AddWithValue("@itemNum", this.textBox2.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item updated successfully");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost; user id=root;password=;database=inventory";
            string insertQuery = "INSERT INTO record(itemName, itemNum) VALUES(@itemName, @itemNum)";
            string selectQuery = "SELECT * FROM record";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@itemName", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@itemNum", this.textBox2.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item added successfully");
                }

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, con))
                {
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }
    }
}
