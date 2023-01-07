
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
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColSTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColTimer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColTotalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gColStopTimer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtCustCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnFormItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.gColPhone,
            this.gColName,
            this.gColCount,
            this.gColSTime,
            this.gColTimer,
            this.gColTotalTime,
            this.gColStopTimer});
            this.dataGridView1.Location = new System.Drawing.Point(122, 211);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 227);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // colIndex
            // 
            this.colIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colIndex.HeaderText = "ID";
            this.colIndex.Name = "colIndex";
            this.colIndex.Width = 30;
            // 
            // gColPhone
            // 
            this.gColPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gColPhone.HeaderText = "Phone#";
            this.gColPhone.MaxInputLength = 10;
            this.gColPhone.Name = "gColPhone";
            this.gColPhone.ReadOnly = true;
            this.gColPhone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gColPhone.Width = 70;
            // 
            // gColName
            // 
            this.gColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gColName.HeaderText = "Name";
            this.gColName.Name = "gColName";
            this.gColName.Width = 60;
            // 
            // gColCount
            // 
            this.gColCount.HeaderText = "Count";
            this.gColCount.Name = "gColCount";
            this.gColCount.Width = 45;
            // 
            // gColSTime
            // 
            this.gColSTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gColSTime.HeaderText = "StartTime";
            this.gColSTime.Name = "gColSTime";
            this.gColSTime.Width = 77;
            // 
            // gColTimer
            // 
            this.gColTimer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gColTimer.HeaderText = "Timer";
            this.gColTimer.Name = "gColTimer";
            this.gColTimer.ReadOnly = true;
            this.gColTimer.Width = 58;
            // 
            // gColTotalTime
            // 
            this.gColTotalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.gColTotalTime.HeaderText = "TotalTime";
            this.gColTotalTime.Name = "gColTotalTime";
            this.gColTotalTime.Width = 79;
            // 
            // gColStopTimer
            // 
            this.gColStopTimer.HeaderText = "Stop";
            this.gColStopTimer.Name = "gColStopTimer";
            this.gColStopTimer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gColStopTimer.Text = "Stop";
            this.gColStopTimer.UseColumnTextForButtonValue = true;
            this.gColStopTimer.Width = 40;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(356, 23);
            this.txtPhone.MaxLength = 10;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(142, 20);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(356, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 20);
            this.txtName.TabIndex = 2;
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
            this.btnStart.Location = new System.Drawing.Point(284, 156);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 25);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(392, 157);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 25);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtCustCount
            // 
            this.txtCustCount.Location = new System.Drawing.Point(356, 107);
            this.txtCustCount.Name = "txtCustCount";
            this.txtCustCount.Size = new System.Drawing.Size(142, 20);
            this.txtCustCount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "# of Kids";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnFormItem
            // 
            this.btnFormItem.Location = new System.Drawing.Point(668, 105);
            this.btnFormItem.Name = "btnFormItem";
            this.btnFormItem.Size = new System.Drawing.Size(75, 23);
            this.btnFormItem.TabIndex = 10;
            this.btnFormItem.Text = "Items";
            this.btnFormItem.UseVisualStyleBackColor = true;
            this.btnFormItem.Click += new System.EventHandler(this.btnFormItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFormItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustCount);
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
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
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
        private System.Windows.Forms.TextBox txtCustCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColSTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn gColTotalTime;
        private System.Windows.Forms.DataGridViewButtonColumn gColStopTimer;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnFormItem;
    }
}

