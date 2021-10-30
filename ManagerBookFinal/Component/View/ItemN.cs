using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerBookFinal.Interface;
using ManagerBookFinal.Module;

namespace ManagerBookFinal.Component.View
{
    public partial class ItemN : UserControl, IObjectID, IData<DataN>, IUpdateState<ItemN, DataN>, IComponentUI
    {
        private int ID = -1;
        private DataN Data = new();
        private Action<ItemN> HandleActionEdit = null;
        public ItemN()
        {
            InitializeComponent();
        }

        public void SetNumber(int num)
        {
            Number.Text = $"#{num}";
        }

        public string GetTitle()
        {
            return Title.Text;
        }

        public int GetNumber()
        {
            if (int.TryParse(Number.Text[1..], out int num))
            {
                return num;
            }

            return -1;
        }

        public void SetID(int id)
        {
            ID = id;
        }

        public int GetID()
        {
            return ID;
        }

        private void BtnEditNote_Click(object sender, EventArgs e)
        {
            HandleActionEdit(this);
        }

        public void SetData(DataN data)
        {
            Data = data;
        }

        public DataN GetData()
        {
            return Data;
        }

        public void OnActionEdit(Action<ItemN> handleEdit)
        {
            HandleActionEdit = handleEdit;
        }

        public void UpdateUI()
        {
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            Title.Text = Data.GetTitle();
        }

        public void SetWidth(int w)
        {
            Width = w;
        }
    }
}
