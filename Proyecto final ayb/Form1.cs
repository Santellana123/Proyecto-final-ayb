using System;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Proyecto_final_ayb
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabaseConnection();

        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = @"Server=DESKTOP-UMCEALU\SQLEXPRESS;Database=Nissan;Integrated Security=True;";
            sqlConnection = new SqlConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (.csv)|.csv|XML files (.xml)|.xml|JSON files (.json)|.json"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string extension = Path.GetExtension(filePath).ToLower();
                switch (extension)
                {
                    case ".json":
                        ForJSON(filePath);
                        break;
                    case ".xml":
                        ForXML(filePath);
                        break;
                    case ".csv":
                        ForCSV(filePath);
                        break;

                    default:
                        MessageBox.Show("ELIGE EL FORMATO ACEPTADO");
                        break;
                }
            }
        }
        private void ForCSV(string filePath)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dataRow = dataTable.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataRow[i] = rows[i];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading CSV: " + ex.Message);
            }
        }
        private void ForJSON(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(jsonData);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading JSON: " + ex.Message);
            }
        }


        private void ForXML(string filePath)
        {
            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(filePath);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading XML: " + ex.Message);
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridView1.DataSource;

            DataRow newRow = dataTable.NewRow();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                newRow[i] = DBNull.Value;
            }

            dataTable.Rows.Add(newRow);

            dataGridView1.Refresh();
        }
        private void GuardarSQL()
        {
            try
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Autos", sqlConnection);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                DataTable dataTable = (DataTable)dataGridView1.DataSource;
                sqlDataAdapter.Update(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void btnSaveToDatabase_Click(object sender, EventArgs e)
        {
            GuardarSQL();

        }

        private void btnLoadFromDatabase_Click(object sender, EventArgs e)
        {
            CargarDeSQL();

        }
        private void CargarDeSQL()
        {
            try
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Autos", sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void btnSaveToXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (.xml)|.xml";
            saveFileDialog.Title = "Save data to XML";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ForXML(filePath);
            }
        }

        private void btnSaveToCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (.csv)|.csv";
            saveFileDialog.Title = "Save data to CSV";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ForCSV(filePath);
            }
        }

        private void btnSaveToJson_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (.json)|.json";
            saveFileDialog.Title = "Save data to XML";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ForJSON(filePath);
            }
        }
    }
}
