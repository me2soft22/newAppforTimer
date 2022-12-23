using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newAppforTimer
{
    public partial class Form1 : Form
    {
        Dictionary<int, System.Windows.Forms.Timer> _timers = new Dictionary<int, System.Windows.Forms.Timer>();
        int cid = 0;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
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
                case 1://STOP
                    if (_timers.ContainsKey(e.RowIndex))
                    {
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer = _timers[e.RowIndex];
                        timer.Stop();
                        _timers.Remove(e.RowIndex);
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
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPhone.Text = "";
            txtName.Text = "";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int rCount = dataGridView1.Rows.Count;
            //MessageBox.Show("before add row: " + rCount.ToString());
            dataGridView1.Rows.Add(rCount, txtPhone.Text, txtName.Text, DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongTimeString());

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += (ss, ee) => { dataGridView1[4, rCount].Value = DateTime.Now.ToLongTimeString(); };
            timer.Interval = 1000;
            timer.Start();
            //MessageBox.Show("before add timer: " + cid.ToString());
            _timers.Add(rCount, timer);

            txtPhone.Text = "";
            txtName.Text = "";
        }
    }
}
