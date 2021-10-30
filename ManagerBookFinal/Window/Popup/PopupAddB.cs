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
using ManagerBookFinal.Component.View;

namespace ManagerBookFinal.Window.Popup
{
    public partial class PopupAddB : Form, IUpdateState<PopupAddB, DataB>, IData<DataB>, IComponentUI, ISaveState<DataB>
    {
        private DataB Data = new();
        private Action<DataB> HandleActionAdd = null;
        public PopupAddB()
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
            Data.SetImageLocation(Image.GetImageLocation());
            Data.SetURL(Url.Text);
            Data.SetLastDate(DateLimit.Value.ToString());
            Data.SetCapitulos((int)Capitulos.Value);
            Data.SetCapitulosCompl((int)CapituloCompl.Value);
            Data.SetPaginas((int)Paginas.Value);
            Data.SetPaginasCompl((int)PaginaCompl.Value);

            SaveAllNotes();
        }

        private void SaveAllNotes()
        {
            Data.CleanNotes();
            var items = NotesGrill.Controls.Cast<ItemN>();
            items.ToList().ForEach(HandleSaveNotes);
        }

        private void HandleSaveNotes(ItemN item)
        {
            Data.AddNote(item.GetData());
        }

        public DataB GetData()
        {
            return Data;
        }

        public void OnActionAdd(Action<DataB> handleActionAdd)
        {
            HandleActionAdd = handleActionAdd;
        }

        public void OnActionEdit(Action<PopupAddB> handleEdit)
        {
            //throw new NotImplementedException();
        }

        public void SetData(DataB data)
        {
            Data = data;
        }

        public void UpdateUI()
        {
            UpdateTitle();
            UpdateURL();
            UpdateLastDate();
            UpdateCapitulos();
            UpdateCapitulosCompl();
            UpdatePaginas();
            UpdatePaginasCompl();
            UpdateImage();
            UpdateNotes();
        }

        private void UpdateTitle()
        {
            Title.Text = Data.GetTitle();
        }

        private void UpdateURL()
        {
            Url.Text = Data.GetURL();
        }

        private void UpdateLastDate()
        {
            DateLimit.Text = Data.GetLastDate();
        }

        private void UpdateCapitulos()
        {
            Capitulos.Value = Data.GetCapitulos();
        }

        private void UpdateCapitulosCompl()
        {
            CapituloCompl.Value = Data.GetCapitulosCompl();
        }

        private void UpdatePaginas()
        {
            Paginas.Value = Data.GetPaginas();
        }

        private void UpdatePaginasCompl()
        {
            PaginaCompl.Value = Data.GetPaginasCompl();
        }

        private void UpdateImage()
        {
            Image.SetImage(Data.GetImageLocation());
        }

        private void UpdateNotes()
        {
            var notes = Data.GetNotes();

            notes.ToList().ForEach(HandleNewNote);
        }

        private void SaveURL()
        {
            if (OpenFileDialogURL.ShowDialog() == DialogResult.OK)
            {
                Url.Text = OpenFileDialogURL.FileName;
            }
        }

        private void BtnAddFileURL_Click(object sender, EventArgs e)
        {
            SaveURL();
        }

        private void BtnNewNote_Click(object sender, EventArgs e)
        {
            NewWindowNote();
        }

        private void NewWindowNote()
        {
            PopupAddN pop = new();
            pop.OnActionAdd(HandleNewNote);
            pop.ShowDialog();
        }

        private void HandleNewNote(DataN noteData)
        {
            ItemN item = new();
            item.SetWidth(NotesGrill.Width - 32);
            item.SetID(noteData.GetID());
            item.SetData(noteData);
            item.SetNumber(NotesGrill.Controls.Count + 1);
            item.OnActionEdit(HandleEditNote);
            item.UpdateUI();

            NotesGrill.Controls.Add(item);
        }

        private void HandleEditNote(ItemN itemNote)
        {
            PopupAddN note = new();
            note.SetData(itemNote.GetData());
            note.OnActionAdd(HandleUpdateItem);
            note.UpdateUI();
            note.ShowDialog();

            void HandleUpdateItem(DataN data)
            {
                itemNote.SetData(data);
                itemNote.UpdateUI();
            }
        }

        private void CheckAutoDateLimit_CheckedChanged(object sender, EventArgs e)
        {
            ToggleEnableLastDate();
        }

        private void ToggleEnableLastDate()
        {
            DateLimit.Enabled = CheckAutoDateLimit.Checked;
        }
    }
}
