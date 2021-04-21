using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoSQLite
{
    public partial class Form1 : Form
    {
        private List<DAL.Users> _list;

        public Form1()
        {
            InitializeComponent();

            _list = new List<DAL.Users>();

            bsUser.DataSource = _list;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _list.Clear();
            List<DAL.Users> list = DAL.SQLiteHelper.GetUsers();
            if (list != null && list.Count > 0)
            {
                _list.AddRange(list);
                bsUser.ResetBindings(false);
            }
        }
    }
}
