using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdoSQLite.DAL
{
    public class Users : IBindableComponent
    {
        //Members of IBindableComponent
        ISite iSit;
        ControlBindingsCollection dataBindings;
        BindingContext bindingContext = new BindingContext();

        public Users()
        {
            dataBindings = new ControlBindingsCollection(this);
        }
        public event EventHandler Disposed;

        public void Dispose()
        {
            //youre code for disposing
        }

        [Browsable(false)]
        public BindingContext BindingContext
        {
            get { return bindingContext; }
            set { bindingContext = value; }
        }

        [Browsable(false)]
        public ControlBindingsCollection DataBindings
        {
            get { return dataBindings; }
        }

        [Browsable(false)]
        public ISite Site
        {
            get { return iSit; }
            set { iSit = value; }
        }


        [DisplayName("ID")]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}