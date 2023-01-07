
using System;
using System.Windows.Forms;

namespace newAppforTimer
{
    partial class Items
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
            System.Windows.Forms.Label label4;
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemQty = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.grpDiscount = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtAmount = new System.Windows.Forms.RadioButton();
            this.rbtPercent = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPurchaseAmt = new System.Windows.Forms.TextBox();
            this.txtSellingAmt = new System.Windows.Forms.TextBox();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.btnHome = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            this.grpDiscount.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(106, 339);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(56, 13);
            label4.TabIndex = 9;
            label4.Text = "Final Price";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(177, 36);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(138, 20);
            this.txtItemName.TabIndex = 0;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(91, 38);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(72, 13);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "ProductName";
            // 
            // txtItemQty
            // 
            this.txtItemQty.Location = new System.Drawing.Point(177, 87);
            this.txtItemQty.Name = "txtItemQty";
            this.txtItemQty.Size = new System.Drawing.Size(138, 20);
            this.txtItemQty.TabIndex = 1;
            this.txtItemQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemQty_KeyPress);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(82, 63);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(134, 20);
            this.txtDiscount.TabIndex = 6;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // grpDiscount
            // 
            this.grpDiscount.Controls.Add(this.label2);
            this.grpDiscount.Controls.Add(this.rbtAmount);
            this.grpDiscount.Controls.Add(this.txtDiscount);
            this.grpDiscount.Controls.Add(this.rbtPercent);
            this.grpDiscount.Location = new System.Drawing.Point(98, 221);
            this.grpDiscount.Name = "grpDiscount";
            this.grpDiscount.Size = new System.Drawing.Size(229, 100);
            this.grpDiscount.TabIndex = 4;
            this.grpDiscount.TabStop = false;
            this.grpDiscount.Text = "Discount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Value";
            // 
            // rbtAmount
            // 
            this.rbtAmount.AutoSize = true;
            this.rbtAmount.Location = new System.Drawing.Point(163, 29);
            this.rbtAmount.Name = "rbtAmount";
            this.rbtAmount.Size = new System.Drawing.Size(61, 17);
            this.rbtAmount.TabIndex = 5;
            this.rbtAmount.Text = "Amount";
            this.rbtAmount.UseVisualStyleBackColor = true;
            // 
            // rbtPercent
            // 
            this.rbtPercent.AutoSize = true;
            this.rbtPercent.Checked = true;
            this.rbtPercent.Location = new System.Drawing.Point(69, 29);
            this.rbtPercent.Name = "rbtPercent";
            this.rbtPercent.Size = new System.Drawing.Size(88, 17);
            this.rbtPercent.TabIndex = 4;
            this.rbtPercent.TabStop = true;
            this.rbtPercent.Text = "Percentage%";
            this.rbtPercent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Purchase Price";
            // 
            // txtPurchaseAmt
            // 
            this.txtPurchaseAmt.Location = new System.Drawing.Point(177, 135);
            this.txtPurchaseAmt.Name = "txtPurchaseAmt";
            this.txtPurchaseAmt.Size = new System.Drawing.Size(138, 20);
            this.txtPurchaseAmt.TabIndex = 2;
            this.txtPurchaseAmt.TextChanged += new System.EventHandler(this.txtPurchaseAmt_TextChanged);
            // 
            // txtSellingAmt
            // 
            this.txtSellingAmt.Location = new System.Drawing.Point(178, 335);
            this.txtSellingAmt.Name = "txtSellingAmt";
            this.txtSellingAmt.ReadOnly = true;
            this.txtSellingAmt.Size = new System.Drawing.Size(138, 20);
            this.txtSellingAmt.TabIndex = 7;
            // 
            // btnAddStock
            // 
            this.btnAddStock.Location = new System.Drawing.Point(129, 382);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(165, 38);
            this.btnAddStock.TabIndex = 10;
            this.btnAddStock.Text = "Add Stock";
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sale Price";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(177, 183);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(138, 20);
            this.txtSalePrice.TabIndex = 3;
            this.txtSalePrice.TextChanged += new System.EventHandler(this.txtSalePrice_TextChanged);
            // 
            // btnHome
            // 
            this.btnHome.AutoSize = true;
            this.btnHome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHome.Location = new System.Drawing.Point(351, 22);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(45, 23);
            this.btnHome.TabIndex = 13;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 479);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.btnAddStock);
            this.Controls.Add(label4);
            this.Controls.Add(this.txtSellingAmt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpDiscount);
            this.Controls.Add(this.txtPurchaseAmt);
            this.Controls.Add(this.txtItemQty);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.txtItemName);
            this.Name = "Items";
            this.Text = "Items";
            this.Load += new System.EventHandler(this.Items_Load);
            this.grpDiscount.ResumeLayout(false);
            this.grpDiscount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemQty;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.GroupBox grpDiscount;
        private System.Windows.Forms.RadioButton rbtAmount;
        private System.Windows.Forms.RadioButton rbtPercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPurchaseAmt;
        private System.Windows.Forms.TextBox txtSellingAmt;
        private System.Windows.Forms.Button btnAddStock;
        private Label label5;
        private TextBox txtSalePrice;
        private Button btnHome;
    }
}