using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Module
{
    public class DataListB
    {
        private string NameTemp;
        private DataB SelectedItem = null;
        private List<DataB> ListBooks = new();

        public string GetNameTemp()
        {
            return NameTemp;
        }

        public void SetNameTemp(string nameTemp)
        {
            NameTemp = nameTemp;
        }

        public List<DataB> GetListBooks()
        {
            return ListBooks;
        }

        public void SetListBooks(List<DataB> listBooks)
        {
            ListBooks = listBooks;
        }

        public DataB GetSelectedItem()
        {
            return SelectedItem;
        }

        public void SetSelectedItem(DataB item)
        {
            SelectedItem = item;
        }
    }
}
