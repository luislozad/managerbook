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
    public partial class Content : UserControl, IData<ContentData>, IComponentUI, IUpdateState<Content, ContentData>, IEnable
    {
        private ContentData Data = new();
        private Action<Content> HandleActionEdit = null;

        public Content()
        {
            InitializeComponent();
        }

        public ContentData GetData()
        {
            return Data;
        }

        public void OnActionEdit(Action<Content> handleEdit)
        {
            HandleActionEdit = handleEdit;
        }

        public void SetData(ContentData data)
        {
            Data = data;
        }

        public void UpdateUI()
        {
            UpdateTitle();
            UpdateTotal();
            UpdateChildren();
        }

        private void UpdateTitle()
        {
            Title.Text = Data.GetTitle() ?? Title.Text;
        }

        private void UpdateTotal()
        {
            Total.Text = Data.GetChildren().Count.ToString();
        }

        private void UpdateChildren()
        {
            var children = Data.GetChildren();

            if (children.Count > 0)
            {
                UpdateElemetsGrill(children);
            } 
            else
            {
                ElementsGrill.Controls.Clear();
            }
        }

        private void UpdateElemetsGrill(IReadOnlyCollection<Card> children)
        {
            if (children.Count > ElementsGrill.Controls.Count)
            {
                AddNewItemToGrill(children);
            }
            else if(children.Count < ElementsGrill.Controls.Count)
            {
                var itemsR = ElementsGrill.Controls.Cast<Card>();
                
                Card cardRemove = itemsR
                                    .ToList()
                                    .Single(card => !children.Contains(card));

                ElementsGrill.Controls.Remove(cardRemove);
            }
        }

        private void AddNewItemToGrill(IReadOnlyCollection<Card>  children)
        {
            var itemsR = ElementsGrill.Controls.Cast<Card>().ToList();

            if (itemsR.Count > 0)
            {
                ElementsGrill.Controls.Add(children.Last());
            }
            else
            {
                children
                    .ToList()
                    .ForEach(child => ElementsGrill.Controls.Add(child));
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            HandleActionEdit?.Invoke(this);
        }

        public void SetEnable(bool val)
        {
            this.Enabled = val;
        }
    }
}
