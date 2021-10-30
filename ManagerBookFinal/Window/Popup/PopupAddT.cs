using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerBookFinal.Module;
using ManagerBookFinal.Interface;

namespace ManagerBookFinal.Window.Popup
{
    public partial class PopupAddT : Form, IUpdateState<PopupAddT, DataT>, IData<DataT>, IComponentUI, ISaveState<DataT>
    {
        private DataT Data = new();
        private Action<DataT> HandleActionAdd = null;
        public PopupAddT()
        {
            InitializeComponent();
            Init();
        }

        public DataT GetData()
        {
            return Data;
        }

        public void OnActionAdd(Action<DataT> handleActionAdd)
        {
            HandleActionAdd = handleActionAdd;
        }

        public void OnActionEdit(Action<PopupAddT> handleEdit)
        {
            //throw new NotImplementedException();
        }

        public void SetData(DataT data)
        {
            Data = data;
        }

        public void UpdateUI()
        {
            UpdateImage();
            UpdateTitle();
            UpdateLastDate();
        }

        private void UpdateImage()
        {
            Image.SetImage(Data.GetImageLocation());
        }

        private void UpdateTitle()
        {
            Title.Text = Data.GetTitle();
        }

        private void UpdateLastDate()
        {
            string dateLast = Data.GetLastDate();

            if (DateTime.TryParse(dateLast, out DateTime result))
            {
                DateLimit.Value = result;
            }
        }

        private void Init()
        {
            ConfigButtons();
        }

        private void ConfigButtons()
        {
            BtnAdd.OnActionClickAdd(HandleSaveSate);
            BtnAdd.OnActionClickCancel(() => Close());
        }

        private void HandleSaveSate()
        {
            SaveAllData();
            HandleActionAdd?.Invoke(Data);
            Close();
        }

        private void SaveAllData()
        {
            Data.SetImageLocation(Image.GetImageLocation());
            Data.SetLastDate(DateLimit.Text);
            Data.SetTitle(Title.Text);
            Data.SetStartDate(Data.GetStartDate() ?? DateTime.Now.ToString("dd/MM/yyyy"));
        }
    }
}
