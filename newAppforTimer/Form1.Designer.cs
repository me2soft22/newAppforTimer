
namespace newAppforTimer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColSTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColTimer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColStopTimer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gColTotalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.gColPhone,
            this.gColName,
            this.gColSTime,
            this.gColTimer,
            this.gColStopTimer,
            this.gColTotalTime});
            this.dataGridView1.Location = new System.Drawing.Point(12, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(356, 23);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(142, 20);
            this.txtPhone.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(356, 70);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 20);
            this.txtName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Customer Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Customer Name";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(288, 127);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 25);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(389, 127);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 25);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // colIndex
            // 
            this.colIndex.HeaderText = "ID";
            this.colIndex.Name = "colIndex";
            // 
            // gColPhone
            // 
            this.gColPhone.HeaderText = "Phone#";
            this.gColPhone.Name = "gColPhone";
            // 
            // gColName
            // 
            this.gColName.HeaderText = "Name";
            this.gColName.Name = "gColName";
            // 
            // gColSTime
            // 
            this.gColSTime.HeaderText = "StartTime";
            this.gColSTime.Name = "gColSTime";
            // 
            // gColTimer
            // 
            this.gColTimer.HeaderText = "Timer";
            this.gColTimer.Name = "gColTimer";
            // 
            // gColStopTimer
            // 
            this.gColStopTimer.HeaderText = "Stop";
            this.gColStopTimer.Name = "gColStopTimer";
            // 
            // gColTotalTime
            // 
            this.gColTotalTime.HeaderText = "TotalTime";
            this.gColTotalTime.Name = "gColTotalTime";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColSTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColTimer;
        private System.Windows.Forms.DataGridViewButtonColumn gColStopTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColTotalTime;
    }
}

