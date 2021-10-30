using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerBookFinal.Interface;
using ManagerBookFinal.Module;

namespace ManagerBookFinal.Window.Popup
{
    public partial class PopupAddR : Form, IData<DataListB>, IComponentUI, ISaveState<DataListB>
    {
        private DataListB Data = new();

        private Action<DataListB> HandleActionAdd;

        public PopupAddR()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            BtnCancelAdd.OnActionClickAdd(ActionAdd);
            BtnCancelAdd.OnActionClickCancel(() => Close());
        }

        private void ActionAdd()
        {
            HandleActionAdd(Data);
            Close();
        }

        public DataListB GetData()
        {
            return Data;
        }

        public void SetData(DataListB data)
        {
            Data = data;
        }

        public void UpdateUI()
        {
            UpdateListBook();
            UpdateNameTemporada();
            UpdateSelectedItem();
        }

        private void UpdateSelectedItem()
        {
            UpdateTitleBook();
            UpdateImageCover();
        }

        private void UpdateTitleBook()
        {
            DataB item = Data.GetSelectedItem();

            if (item != null)
            {
                ListaLibros.SelectedItem = item.GetTitle();
            }
        }

        private void UpdateImageCover()
        {
            DataB item = Data.GetSelectedItem();

            if (item != null)
            {
                ImageCover.ImageLocation = item.GetImageLocation();
            }
        }

        private void UpdateNameTemporada()
        {
            TemporadaNombre.Text = Data.GetNameTemp();
        }

        private void UpdateListBook()
        {
            Data.GetListBooks().ForEach(book =>
            {
                ListaLibros.Items.Add(book.GetTitle());
            });
        }

        private void ListaLibros_SelectedValueChanged(object sender, EventArgs e)
        {
            var box = (ComboBox)sender;
            SaveSelectedItem(box.SelectedItem.ToString());
            UpdateImageCover();
        }

        private void SaveSelectedItem(string title)
        {
            DataB item = Data.GetListBooks().Single(data => data.GetTitle().Equals(title));
            Data.SetSelectedItem(item);
        }

        public void OnActionAdd(Action<DataListB> handleActionAdd)
        {
            HandleActionAdd = handleActionAdd;
        }
    }
}
