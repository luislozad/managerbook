using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerBookFinal.Component.View;
using ManagerBookFinal.Interface;

namespace ManagerBookFinal.Module
{
    public class ContentData: IObjectID
    {
        private string Title;
        private int ID = -1;
        private List<Card> Children = new();

        public void SetTitle(string title)
        {
            Title = title;
        }

        public string GetTitle()
        {
            return Title;
        }

        public void AddChildren(Card child)
        {
            Children.Add(child);
        }

        public IReadOnlyCollection<Card> GetChildren()
        {
            return Children.AsReadOnly();
        }

        public void CleanChildren()
        {
            Children.Clear();
        }
        public int GetID()
        {
            return ID;
        }

        public void SetID(int id)
        {
            ID = id;
        }

        public bool RemoveChildrenByID(int id)
        {
            List<Card> card = Children.FindAll(c => c.GetID() != id);

            if (card.Count == Children.Count - 1)
            {
                Children = card;
                return true;
            }

            return false;
        }
    }
}
