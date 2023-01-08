using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newAppforTimer
{
    public partial class Items : Form
    {
        DataTable inventory = new DataTable();
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zoha\source\repos\newAppforTimer\newAppforTimer\Database1.mdf;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        public Items()
        {
            InitializeComponent();
            clearFields();
            con = new SqlConnection(connectionString);
            stockGridview.AllowUserToAddRows = false;
            //truncatedb();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            //inventory.Columns.Add("Category");
            //inventory.Columns.Add("ProductName");
            //inventory.Columns.Add("BuyingPrice");
            //inventory.Columns.Add("SalePrice");
            //inventory.Columns.Add("Quantity");
            //inventory.Columns.Add("Discount");
            //inventory.Columns.Add("FinalPrice");

            //stockGridview.DataSource = inventory;
            refreshGridView();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            double salePrice = 0;
            double disc = 0;
            double totAmount = 0;
            if (txtSalePrice.Text == "")
            {
                salePrice = 0;
            }
            else {
                salePrice = Convert.ToDouble(txtSalePrice.Text);
            }
            if (txtDiscount.Text == "")
            {
                disc = 0;
            }
            else
            {
                disc = Convert.ToDouble(txtDiscount.Text);
            }   
            if (rbtAmount.Checked == true)
            {
                totAmount = salePrice - disc;
            }
            else
            {
                totAmount = salePrice - Math.Round((salePrice * disc) / 100);
            }
            txtSellingAmt.Text = totAmount.ToString();
        }

        private bool insertIntoStockTable(string itemCategory, string prodName, int qty, string discount, double purchasePrice, double salePrice, double sellingPrice)
        {
            bool isInserted = false;
            con.Open();
            cmd = new SqlCommand("INSERT INTO Items (Category,ItemName,Quantity,Discount,PurchasePrice,SalePrice,SellPrice,DateAdded) VALUES(@Category,@ItemName,@Quantity,@Discount,@PurchasePrice,@SalePrice,@SellPrice,@DateAdded)", con);

            string qrySlct = "Select * from Items where Category='" + itemCategory + "' and ItemName='" + prodName +"' ";
            SqlDataAdapter da = new SqlDataAdapter(qrySlct, con);
            SqlCommand selCmd = new SqlCommand(qrySlct, con);

            SqlDataReader reader = selCmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                MessageBox.Show("Item '" + prodName.ToString().Trim() + "' With Category " + itemCategory .ToString().Trim() + " Already Exists");
                con.Close();
            }
            else
            {
                cmd.Parameters.AddWithValue("@Category", itemCategory);
                cmd.Parameters.AddWithValue("@ItemName", prodName);
                cmd.Parameters.AddWithValue("@Quantity", qty);
                cmd.Parameters.AddWithValue("@Discount", discount);
                cmd.Parameters.AddWithValue("@PurchasePrice", purchasePrice);
                cmd.Parameters.AddWithValue("@SalePrice", salePrice);
                cmd.Parameters.AddWithValue("@SellPrice", sellingPrice);
                cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now.ToShortDateString());
                reader.Close();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Records Inserted Successfully");
                isInserted = true;
            }
            return isInserted;
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == "" || txtItemQty.Text == "" || txtDiscount.Text == "" || txtPurchaseAmt.Text == "" || txtSalePrice.Text == "" || txtSellingAmt.Text == "" )
            {
                MessageBox.Show("Please Enter all the fields.");
            }
            else
            {
                string itemCategory = cboCategory.SelectedItem.ToString();
                string itemName = txtItemName.Text;
                int iqty = Convert.ToInt32(txtItemQty.Text);
                string idisc = txtDiscount.Text;
                bool isPercent = rbtPercent.Checked;
                bool isAmount = rbtAmount.Checked;
                if (isPercent)
                {
                    idisc = idisc + "%";
                }
                double ipurPrice = Math.Round(Convert.ToDouble(txtPurchaseAmt.Text),2);
                double isalePrice = Math.Round(Convert.ToDouble(txtSalePrice.Text), 2);
                double iselPrice = Math.Round(Convert.ToDouble(txtSellingAmt.Text),2);
                bool isInserted = insertIntoStockTable(itemCategory, itemName, iqty, idisc, ipurPrice, isalePrice, iselPrice);
                if(isInserted)
                {
                    refreshGridView();
                    //inventory.Rows.Add(itemCategory, itemName, iqty, ipurPrice, isalePrice, idisc, iselPrice);
                    clearFields();
                }
            }
        }

        private void txtPurchaseAmt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtItemQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only Numbers allowed");
                txtDiscount.Text = "";
            }
        }

        private void clearFields()
        {
            cboCategory.SelectedIndex = -1;
            txtItemName.Text = "";
            txtItemQty.Text = "";
            txtDiscount.Text = "0";
            txtPurchaseAmt.Text = "";
            txtSalePrice.Text = "";
            txtSellingAmt.Text = "";
            rbtPercent.Checked = true;
        }

        private void truncatedb()
        {
            con.Open();
            string query1 = "TRUNCATE TABLE Items";
            cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void txtSalePrice_TextChanged(object sender, EventArgs e)
        {
            txtSellingAmt.Text = txtSalePrice.Text;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void retrieveFromStock(string category, string itemName)
        {
            int sid = 0;
            string sCat = "";
            string sName = "";
            int sQty = 0;
            double pprice = 0;
            double sprice = 0;
            string sdisc = "";
            double fprice = 0;

            con.Open();
            string selectQry1 = "Select * from Items where ItemName='" + itemName + "' and Category='"+ category + "' ";
            SqlDataAdapter da = new SqlDataAdapter(selectQry1, con);
            SqlCommand selCmd = new SqlCommand(selectQry1, con);

            SqlDataReader reader = selCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sid = reader.GetInt32(0);
                    sCat = reader.GetString(1);
                    sName = reader.GetString(2);
                    sQty = reader.GetInt32(3);
                    pprice = Convert.ToDouble(reader.GetDecimal(4));
                    sprice = Convert.ToDouble(reader.GetDecimal(5));
                    sdisc = reader.GetString(6);
                    fprice = Convert.ToDouble(reader.GetDecimal(7));
                    txtItemName.Text = sName;
                    txtItemQty.Text = sQty.ToString();
                    txtDiscount.Text = sdisc.ToString();
                    txtPurchaseAmt.Text = pprice.ToString();
                    txtSalePrice.Text = sprice.ToString();
                    txtSellingAmt.Text = fprice.ToString();
                }
            }
            reader.Close();
            con.Close();
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            string category = cboCategory.Text;
            string itemName = txtItemName.Text;
            retrieveFromStock(category, itemName);
        }

        private bool updateExistingStock(string itemCategory, string prodName, int qty, string discount, double purchasePrice, double salePrice, double sellingPrice)
        {
            bool isUpdated = false;
            con.Open();
            string selectQ2 = "Select * from Items where Category='" + itemCategory + "' and ItemName='" + prodName + "' ";
            SqlDataAdapter da = new SqlDataAdapter(selectQ2, con);
            SqlCommand selCmd = new SqlCommand(selectQ2, con);

            SqlDataReader reader = selCmd.ExecuteReader();

            if (reader.HasRows)
            {
                cmd = new SqlCommand("UPDATE Items SET Quantity='" + qty + "',PurchasePrice='" + purchasePrice +
                    "',SalePrice='" + salePrice + "', Discount='" + discount + "', SellPrice='" + sellingPrice + "' " +
                    "where Category='" + itemCategory + "' and ItemName='" + prodName + "' ", con);
                reader.Close();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Stocks Updated Successfully");
                refreshGridView();
                isUpdated = true;
            }
            else
            {
                con.Close();
                MessageBox.Show("No Records Updated");            
            }
            return isUpdated;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtItemName.Text == "" || txtItemQty.Text == "" || txtDiscount.Text == "" || txtPurchaseAmt.Text == "" || txtSalePrice.Text == "" || txtSellingAmt.Text == "")
            {
                MessageBox.Show("Please Enter all Fields..!!!");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Want to Save..?", "Save / Update", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    updateExistingStock(cboCategory.Text, txtItemName.Text, Convert.ToInt32(txtItemQty.Text), txtDiscount.Text, Convert.ToDouble(txtPurchaseAmt.Text), Convert.ToDouble(txtSalePrice.Text), Convert.ToDouble(txtSellingAmt.Text));
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure to Delete..?", "Delete Stock", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    string grdCategory = stockGridview.CurrentRow.Cells[0].Value.ToString();
                    string grdItemName = stockGridview.CurrentRow.Cells[1].Value.ToString();
                    cmd = new SqlCommand("Delete from Items Where Category='" + grdCategory + "' and ItemName='" + grdItemName + "' ", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Stock Removed Succesfully");
                    con.Close();
                    refreshGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void refreshGridView()
        {
            if (stockGridview.Rows.Count > 1)
            {
                inventory.Rows.Clear();
                con.Open();
                string selectQry1 = "Select Category,ItemName,Quantity,PurchasePrice,SalePrice,Discount,SellPrice from Items";
                SqlDataAdapter da = new SqlDataAdapter(selectQry1, con);
                SqlCommand selCmd = new SqlCommand(selectQry1, con);
                da.Fill(inventory);
                stockGridview.DataSource = inventory;
                con.Close();
            }
            else
            {
                con.Open();
                string selectQry1 = "Select Category,ItemName,Quantity,PurchasePrice,SalePrice,Discount,SellPrice from Items";
                SqlDataAdapter da = new SqlDataAdapter(selectQry1, con);
                SqlCommand selCmd = new SqlCommand(selectQry1, con);
                da.Fill(inventory);
                stockGridview.DataSource = inventory;
                con.Close();
            }
        }
    }
}
