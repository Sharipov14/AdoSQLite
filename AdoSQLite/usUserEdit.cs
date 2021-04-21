using AdoSQLite.DAL;
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
    public partial class usUserEdit : UserControl
    {
        private Users user;

        public DAL.Users User { get => user; set { user = value; bind(); } }

        private void bind()
        {
            if (user != null)
            {
                txtName.DataBindings.Clear();
                txtName.DataBindings.Add("Text", user, "Name");
                txtUserName.DataBindings.Clear();
                txtUserName.DataBindings.Add("Text", user, "UserName");
                dtpDate.DataBindings.Clear();
                dtpDate.DataBindings.Add("Value", user, "Date");
            }
        }

        public usUserEdit()
        {
            InitializeComponent();
        }
    }
}
