namespace Proyecto_final_ayb
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoadFile = new Button();
            btnAddRow = new Button();
            btnSaveToXML = new Button();
            btnSaveToCSV = new Button();
            btnSaveToJson = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(62, 66);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(75, 23);
            btnLoadFile.TabIndex = 0;
            btnLoadFile.Text = "button1";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += button1_Click;
            // 
            // btnAddRow
            // 
            btnAddRow.Location = new Point(62, 95);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(75, 23);
            btnAddRow.TabIndex = 1;
            btnAddRow.Text = "button2";
            btnAddRow.UseVisualStyleBackColor = true;
            // 
            // btnSaveToXML
            // 
            btnSaveToXML.Location = new Point(62, 124);
            btnSaveToXML.Name = "btnSaveToXML";
            btnSaveToXML.Size = new Size(75, 23);
            btnSaveToXML.TabIndex = 2;
            btnSaveToXML.Text = "button3";
            btnSaveToXML.UseVisualStyleBackColor = true;
            // 
            // btnSaveToCSV
            // 
            btnSaveToCSV.Location = new Point(62, 153);
            btnSaveToCSV.Name = "btnSaveToCSV";
            btnSaveToCSV.Size = new Size(75, 23);
            btnSaveToCSV.TabIndex = 3;
            btnSaveToCSV.Text = "button4";
            btnSaveToCSV.UseVisualStyleBackColor = true;
            // 
            // btnSaveToJson
            // 
            btnSaveToJson.Location = new Point(62, 269);
            btnSaveToJson.Name = "btnSaveToJson";
            btnSaveToJson.Size = new Size(75, 23);
            btnSaveToJson.TabIndex = 7;
            btnSaveToJson.Text = "btnSaveToJson";
            btnSaveToJson.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(229, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(330, 188);
            dataGridView1.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnSaveToJson);
            Controls.Add(btnSaveToCSV);
            Controls.Add(btnSaveToXML);
            Controls.Add(btnAddRow);
            Controls.Add(btnLoadFile);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadFile;
        private Button btnAddRow;
        private Button btnSaveToXML;
        private Button btnSaveToCSV;
        private Button btnSaveToJson;
        private DataGridView dataGridView1;
    }
}
