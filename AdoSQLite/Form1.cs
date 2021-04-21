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
        private bool _newUserEdit;


        public Form1()
        {
            InitializeComponent();

            _list = new List<DAL.Users>();

            bsUser.DataSource = _list;
            dataGridView1.AutoGenerateColumns = true;
            usUserEdit1.User = new DAL.Users { Date = DateTime.Now.Date };
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            _list.Clear();
            List<DAL.Users> list = DAL.SQLiteHelper.GetUsers();
            if (list != null && list.Count > 0)
            {
                _list.AddRange(list);
                bsUser.ResetBindings(false);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var user = (DAL.Users)bsUser.Current;
            usUserEdit1.User = user;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            usUserEdit1.User = new DAL.Users { Date = DateTime.Now.Date };
            _newUserEdit = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_newUserEdit)
            {
                DAL.SQLiteHelper.AddUser(usUserEdit1.User);
                _newUserEdit = false;
            }
            else
                DAL.SQLiteHelper.SaveUser(usUserEdit1.User);
            UpdateTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DAL.SQLiteHelper.DeleteUser(id: usUserEdit1.User?.Id ?? 0);
            UpdateTable();
        }
    }
}
