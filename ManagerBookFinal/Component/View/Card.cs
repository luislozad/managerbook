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
    public partial class Card : 
        UserControl, 
        IComponentUI,  
        IClickable<Card>, 
        IObjectID, 
        IData<CardData>, 
        IUpdateState<Card, CardData>, 
        IDataRaw,
        IDeleteState<Card, CardData>
    {
        private CardData Data = new();
        private Action<Card> HandleUpdateSate = null;
        private Action<Card> HandleDeleteItem = null;
        private Action<Card> HandleActionClick = null;
        private bool Clickeable = false;

        private int ProgressComplVal = 0;
        private int ProgressTotalVal = 0;

        private const float FONT_SIZE = 8F;
        private const string FONT_FAMILY = "Segoe UI";
        public Card()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            UpdateTitle();
            UpdateImage();
            UpdateProgress();
            UpdateMetaData();
        }

        private void UpdateProgress()
        {
            UpdateProgressText();
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            ProgressBar.Value = (ProgressComplVal * 100) / (ProgressTotalVal > 0 ? ProgressTotalVal : 100);
        }

        private void UpdateProgressText()
        {
            ProgressTotal.Text = $"{ProgressComplVal}/{ProgressTotalVal}";
        }

        private void UpdateTitle()
        {
            Title.Text = Data.GeTitle();
        }

        private void UpdateImage()
        {
            Image.ImageLocation = Data.GetImageLocation();
        }

        private void UpdateMetaData()
        {
            ClearMetaData();
            UpdateMetaDataTitle();
            UpdateMetaDataValue();
        }

        private void UpdateMetaDataTitle()
        {
            string[] titles = Data.GetMetaDataTitle();

            for (int i = 0; i < titles.Length; i++)
            {
                Label title = NewLabel(titles[i]);
                title.TextAlign = ContentAlignment.MiddleRight;
                title.Font = new Font(FONT_FAMILY, FONT_SIZE, FontStyle.Bold, GraphicsUnit.Point);
                MetaDataGrill.Controls.Add(title, 0, i + 1);
            }
        }

        private void UpdateMetaDataValue()
        {
            string[] values = Data.GetMetaDataValue();

            for (int i = 0; i < values.Length; i++)
            {
                Label value = NewLabel(values[i]);
                value.TextAlign = ContentAlignment.MiddleLeft;
                value.Font = new Font(FONT_FAMILY, FONT_SIZE, FontStyle.Regular, GraphicsUnit.Point);
                MetaDataGrill.Controls.Add(value, 1, i + 1);
            }
        }

        private void ClearMetaData()
        {
            MetaDataGrill.Controls.Clear();
        }

        private Label NewLabel(string text)
        {
            Label lbl = new();
            lbl.Text = text;
            lbl.AutoSize = false;
            lbl.Dock = DockStyle.Fill;

            return lbl;

        }

        public void SetProgress(int compl, int total)
        {
            ProgressComplVal = compl;
            ProgressTotalVal = total;
        }

        public void SetMetaDataTitle(string[] titles)
        {
            Data.SetMetaDataTitle(titles);
        }

        public void SetMetaDataValue(string[] values)
        {
            Data.SetMetaDataValue(values);
        }
        public void SetTitle(string title)
        {
            Data.SetTitle(title);
        }

        public void SetID(int id)
        {
            Data.SetID(id);
        }

        public int GetID()
        {
            return Data.GetID();
        }

        public void SetImage(string imageLocalation)
        {
            Data.SetImageLocation(imageLocalation);
        }

        public void SetClickeable(bool value)
        {
            if (value)
            {
                Image.Cursor = Cursors.Hand;
            }
            else
            {
                Image.Cursor = Cursors.Default;
            }

            Clickeable = value;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void UpdateState()
        {
            HandleUpdateSate?.Invoke(this);
        }

        public void OnActionClick(Action<IDataRaw> handleAction)
        {
            HandleActionClick = handleAction;
        }

        public void OnActionEdit(Action<Card> handleEdit)
        {
            HandleUpdateSate = handleEdit;
        }

        public void OnActionDelete(Action<Card> handleDelete)
        {
            HandleDeleteItem = handleDelete;
        }

        private void Image_Click(object sender, EventArgs e)
        {
            ActionClick();
        }

        private void ActionClick()
        {
            if (Clickeable)
            {
                HandleActionClick(this);
            }
        }

        public void SetData(CardData data)
        {
            Data = data;
        }

        public CardData GetData()
        {
            return Data;
        }

        public void OnActionClick(Action<Card> handleAction)
        {
            HandleActionClick = handleAction;
        }

        public void SetDataRaw<D>(D dataRaw) where D : IObjectID
        {
            Data.SetDataRaw(dataRaw);
        }

        public D GetDataRaw<D>() where D : IObjectID
        {
            return Data.GetDataRaw<D>();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void DeleteItem()
        {
            HandleDeleteItem?.Invoke(this);
        }
    }
}
