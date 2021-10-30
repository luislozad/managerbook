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
using ManagerBookFinal.Component.View;

namespace ManagerBookFinal.Window.Popup
{
    public partial class PopupEditR : Form, IData<DataR>, IComponentUI, ISaveState<DataR>
    {
        private DataR Data = new();

        private Action<DataR> HandleActionAdd = null;

        private struct DNote
        {
            public int ID { get; set; }
            public int Position { get; set; }
            public string Title { get; set; }
            public string Note { get; set; }

            public int Width { get; set; }
        }

        public PopupEditR()
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
            SaveAllData();
            HandleActionAdd(Data);
            Close();
        }

        private void SaveAllData()
        {
            Data.SetCapToday((int)CapTotalToday.Value);
            Data.SetPagToday((int)PagTotalToday.Value);
            SaveNotes();
        }

        private void SaveNotes()
        {
            var notes = NotesGrill.Controls.Cast<ItemN>()?.ToList();

            if (notes != null)
            {
                Data.GetNotes().Clear();
            }

            notes?.ForEach(note => Data.GetNotes().Add(note.GetData()));
        }

        public DataR GetData()
        {
            return Data;
        }

        public void SetData(DataR data)
        {
            Data = data;
        }

        public void UpdateUI()
        {
            UpdateTitle();
            UpdateCapTotal();
            UpdatePagTotal();
            UpdateDateStart();
            UpdateHourStart();
            UpdateDateEnd();
            UpdateHourEnd();
            UpdateImageLocation();
            UpdateCapToday();
            UpdatePagToday();
            UpdateBtnReading();
            UpdateNotes();
        }

        private void UpdateNotes()
        {
            int indx = 1;
            Data.GetNotes().ForEach(n => 
            {
                DNote note = new();
                note.ID = n.GetID();
                note.Title = n.GetTitle();
                note.Note = n.GetNote();
                note.Position = indx;
                note.Width = NotesGrill.Width - 35;

                ItemN item = CreateNote(note, ActionUpdateNote);

                NotesGrill.Controls.Add(item);
                
                indx++;
            });
        }

        private void UpdatePagTotal()
        {
            PagTotal.Text = $"{Data.GetPagTotalCompl()}/{Data.GetPagTotal()}";
        }

        private void UpdateCapTotal()
        {
            CapTotal.Text = $"{Data.GetCapTotalCompl()}/{Data.GetCapTotal()}";
        }

        private void UpdateTitle()
        {
            Title.Text = Data.GetTitle();
        }

        private void UpdateDateStart()
        {
            FechaInicioLb.Text = Data.GetDateStart();
        }

        private void UpdateHourStart()
        {
            HoraInicioLb.Text = GetHourStart();
        }

        private void UpdateDateEnd()
        {
            FechaFinalLb.Text = Data.GetDateEnd();
        }

        private void UpdateHourEnd()
        {
            HoraFinalLb.Text = GetHourEnd();
        }

        private void UpdateImageLocation()
        {
            ImageCover.ImageLocation = Data.GetImageLocation();
        }

        private void UpdateCapToday()
        {
            CapTotalToday.Value = Data.GetCapToday();
        }

        private void UpdatePagToday()
        {
            PagTotalToday.Value = Data.GetPagToday();
        }

        private string GetHourEnd()
        {
            if (Data.GetHourEnd() > 0)
            {
                return ConvertHourUnixToNormalize(Data.GetHourEnd());
            }

            return "N/A";
        }

        private string GetHourStart()
        {
            if (Data.GetHourStart() > 0)
            {
                return ConvertHourUnixToNormalize(Data.GetHourStart());
            }

            return "N/A";
        }

        private string ConvertHourUnixToNormalize(long hour)
        {
            return DateTimeOffset
                    .FromUnixTimeSeconds(hour)
                    .ToLocalTime()
                    .ToString("hh:mm tt");
        }

        private void BtnStartReading_Click(object sender, EventArgs e)
        {
            InitReading();
        }

        private void InitReading()
        {
            if (Data.GetHourStart() <= 0)
            {
                StartReading();
            }
            else if (Data.GetHourEnd() <= 0)
            {
                EndReading();
            }
        }

        private void EndReading()
        {
            SetDataEndReading();
            SetStateBtnReading(1, 1);
            UpdateDateEnd();
            UpdateHourEnd();
        }

        private void SetDataEndReading()
        {
            Data.SetDateEnd(DateTime.Now.ToString("dd/MM/yyyy"));
            Data.SetHourEnd(DateTimeOffset.Now.ToUnixTimeSeconds());
        }

        private void StartReading()
        {
            SetStateBtnReading(1, 0);
            SetDataStartReading();
            UpdateDateStart();
            UpdateHourStart();
        }

        private void UpdateBtnReading()
        {
            SetStateBtnReading(Data.GetHourStart(), Data.GetHourEnd());
        }

        private void SetStateBtnReading(long start, long end)
        {
            if (start <= 0 && end <= 0)
            {
                BtnStartReading.Text = "Iniciar lectura";
            }
            else if (start > 0 && end <= 0)
            {
                BtnStartReading.Text = "Finalizar lectura";
            }
            else
            {
                BtnStartReading.Text = "Lectura finalizada";
                BtnStartReading.Enabled = false;
            }
        }

        private void SetDataStartReading()
        {
            Data.SetDateStart(DateTime.Now.ToString("dd/MM/yyyy"));
            Data.SetHourStart(DateTimeOffset.Now.ToUnixTimeSeconds());
        }

        public void OnActionAdd(Action<DataR> handleActionAdd)
        {
            HandleActionAdd = handleActionAdd;
        }

        private void BtnAddNote_Click(object sender, EventArgs e)
        {
            AddNoteGrill();
        }

        private void AddNoteGrill()
        {
            PopupAddN pop = new();
            pop.OnActionAdd(ActionAddNote);

            pop.ShowDialog();
        }

        private void ActionAddNote(DataN dataNote)
        {
            DNote note = new();
            note.ID = -1;
            note.Note = dataNote.GetNote();
            note.Title = dataNote.GetTitle();
            note.Width = NotesGrill.Width - 35;
            note.Position = NotesGrill.Controls.Count + 1;

            ItemN itemNote = CreateNote(note, ActionUpdateNote);

            NotesGrill.Controls.Add(itemNote);
        }

        private ItemN CreateNote(DNote note, Action<ItemN> handleEdit)
        {
            ItemN itemNote = new();

            var data = itemNote.GetData();
            data.SetNote(note.Note);
            data.SetTitle(note.Title);
            data.SetID(note.ID);

            itemNote.OnActionEdit(handleEdit);
            itemNote.SetNumber(note.Position);
            
            if (note.Width > 0)
            {
                itemNote.SetWidth(note.Width);
            }

            itemNote.UpdateUI();

            return itemNote;
        }

        private void ActionUpdateNote(ItemN itemNote)
        {
            PopupAddN pop = new();
            pop.OnActionAdd(ActionEditNote);

            pop.SetData(itemNote.GetData());

            void ActionEditNote(DataN dataNote)
            {
                var data = itemNote.GetData();
                data.SetNote(dataNote.GetNote());
                data.SetTitle(dataNote.GetTitle());

                itemNote.UpdateUI();
            }

            pop.UpdateUI();

            pop.ShowDialog();
        }
    }
}
