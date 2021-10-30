using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerBookFinal.Component.Button
{
    public partial class BtnAdd : UserControl
    {
        private Action HandleCancel = null;
        private Action HandleAdd = null;
        public BtnAdd()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            HandleAdd?.Invoke();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            HandleCancel?.Invoke();
        }

        public void OnActionClickCancel(Action handleCancel)
        {
            HandleCancel = handleCancel;
        }

        public void OnActionClickAdd(Action handleAdd)
        {
            HandleAdd = handleAdd;
        }
    }
}
