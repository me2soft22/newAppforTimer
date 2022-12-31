using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using System.Data.Sql;
using System.Data.SqlClient;

namespace newAppforTimer
{
    public partial class Form1 : Form
    {
        Dictionary<int, System.Windows.Forms.Timer> _timers = new Dictionary<int, System.Windows.Forms.Timer>();
        int cid = 0;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zoha\source\repos\newAppforTimer\newAppforTimer\Database1.mdf;Integrated Security=True";
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlConnection con,con1;
        SqlDataAdapter da;

        const int weekdayHourPrice = 150;
        const int weekendHourPrice = 200;
        const int addl30MinsPrice = 50;
        const int addl1HourPrice = 100;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            con = new SqlConnection(connectionString);
            //truncatedatabase();
            calcTotalCost(2, 10, 5);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5://START
                    if (!_timers.ContainsKey(e.RowIndex))
                    {
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer.Tick += (ss, ee) => { dataGridView1[4, e.RowIndex].Value = DateTime.Now.ToLongTimeString().ToString(); };
                        timer.Interval = 1000;
                        timer.Start();
                        _timers.Add(e.RowIndex, timer);
                    }
                    break;
                case 0:
                    return;
                case 7://STOP
                    if (_timers.ContainsKey(e.RowIndex))
                    {
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer = _timers[e.RowIndex];
                        timer.Stop();
                        _timers.Remove(e.RowIndex);
                        updateLKONHistoryTable(dataGridView1[1, e.RowIndex].Value.ToString(), Convert.ToDateTime(dataGridView1[4, e.RowIndex].Value), Convert.ToDateTime(dataGridView1[5, e.RowIndex].Value));
                        updatePaymentInfo(dataGridView1[1, e.RowIndex].Value.ToString());
                    }
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPhone.Text = "";
            txtName.Text = "";
            txtCustCount.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPhone.Text = "";
            txtName.Text = "";
            txtCustCount.Text = "";
        }

        [Obsolete]
        private void btnStart_Click(object sender, EventArgs e)
        {
            String curDateTime="";
            if (txtPhone.Text.Length != 10)
            {
                MessageBox.Show("Maximum 10 numbers Allowed....!");
            }
            else if (txtPhone.Text == "" || txtName.Text == "" || txtCustCount.Text == "") {
                MessageBox.Show("Please Enter all the fields.");
            } else {
                int rCount = dataGridView1.Rows.Count;
                //MessageBox.Show("before add row: " + rCount.ToString());
                curDateTime = DateTime.Now.ToLongTimeString();
                dataGridView1.Rows.Add(rCount, txtPhone.Text, txtName.Text, txtCustCount.Text, DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongTimeString());
                bool isSuccess = insertIntoLKONDatabase(txtPhone.Text, txtName.Text, txtCustCount.Text, curDateTime);
                if (!isSuccess)
                {
                    updateIntoLKONDatabase(txtPhone.Text, txtName.Text, txtCustCount.Text, curDateTime);
                }
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Tick += (ss, ee) => { dataGridView1[5, rCount].Value = DateTime.Now.ToLongTimeString(); };
                timer.Interval = 1000;
                timer.Start();
                //MessageBox.Show("before add timer: " + cid.ToString());
                _timers.Add(rCount, timer);

                txtPhone.Text = "";
                txtName.Text = "";
                txtCustCount.Text = "";
            }

        }

        [Obsolete]
        private bool insertIntoLKONDatabase(string custPhone, string custName, string custCount, string curDateTime)
        {
            bool isInserted = false;
            con.Open();
            cmd = new SqlCommand("INSERT INTO Customer (PhoneNumber,Name,Noofvisit,LastVisit) VALUES(@PhoneNumber,@Name,@NoofVisit,@LastVisit)", con);
            cmd1 = new SqlCommand("INSERT INTO History (PhoneNumber,NumberOfKids,InDate,StartTime,EndTime,HoursPlayed) VALUES(@PhoneNumber,@NumberOfKids,@InDate,@StartTime,@EndTime,@HoursPlayed)", con);
            cmd.Parameters.AddWithValue("@PhoneNumber", custPhone);
            cmd1.Parameters.AddWithValue("@PhoneNumber", custPhone);
            cmd1.Parameters.AddWithValue("@NumberOfKids", custCount);
            cmd1.Parameters.AddWithValue("@InDate", DateTime.Now.ToShortDateString());
            cmd1.Parameters.AddWithValue("@StartTime", curDateTime);
            cmd1.Parameters.AddWithValue("@EndTime", curDateTime);
            cmd1.Parameters.AddWithValue("@HoursPlayed", curDateTime);
            cmd.Parameters.AddWithValue("@Name", custName);

            string selectQry1 = "Select * from Customer where PhoneNumber=@PhoneNumber";
            SqlDataAdapter da = new SqlDataAdapter(selectQry1, con);
            SqlCommand selVisitCmd = new SqlCommand(selectQry1, con);

            selVisitCmd.Parameters.AddWithValue("@PhoneNumber", custPhone);
            SqlDataReader reader = selVisitCmd.ExecuteReader();
            int act_Novisit=0;
            if (!reader.HasRows)
            {
                cmd.Parameters.AddWithValue("@Noofvisit", act_Novisit+1);
                cmd.Parameters.AddWithValue("@LastVisit", DateTime.Now);
                reader.Close();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                //cmd.Connection.Close();
                //selLvisitCmd.Connection.Close();
                //selVisitCmd.Connection.Close();
                con.Close();
                MessageBox.Show("Records Inserted Successfully");
                isInserted = true;
            }
            else
            {
                con.Close();
            }
            return isInserted;
        }

        private bool updateIntoLKONDatabase(string custPhone, string custName, string custCount, string curDateTime)
        {
            bool isUpdated = false;
            con.Open();
            int noOfVisit=0;
            string lastVisittime="";
            string selectQ1 = "Select * from Customer where PhoneNumber='" + custPhone + "' ";
            SqlDataAdapter da = new SqlDataAdapter(selectQ1, con);
            SqlCommand selCmd = new SqlCommand(selectQ1, con);

            SqlDataReader rdr = selCmd.ExecuteReader();
            int act_Novisit = 0;
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    string tempVisit = rdr.GetInt32(3).ToString();
                    if (tempVisit != null)
                    {
                        act_Novisit = Convert.ToInt32(tempVisit);
                        {
                            noOfVisit = act_Novisit + 1;
                        }
                    }
                    else
                    {
                        noOfVisit = act_Novisit;
                    }
                    string templastv = rdr.GetDateTime(4).ToString();
                    if (templastv != null)
                    {
                        lastVisittime = DateTime.Now.ToString();
                    }
                    else
                    {
                        lastVisittime = DateTime.Now.ToString();
                    }
                }
                rdr.Close();
                cmd1 = new SqlCommand("UPDATE Customer SET Noofvisit='"+ noOfVisit + "',LastVisit='"+ lastVisittime + "' where PhoneNumber='" + custPhone + "' ", con);
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Records Updated Successfully");
                isUpdated = true;
            }
            else
            {
                MessageBox.Show("No Records Updated");
            }
            return isUpdated;
        }

        private bool updateLKONHistoryTable(string custPhone, DateTime startTime, DateTime endTime)
        {
            bool isUpdated = false;
            con.Open();
            TimeSpan timeDiff = Convert.ToDateTime(endTime) - Convert.ToDateTime(startTime);
            var TotalHours = String.Format("{0}:{1}:{2}", timeDiff.Hours, timeDiff.Minutes, timeDiff.Seconds);
            cmd1 = new SqlCommand("UPDATE History SET StartTime='" + startTime.ToString() + "',endTime='" + endTime.ToString() + "', HoursPlayed='"+TotalHours+"'  where PhoneNumber='" + custPhone + "' and InDate='" + DateTime.Now.ToShortDateString() + "' ", con);
            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Records Updated Successfully");
            isUpdated = true;
            return isUpdated;
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int diffSec = Convert.ToInt32((Convert.ToDateTime(row.Cells["gColTimer"].Value) - Convert.ToDateTime(row.Cells["gColSTime"].Value)).TotalSeconds);
                int diffMin = Convert.ToInt32((Convert.ToDateTime(row.Cells["gColTimer"].Value) - Convert.ToDateTime(row.Cells["gColSTime"].Value)).TotalMinutes);
                row.Cells["gColTotalTime"].Value = diffSec.ToString();
                if (Convert.ToInt32(row.Cells["gColTotalTime"].Value) > 50)
                {
                    row.Cells["gColTotalTime"].Style.ForeColor = Color.White;
                    row.Cells["gColTotalTime"].Style.BackColor = Color.Red;
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only Numbers allowed");
                txtPhone.Text = "";
            }
        }

        private void truncatedatabase()
        {
            con.Open();
            string query1 = "TRUNCATE TABLE Customer";
            string query2 = "TRUNCATE TABLE History";
            cmd = new SqlCommand(query1, con);
            cmd1 = new SqlCommand(query2, con);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();
        }

        private void updatePaymentInfo(string custPhone) {
            con.Open();
            bool isUpdated = false;
            Double totalValue = 0.0;
            string qry = "Select * from History where PhoneNumber='" + custPhone + "' and InDate='" + DateTime.Now.ToShortDateString() + "' ";
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            SqlCommand selCmd = new SqlCommand(qry, con);
            SqlDataReader rdr = selCmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    string tempHours = rdr.GetInt32(3).ToString();
                    string[] Separate = tempHours.Split(':');
                    int hour = Convert.ToInt32(Separate[0]);
                    int mins = Convert.ToInt32(Separate[1]);
                    int secs = Convert.ToInt32(Separate[2]);
                    totalValue = calcTotalCost(hour, mins, secs);
                }
            }
            rdr.Close();
            cmd = new SqlCommand("UPDATE History SET TotalAmount='" + totalValue + "' where PhoneNumber='" + custPhone + "' and InDate='" + DateTime.Now.ToShortDateString() + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Records Updated Successfully");
            isUpdated = true;
        }

        private Double calcTotalCost(int hr, int min, int ss)
        {
            Double hourlyCost = 0.0;
            Double CalcTotalCost = 0.0;
            var date = DateTime.Now;
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                hourlyCost = weekendHourPrice;
            }
            else
            {
                hourlyCost = weekdayHourPrice;
            }
            if (hr == 1) {
                CalcTotalCost = CalcTotalCost + (1 * hourlyCost);
            }else if(hr > 1)
            {
                CalcTotalCost = CalcTotalCost + (1 * hourlyCost) + ((hr - 1) * addl1HourPrice);
            }
            if(min < 59)
            {
                if (hr < 1)
                {
                    CalcTotalCost = CalcTotalCost + hourlyCost;
                }
            }
            if(hr>=1 && min <= 40)
            {
                if(min > 11)
                {
                    CalcTotalCost = CalcTotalCost + addl30MinsPrice;
                }
            }
            else if(hr>=1 && min >= 40 && min <= 59)
            {
                CalcTotalCost = CalcTotalCost + addl1HourPrice;
            }
            return CalcTotalCost;
        }
    }

}

