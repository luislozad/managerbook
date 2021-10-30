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

namespace ManagerBookFinal.Window.Popup
{
    public partial class PopupAddN : Form, IUpdateState<PopupAddN, DataN>, IData<DataN>, IComponentUI, ISaveState<DataN>, IObjectID
    {

        private DataN Data = new();
        private Action<DataN> HandleActionAdd = null;

        private int ID = -1;

        public PopupAddN()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ConfigButtons();
        }

        private void ConfigButtons()
        {
            BtnCancelAdd.OnActionClickAdd(HandleSaveSate);
            BtnCancelAdd.OnActionClickCancel(() => Close());
        }

        private void HandleSaveSate()
        {
            SaveAllData();
            HandleActionAdd?.Invoke(Data);
            Close();
        }

        private void SaveAllData()
        {
            Data.SetTitle(Title.Text);
            Data.SetNote(Note.Text);
        }

        public DataN GetData()
        {
            return Data;
        }

        public void OnActionAdd(Action<DataN> handleActionAdd)
        {
            HandleActionAdd = handleActionAdd;
        }

        public void OnActionEdit(Action<PopupAddN> handleEdit)
        {
            //throw new NotImplementedException();
        }

        public void SetData(DataN data)
        {
            Data = data;
        }

        public void UpdateUI()
        {
            UpdateTitle();
            UpdateNote();
        }

        private void UpdateTitle()
        {
            Title.Text = Data.GetTitle();
        }

        private void UpdateNote()
        {
            Note.Text = Data.GetNote();
        }

        public void SetID(int id)
        {
            ID = id;
        }

        public int GetID()
        {
            return ID;
        }
    }
}
