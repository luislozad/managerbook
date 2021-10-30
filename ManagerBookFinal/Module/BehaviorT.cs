using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerBookFinal.Component.View;
using ManagerBookFinal.Interface.BehaviorC;
using ManagerBookFinal.Window.Popup;
using ManagerBookFinal.Interface;

namespace ManagerBookFinal.Module
{
    public class BehaviorT<T>: IState, IComponentUI, IData<ContentData>, IBuild
    where
        T : IShowControl<IDataRaw>
    {
        private Content Container = null;
        private ContentData Data = new();

        private T HandleContainer;

        public BehaviorT() { }
        public BehaviorT(Content container)
        {
            Container = container;
        }

        public void SetHandleContainer(T handleContainer)
        {
            HandleContainer = handleContainer;
        }

        public void SetContainer(Content container)
        {
            Container = container;
        }

        private void UpdateContainerDB()
        {
            using CRUD.Temporada temporadaDB = new();
            List<Model.Temporada> temporadaM = temporadaDB.Read();

            List<Card> cardItems = GetCards(temporadaM);

            cardItems.ForEach(card => Data.AddChildren(card));

            Container.SetData(Data);
            Container.UpdateUI();
        }

        private List<Card> GetCards(List<Model.Temporada> temporadaM)
        {
            List<Card> cardItems = new();

            temporadaM.ForEach(temp => 
            {
                DataT dataT = new();
                dataT.SetID(temp.ID);
                dataT.SetTitle(temp.Title);
                dataT.SetLastDate(temp.LastDate);
                dataT.SetImageLocation(temp.ImageLocation);

                cardItems.Add(NewCard(dataT));
            });

            return cardItems;
        }

        private void ActionAdd(Content _view)
        {
            PopupAddT pop = new();
            pop.OnActionAdd(AddChild);

            pop.ShowDialog();
        }

        private void AddChild(DataT data)
        {
            Data.AddChildren(AddNewChildren(data));

            Container.SetData(Data);
            Container.UpdateUI();
        }

        private Card AddNewChildren(DataT data)
        {
            Model.Temporada modelT = SaveDataToDb(data);
            data.SetID(modelT.ID);

            return NewCard(data);
        }

        private Card NewCard(DataT data)
        {
            var (totalBook, totalBookCompl, totalPage, totalPageCompl) = GetMetadataTotalBook(data);

            Card card = new();
            card.SetID(data.GetID());
            card.SetTitle(data.GetTitle());
            card.SetImage(data.GetImageLocation());
            card.SetMetaDataTitle(new string[] { "Libros:", "Paginas:", "Fecha limite:" });
            card.SetMetaDataValue(new string[] { $"{totalBookCompl}/{totalBook}", $"{totalPageCompl}/{totalPage}", data.GetLastDate() });
            card.SetProgress(totalBookCompl, totalBook);
            card.SetClickeable(true);
            card.OnActionClick(HandleContainer.ShowView);
            card.OnActionEdit(ActionEditCard);
            card.OnActionDelete(ActionDeleteCard);
            card.SetDataRaw(data);

            card.UpdateUI();

            return card;
        }

        private (int, int, int, int) GetMetadataTotalBook(DataT data)
        {
            using Database.Context database = new();

            List<Model.Libro> libroM = database.Libros.Where(lb => lb.IDTemporada == data.GetID()).ToList();

            int totalBook = libroM.Count;
            int totalBookCompl = libroM.Sum(lb => 
            {
                var sum = lb.Chapters > 0 ? lb.ChaptersCompl / lb.Chapters : 0;
                return sum;
            });

            int totalPage = libroM.Sum(lb => lb.Pages);
            int totalPageCompl = libroM.Sum(lb => lb.PagesCompl);

            return (totalBook, totalBookCompl, totalPage, totalPageCompl);
        }

        private void ActionDeleteCard(Card card)
        {
            DeleteTempUi(card.GetID());
        }

        private void DeleteTempUi(int id)
        {
            if (Container.GetData().RemoveChildrenByID(id))
            {
                DeleteTempDb(id);
                Container.UpdateUI();
            }
        }

        private void DeleteTempDb(int id)
        {
            using Database.Context database = new();
            Model.Temporada temporadaM = database.Temporadas.Single(temp => temp.ID == id);
            database.Temporadas.Remove(temporadaM);
            database.SaveChanges();
        }

        private void ActionEditCard(Card card)
        {
            CardData cardData = card.GetData();

            PopupAddT pop = new();
            pop.SetData(card.GetDataRaw<DataT>());
            pop.OnActionAdd(ActionUpdateCard);
            pop.UpdateUI();
            pop.ShowDialog();

            void ActionUpdateCard(DataT data)
            {
                cardData.SetTitle(data.GetTitle());
                cardData.SetImageLocation(data.GetImageLocation());
                cardData.SetMetaDataValue(new string[] { "0/0", "0/0", data.GetLastDate() });
                cardData.SetDataRaw(data);

                UpdateDataToDb(data);

                card.UpdateUI();
            }
        }

        private Model.Temporada SaveDataToDb(DataT data)
        {
            using Database.Context database = new();

            Model.Temporada temporada = new() 
            {
                Title = data.GetTitle(),
                ImageLocation = data.GetImageLocation(),
                StartDate = data.GetStartDate(),
                LastDate = data.GetLastDate()
            };

            database.Temporadas.Add(temporada);

            database.SaveChanges();

            return temporada;
        }

        private void UpdateDataToDb(DataT dataT)
        {
            using Database.Context dataDb = new();
            Model.Temporada temporadaOld = dataDb.Temporadas.Find(dataT.GetID());
            temporadaOld.Title = dataT.GetTitle();
            temporadaOld.LastDate = dataT.GetLastDate();
            temporadaOld.ImageLocation = dataT.GetImageLocation();

            dataDb.SaveChanges();
        }

        public void UpdateUI()
        {
            UpdateContainer();
            UpdateContainerDB();
        }

        private void UpdateContainer()
        {
            Container.UpdateUI();
        }

        public void SetData(ContentData data)
        {
            Data = data;
        }

        public ContentData GetData()
        {
            return Data;
        }

        public void Init()
        {
            Container.SetData(Data);
            Container.OnActionEdit(ActionAdd);
        }
    }
}
