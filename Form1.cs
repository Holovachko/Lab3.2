using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab3._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Вася\source\repos\Lab3.2\Database1.mdf;Integrated Security=True";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand getAll = new SqlCommand(
                "SELECT * FROM Persons",
                con
                );
            SqlDataAdapter adapt = new SqlDataAdapter(getAll);
            con.Open();
            adapt.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Вася\source\repos\Lab3.2\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand pretWithFlat = new SqlCommand(
                "SELECT * FROM Persons WHERE FlatAvailability = 'yes'",
                con
                );
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(pretWithFlat);
            con.Open();
            adapt.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Вася\source\repos\Lab3.2\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand maxSalary = new SqlCommand(
                "SELECT TOP(1) * FROM Persons ORDER BY salary DESC",
                con
                );
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(maxSalary);
            con.Open();
            adapt.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Вася\source\repos\Lab3.2\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand delPret = new SqlCommand(
                "WITH DB AS (" +
                "SELECT TOP(1) * FROM Persons ORDER BY Salary)" +
                "DELETE FROM DB"
                ,
                con
                );
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(delPret);
            con.Open();
            adapt.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Вася\source\repos\Lab3.2\Database1.mdf;Integrated Security=True";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand ChangeList = new SqlCommand(
                "UPDATE Persons SET Salary = Salary + 1000",
                con
                );
            SqlCommand getList = new SqlCommand(
              "SELECT * FROM Persons ",
              con
              );
            SqlDataAdapter adaptGet = new SqlDataAdapter(getList);
            ChangeList.ExecuteNonQuery();
            adaptGet.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Вася\source\repos\Lab3.2\Database1.mdf;Integrated Security=True";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand pretWithGreenEyes = new SqlCommand(
               "SELECT EyesColor , COUNT(*) as countPret FROM Persons WHERE EyesColor = 'green' GROUP BY EyesColor"
               ,
               con
               );
            SqlDataAdapter adaptGet = new SqlDataAdapter(pretWithGreenEyes);
            con.Open();
            adaptGet.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }
    }
}
