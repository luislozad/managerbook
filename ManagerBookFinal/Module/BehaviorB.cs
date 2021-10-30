using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerBookFinal.Component.View;
using ManagerBookFinal.Interface.BehaviorC;
using ManagerBookFinal.Window.Popup;
using System;
using ManagerBookFinal.Interface;
using System.Windows.Forms;

namespace ManagerBookFinal.Module
{
    public class BehaviorB<T>: IState, IShowControl<IDataRaw>, ITabControl, IComponentUI, IData<ContentData>, IBuild
    where T: IData<ContentData>, IComponentUI, IEnable, IObjectID
    {
        private Content Container = null;

        private ContentData Data = new();

        private TabControl TabControlMain = null;

        private IDataRaw CurrentTemporada = new DataRaw();

        private T HandleContainer;

        public BehaviorB() { }

        public void ShowView(IDataRaw card)
        {
            SetCurrentTemporada(card);
            SetSelectTabIndex();
            Data.CleanChildren();
            UpdateUI();
            CopyDataToReading();
        }

        private void CopyDataToReading()
        {
            HandleContainer.GetData().CleanChildren();

            Container.GetData().GetChildren().ToList().ForEach(card => 
            {
                Card newCard = new();
                DataB cardData = card.GetDataRaw<DataB>();

                DataB newDataRaw = new();

                newDataRaw.SetID(cardData.GetID());
                newDataRaw.SetTitle(cardData.GetTitle());
                newDataRaw.SetImageLocation(cardData.GetImageLocation());
                newDataRaw.SetCapitulos(cardData.GetCapitulos());
                newDataRaw.SetCapitulosCompl(cardData.GetCapitulosCompl());
                newDataRaw.SetLastReadingDate(cardData.GetLastReadingDate());
                newDataRaw.SetPaginas(cardData.GetPaginas());
                newDataRaw.SetPaginasCompl(cardData.GetPaginasCompl());
                newDataRaw.SetURL(cardData.GetURL());

                newDataRaw.SetCapByWeek(cardData.GetCapByWeek());
                newDataRaw.SetPagByDay(cardData.GetPagByDay());
                newDataRaw.SetHourByDay(cardData.GetHourByDay());

                newDataRaw.SetLastDateSystem(cardData.GetLastDateSystem());

                newDataRaw.SetStartDate(cardData.GetStartDate());
                newDataRaw.SetLastDate(cardData.GetLastDate());

                newCard.SetDataRaw(newDataRaw);

                HandleContainer.GetData().AddChildren(newCard);
            });

            if (Container.GetData().GetChildren().Count > 0)
            {
                HandleContainer.SetEnable(true);
                HandleContainer.SetID(CurrentTemporada.GetID());

                HandleContainer.UpdateUI();
            }
            else
            {
                HandleContainer.SetID(CurrentTemporada.GetID());
                HandleContainer.UpdateUI();
            }

        }

        private void SetCurrentTemporada(IDataRaw card)
        {
            CurrentTemporada = card;
        }

        public void SetHandleContainer(T handleContainer)
        {
            HandleContainer = handleContainer;
        }

        private void SetSelectTabIndex()
        {
            TabControlMain.SelectedIndex = 1;
        }

        public void SetContainer(Content container)
        {
            Container = container;
        }

        void ActionAdd(Content view)
        {
            DataT dataT = CurrentTemporada.GetDataRaw<DataT>();

            PopupAddB pop = new();

            pop.OnActionAdd(AddChild);
            pop.GetData().SetLastDate(dataT.GetLastDate());
            pop.GetData().SetStartDate(dataT.GetStartDate());

            pop.UpdateUI();
            pop.ShowDialog();
        }

        void AddChild(DataB data)
        {
            ContentData contentData = Container.GetData();

            contentData.AddChildren(AddNewChildren(data));

            Container.UpdateUI();
        }

        private void UpdateContainerDB()
        {
            using Database.Context database = new();
            List<Model.Libro> libroM = database.Libros.Where(libro => libro.IDTemporada == CurrentTemporada.GetID()).ToList();

            List<Card> cardItems = GetCards(libroM);

            cardItems.ForEach(card => Container.GetData().AddChildren(card));

            Container.UpdateUI();
        }

        private List<Card> GetCards(List<Model.Libro> libroM)
        {
            using Database.Context database = new();

            var temporadaLectura = Helper.Lecturas.GetTemporadaLecturaIncomplete(CurrentTemporada.GetID());

            List<Card> cardItems = new();

            libroM.ForEach(libro =>
            {
                DataB dataB = new();
                dataB.SetID(libro.ID);
                dataB.SetTitle(libro.Title);
                dataB.SetLastDate(libro.LastDate);
                dataB.SetImageLocation(libro.ImageLocation);
                dataB.SetCapitulos(libro.Chapters);
                dataB.SetPaginas(libro.Pages);
                dataB.SetURL(libro.Url);
                dataB.SetLastReadingDate(libro.LastReadingDate);
                dataB.SetStartDate(libro.StartDate);
                dataB.SetCapitulosCompl(libro.ChaptersCompl);
                dataB.SetPaginasCompl(libro.PagesCompl);

                List<Model.Nota> notas = database.Notas.Where(nt => nt.IDBook == libro.ID).ToList();

                InsertDataReading(dataB);

                notas.ForEach(nota =>
                {
                    DataN data = new();
                    data.SetID(nota.ID);
                    data.SetTitle(nota.Title);
                    data.SetNote(nota.Note);

                    dataB.AddNote(data);
                });

                cardItems.Add(NewCard(dataB));
            });

            return cardItems;
        }

        private void InsertDataReading(DataB dataB)
        {
            var readingLibros = Helper.Lecturas.GetLecturaTrunco(CurrentTemporada.GetID(), dataB.GetID());

            if (readingLibros.Count > 0)
            {
                dataB.SetPagByDay(Helper.Libro.CalcPagByDay(readingLibros));
                dataB.SetCapByWeek(Helper.Libro.CalcCapByWeek(readingLibros));
                dataB.SetHourByDay(Helper.Libro.CalcHourByDay(readingLibros));
                dataB.SetLastDateSystem(Helper.Libro.GetDateLastRealBook(readingLibros, dataB.GetID()));
            }
        }

        private Card AddNewChildren(DataB data)
        {
            Model.Libro modelB = SaveDataToDb(data, CurrentTemporada.GetID());
            data.SetID(modelB.ID);

            return NewCard(data);
        }

        private Model.Libro SaveDataToDb(DataB data, int idParent)
        {
            using Database.Context database = new();

            Model.Temporada temporadaM = database.Temporadas.Single(t => t.ID == idParent);

            List<Model.Nota> notas = new();

            data.GetNotes().ToList().ForEach(nt => notas.Add(new Model.Nota
            {
                Title = nt.GetTitle(),
                Note = nt.GetNote()
            }));

            Model.Libro libroM = new()
            {
                Title = data.GetTitle(),
                ImageLocation = data.GetImageLocation(),
                LastDate = data.GetLastDate(),
                Pages = data.GetPaginas(),
                PagesCompl = data.GetPaginasCompl(),
                Chapters = data.GetCapitulos(),
                ChaptersCompl = data.GetCapitulosCompl(),
                Url = data.GetURL(),
                Notes = notas,
                StartDate = data.GetStartDate()
            };

            temporadaM.BookList = new();

            temporadaM.BookList.Add(libroM);

            database.SaveChanges();

            return libroM;
        }

        private void HandleDeleteCard(Card card)
        {
            DeleteCardUi(card.GetID());
        }

        private void DeleteCardUi(int id)
        {
            if (Container.GetData().RemoveChildrenByID(id))
            {
                DeleteCardDb(id);
                Container.UpdateUI();
            }
        }

        private void DeleteCardDb(int id)
        {
            using Database.Context database = new();
            Model.Libro libro = database.Libros.Single(card => card.ID == id);

            database.Libros.Remove(libro);
            database.SaveChanges();
        }

        private Card NewCard(DataB data)
        {
            Card card = new();
            card.SetID(data.GetID());
            card.SetTitle(data.GetTitle());
            card.SetImage(data.GetImageLocation());
            card.OnActionEdit(HandleEditCard);
            card.OnActionDelete(HandleDeleteCard);

            card.SetMetaDataTitle(new string[]
            {
                "Capitulos:",
                "Paginas:",
                "PagXDia:",
                "CapXSemana:",
                "HorXDia:",
                "Ultima lectura:",
                "Fecha limite:",
                "Fecha Aproximada:"
            });

            card.SetMetaDataValue(new string[]
            {
                $"{data.GetCapitulosCompl()}/{data.GetCapitulos()}",
                $"{data.GetPaginasCompl()}/{data.GetPaginas()}",
                $"{(data.GetPagByDay() > 0 ? data.GetPagByDay() : "N/A")}",
                $"{(data.GetCapByWeek() > 0 ? data.GetCapByWeek() : "N/A")}",
                $"{(data.GetHourByDay() > 0 ? data.GetHourByDay() : "N/A")}",
                $"{data.GetLastReadingDate() ?? "N/A"}",
                $"{data.GetLastDate()}",
                $"{data.GetLastDateSystem() ?? "N/A"}"
            });

            card.SetDataRaw(data);
            card.SetProgress(data.GetCapitulosCompl(), data.GetCapitulos());

            card.UpdateUI();

            return card;
        }

        private void HandleEditCard(Card card)
        {
            PopupAddB pop = new();
            pop.SetData(card.GetDataRaw<DataB>());
            pop.OnActionAdd(HandleUpdateCard);
            pop.UpdateUI();

            pop.ShowDialog();

            void HandleUpdateCard(DataB data)
            {
                CardData cardData = card.GetData();
                cardData.SetTitle(data.GetTitle());
                cardData.SetImageLocation(data.GetImageLocation());

                cardData.SetMetaDataValue(new string[]
                {
                    $"{data.GetCapitulosCompl()}/{data.GetCapitulos()}",
                    $"{data.GetPaginasCompl()}/{data.GetPaginas()}",
                    $"{(data.GetPagByDay() > 0 ? data.GetPagByDay() : "N/A")}",
                    $"{(data.GetCapByWeek() > 0 ? data.GetCapByWeek() : "N/A")}",
                    $"{(data.GetHourByDay() > 0 ? data.GetHourByDay() : "N/A")}",
                    $"{data.GetLastReadingDate() ?? "N/A"}",
                    $"{data.GetLastDate()}",
                    $"{data.GetLastDateSystem() ?? "N/A"}"
                });

                cardData.SetDataRaw(data);
                card.SetProgress(data.GetCapitulosCompl(), data.GetCapitulos());

                UpdateCardDb(data);

                card.UpdateUI();
            }
        }

        private void UpdateCardDb(DataB data)
        {
            using Database.Context dataDb = new();

            UpdateBookDb(data);

            dataDb.SaveChanges();
        }

        private void UpdateBookDb(DataB data)
        {
            using Database.Context database = new();

            Model.Libro libroOld = database.Libros.Single(lb => lb.ID == data.GetID());
            libroOld.Title = data.GetTitle();
            libroOld.LastDate = data.GetLastDate();
            libroOld.ImageLocation = data.GetImageLocation();
            libroOld.Url = data.GetURL();
            libroOld.Chapters = data.GetCapitulos();
            libroOld.ChaptersCompl = data.GetCapitulosCompl();
            libroOld.Pages = data.GetPaginas();
            libroOld.PagesCompl = data.GetPaginasCompl();

            database.SaveChanges();

            SaveNotesDb(data);
        }

        private void SaveNotesDb(DataB data)
        {
            using Database.Context database = new();

            var notas = database.Notas.Where(nota => nota.IDBook == data.GetID()).ToList();

            if (data.GetNotes().Count > notas.Count)
            {
                NewNote(data);
            }
            else
            {
                UpdateNote(data);
            }
        }

        private void UpdateNote(DataB data)
        {
            using Database.Context database = new();

            var notas = database.Notas.Where(nota => nota.IDBook == data.GetID()).ToList();

            data
                .GetNotes()
                .ToList()
                .ForEach(nota =>
                {
                    var currentNota = notas.Single(lastNota => lastNota.ID == nota.GetID());

                    currentNota.Title = nota.GetTitle();
                    currentNota.Note = nota.GetNote();

                    database.SaveChanges();
                });
        }

        private void NewNote(DataB data)
        {
            using Database.Context database = new();

            var libro = database.Libros.Single(book => book.ID == data.GetID());

            libro.Notes = new();

            var newNotas = data.GetNotes().ToList();

            newNotas.ForEach(nota =>
            {

                if (nota.GetID() <= 0)
                {
                    Model.Nota newNota = new()
                    {
                        Title = nota.GetTitle(),
                        Note = nota.GetNote()
                    };

                    libro.Notes.Add(newNota);

                    database.SaveChanges();

                    nota.SetID(newNota.ID);
                }
            });
        }

        public void SetTab(TabControl tabControl)
        {
            TabControlMain = tabControl;
        }

        public void UpdateUI()
        {
            UpdateContainer();
            UpdateContainerDB();
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            var data = CurrentTemporada.GetDataRaw<DataT>();

            string temporada = data.GetTitle();

            if (temporada != null && temporada != "")
            {
                Container.GetData().SetTitle($"{temporada} > Libros:");
                Container.SetEnable(true);
                Container.UpdateUI();
            }
        }

        private void UpdateContainer()
        {
            Container.SetData(Data);
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
            Container.OnActionEdit(ActionAdd);
            //SetDataRawDB();
            CurrentTemporada.SetDataRaw(new DataT());
        }
    }
}
