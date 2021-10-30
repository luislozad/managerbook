using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerBookFinal.Interface;

namespace ManagerBookFinal.Module
{
    public class DataN: IObjectID
    {
        private int ID = -1;
        private string Title, Note;

        public void SetTitle(string title)
        {
            Title = title;
        }

        public string GetTitle()
        {
            return Title;
        }

        public void SetNote(string note)
        {
            Note = note;
        }

        public string GetNote()
        {
            return Note;
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
