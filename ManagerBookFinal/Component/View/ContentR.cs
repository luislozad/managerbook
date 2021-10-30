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
    public partial class ContentR : 
        UserControl, 
        IData<ContentData>, 
        IComponentUI, 
        IUpdateState<Content, ContentData>, 
        IEnable,
        IProcess
    {
        private ContentData Data = new();

        private Action<int> HandleCompleteProcess = null;

        private bool Reset = false;

        public struct DataReading
        {
            public string Start { get; set; }
            public string End { get; set; }

            public void Clear()
            {
                Start = null;
                End = null;
            }
        }

        private DataReading DataReadingContent;

        private Action<DataReading, IEnable> HandleActionReading = null;

        public ContentR()
        {
            InitializeComponent();
        }

        public ContentData GetData()
        {
            return Data;
        }

        public void SetDataReading(DataReading dataReading)
        {
            DataReadingContent = dataReading;
        }

        public DataReading GetDataReading()
        {
            return DataReadingContent;
        }

        public void OnCreateReading(Action<DataReading, IEnable> handleReading)
        {
            HandleActionReading = handleReading;
        }

        public void OnActionEdit(Action<Content> handleEdit)
        {
            ContentMain.OnActionEdit(handleEdit);
        }

        public void SetData(ContentData data)
        {
            Data = data;
        }

        public void SetEnable(bool val)
        {
            ContainerControlReading.Enabled = val;
        }

        public void UpdateUIContainer()
        {
            UpdateConfirmReset();
            ContentMain.UpdateUI();
        }

        public void UpdateUI()
        {
            UpdateTitle();
            UpdateControlReading();
            UpdateContainerReading();
        }

        private void UpdateConfirmReset()
        {
            if (DataReadingContent.Start != null && DataReadingContent.End != null && Reset == false)
            {
                Reset = true;
                ResetStateReading();
            }
            else if(DataReadingContent.Start == null)
            {
                Reset = false;
            }
        }

        private void UpdateContainerReading()
        {
            if (DataReadingContent.Start != null && DataReadingContent.End == null && Data.GetChildren().Count > 0)
            {
                ContentMain.SetEnable(true);
            }
            else
            {
                ContentMain.SetEnable(false);
            }
        }

        private void UpdateControlReading()
        {
            UpdateReadingDatePicker();
            UpdateReadingBtn();
        }

        private void UpdateReadingDatePicker()
        {
            DatePickerStart();
            DatePickerEnd();
        }

        private void DatePickerEnd()
        {
            if (DataReadingContent.End != null)
            {
                FechaFinLectura.Text = DataReadingContent.End;
                FechaFinLectura.Enabled = false;
            } 
            else if (Data.GetChildren().Count > 0)
            {
                FechaFinLectura.Text = DateTime.Now.ToString();
                FechaFinLectura.Enabled = true;
            }
            else if(Data.GetChildren().Count <= 0)
            {
                FechaFinLectura.Text = DateTime.Now.ToString();
                FechaFinLectura.Enabled = false;
            }
        }

        private void DatePickerStart()
        {
            if (DataReadingContent.Start != null)
            {
                FechaInicioLectura.Text = DataReadingContent.Start;
                FechaInicioLectura.Enabled = false;
            }
            else if (Data.GetChildren().Count > 0)
            {
                FechaInicioLectura.Text = DateTime.Now.ToString();
                FechaInicioLectura.Enabled = true;
            }
            else if (Data.GetChildren().Count <= 0)
            {
                FechaInicioLectura.Text = DateTime.Now.ToString();
                FechaInicioLectura.Enabled = false;
            }
        }

        private void UpdateReadingBtn()
        {
            if (DataReadingContent.End != null)
            {
                BtnCreateRead.Text = "Temporada finalizada";
                BtnCreateRead.Enabled = false;
                BtnResetReading.Enabled = true;
            }
            else if(DataReadingContent.Start == null && Data.GetChildren().Count > 0)
            {
                BtnCreateRead.Text = "Crear temporada";
                BtnCreateRead.Enabled = true;
                BtnResetReading.Enabled = false;
            }
            else if (DataReadingContent.Start != null)
            {
                BtnCreateRead.Text = "Finalizar temporada";
                BtnCreateRead.Enabled = true;
                BtnResetReading.Enabled = false;
            }
            else if (Data.GetChildren().Count <= 0)
            {
                BtnCreateRead.Text = "Aun no hay libros";
                BtnCreateRead.Enabled = false;
                BtnResetReading.Enabled = false;
            }
        }

        public void AddChildren(Card card)
        {
            ContentMain.GetData().AddChildren(card);
        }

        public void ClearChildren()
        {
            ContentMain.GetData().CleanChildren();
        }

        private void UpdateTitle()
        {
            ContentMain.GetData().SetTitle(Data.GetTitle());
            ContentMain.UpdateUI();
        }

        private void BtnCreateRead_Click(object sender, EventArgs e)
        {
            UpdateConfirmReset();
            NewStateReading();
            UpdateControlReading();
            CompleteProcess();
        }

        private void NewStateReading()
        {
            SaveDateRead();
            HandleActionReading?.Invoke(DataReadingContent, ContentMain);
        }

        private void SaveDateRead()
        {
            if (DataReadingContent.Start == null)
            {
                DataReadingContent.Start = DateTime.Parse(FechaInicioLectura.Value.ToString()).ToString("dd/MM/yyyy");
            }
            else if (DataReadingContent.End == null)
            {
                DataReadingContent.End = DateTime.Parse(FechaFinLectura.Value.ToString()).ToString("dd/MM/yyyy");
            }
        }

        private void BtnResetReading_Click(object sender, EventArgs e)
        {
            ResetStateReading();
        }

        private void CompleteProcess()
        {
            if (Reset == false && DataReadingContent.Start != null && DataReadingContent.End != null)
            {
                HandleCompleteProcess?.Invoke(GetData().GetID());
            }
        }

        private void ResetStateReading()
        {
            Reset = true;
            DataReadingContent.Clear();
            ClearChildren();
            UpdateUI();
        }

        public void OnComplete(Action<int> handleComplete)
        {
            HandleCompleteProcess = handleComplete;
        }
    }
}
