using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerBookFinal.Component.View;
using ManagerBookFinal.Interface;
using ManagerBookFinal.Interface.BehaviorC;
using ManagerBookFinal.Module.Database;
using ManagerBookFinal.Window.Popup;

namespace ManagerBookFinal.Module
{
    public class BehaviorR : IComponentUI, IData<ContentData>, IEnable, IBuild, IObjectID
    {
        private int ID = -1;
        private ContentData Data = new();
        private ContentR Container = null;

        private ContentR.DataReading DataReadingContent;

        public ContentData GetData()
        {
            return Data;
        }

        private void ActionAdd(Content ctx)
        {
            PopupAddR pop = new();
            Data.GetChildren().ToList().ForEach(card => 
            {
                pop.GetData().GetListBooks().Add(card.GetDataRaw<DataB>());
            });
            pop.OnActionAdd(NewReading);
            pop.UpdateUI();

            pop.ShowDialog();
        }

        private void NewReading(DataListB data)
        {
            Card card = NewCard(data.GetSelectedItem());

            Container.AddChildren(card);

            Container.UpdateUIContainer();
        }

        private Card NewCard(DataB data)
        {
            Card card = new();
            card.OnActionEdit(StartNewReading);
            CardData cardData = card.GetData();
            cardData.SetID(data.GetID());
            cardData.SetImageLocation(data.GetImageLocation());
            cardData.SetTitle(data.GetTitle());


            DataR dataReading = new();
            dataReading.SetImageLocation(data.GetImageLocation());
            dataReading.SetTitle(data.GetTitle());
            dataReading.SetLink(data.GetURL());
            dataReading.SetLastDateLimit(data.GetLastDate());
            dataReading.SetCapTotal(data.GetCapitulos());
            dataReading.SetPagTotal(data.GetPaginas());
            dataReading.SetPagTotalCompl(data.GetPaginasCompl());
            dataReading.SetCapTotalCompl(data.GetCapitulosCompl());
            dataReading.SetDateLastReading(data.GetLastReadingDate());

            dataReading.SetPagByDay(data.GetPagByDay());
            dataReading.SetLastDateSystem(data.GetLastDateSystem());
            dataReading.SetStartDate(data.GetStartDate());
            dataReading.SetHourByDay(data.GetHourByDay());

            BuildMetaData(card, dataReading);

            card.SetProgress(data.GetCapitulosCompl(), data.GetCapitulos());

            cardData.SetDataRaw(dataReading);

            UpdateCardToDb(card, dataReading);

            card.UpdateUI();

            return card;
        }

        private void StartNewReading(Card card)
        {
            PopupEditR pop = new();

            DataR data = card.GetDataRaw<DataR>();

            pop.SetData(data);

            pop.OnActionAdd(ActionUpdateReading);

            pop.UpdateUI();
            pop.ShowDialog();

            void ActionUpdateReading(DataR data)
            {
                UpdateUICard(card, data);
                UpdateCardToDb(card, data);
            }
        }

        private void UpdateCardToDb(Card card, DataR data)
        {
            using Context database = new();

            var modelReading = database.Lecturas.SingleOrDefault(read => read.ID == data.GetID());

            if (modelReading != null)
            {
                UpdateReading(card, data);
            }
            else
            {
                SaveReading(card, data);
            }
        }

        private void SaveReading(Card card, DataR data)
        {
            using Context database = new();

            Model.Lecturas reading = new();

            reading.IDLibro = card.GetID();
            reading.IDTemporadaLectura = Container.GetData().GetID();
            reading.FechaInicial = data.GetDateStart();
            reading.FechaFinal = data.GetDateEnd();
            reading.HoraFinal = data.GetHourEnd();
            reading.HoraInicial = data.GetHourStart();
            reading.CapitulosDeHoy = data.GetCapToday();
            reading.PaginasDeHoy = data.GetPagToday();

            reading.NotaLecturas = new();

            var libro = database.Libros.SingleOrDefault(book => book.ID == card.GetID());

            if (libro != null)
            {
                libro.Notes = new();

                data
                    .GetNotes()
                    .ForEach(note =>
                    {
                        Model.Nota modelNota = new();
                        modelNota.Title = note.GetTitle();
                        modelNota.Note = note.GetNote();

                        libro
                            .Notes
                            .Add(modelNota);

                        database.SaveChanges();

                        note.SetID(modelNota.ID);
                    });

                libro.Notes.ForEach(note => reading.NotaLecturas.Add(new Model.NotaLectura { IDNota = note.ID }));
            }

            database.Lecturas.Add(reading);

            database.SaveChanges();

            data.SetID(reading.ID);
        }

        private void UpdateReading(Card card, DataR data)
        {
            using Context database = new();

            var readingM = database.Lecturas.Single(read => read.ID == data.GetID());

            readingM.CapitulosDeHoy = data.GetCapToday();
            readingM.FechaFinal = data.GetDateEnd();
            readingM.FechaInicial = data.GetDateStart();
            readingM.HoraFinal = data.GetHourEnd();
            readingM.HoraInicial = data.GetHourStart();
            readingM.PaginasDeHoy = data.GetPagToday();

            UpdateReadingNotes(card, readingM, data);

            database.SaveChanges();
        }

        private void UpdateReadingNotes(Card card, Model.Lecturas modelReading, DataR data)
        {
            using Context database = new();

            var readingNotes = database
                                .NotaLecturas
                                .Where(nota => nota.IDLecturas == modelReading.ID)
                                .OrderBy(nota => nota.ID)
                                .ToList();

            if (data.GetNotes().Count > readingNotes.Count && readingNotes.Count > 0)
            {
                SaveNoteToDb(card, readingNotes, data);
            } 
            else if (data.GetNotes().Count > 0 && data.GetNotes().Count == readingNotes.Count)
            {
                UpdateNoteToDb(card, data);
            }
            else if (data.GetNotes().Count > 0 && readingNotes.Count == 0)
            {
                NewNoteToDb(card, modelReading, data);
            }
        }

        private void NewNoteToDb(Card card, Model.Lecturas modelReading, DataR data)
        {
            using Context database = new();

            modelReading.NotaLecturas = new();

            var libro = database.Libros.SingleOrDefault(lb => lb.ID == card.GetID());

            if (libro != null)
            {
                libro.Notes = new();

                data
                    .GetNotes()
                    .ForEach(nota => 
                    {
                        Model.Nota newNota = new() 
                        {
                            Title = nota.GetTitle(),
                            Note = nota.GetNote()
                        };

                        libro.Notes.Add(newNota);
                        
                        database.SaveChanges();

                        nota.SetID(newNota.ID);
                    });


                libro
                    .Notes
                    .ForEach(nota => 
                    {
                        modelReading.NotaLecturas.Add(new Model.NotaLectura { IDNota = nota.ID });
                    });

                database.SaveChanges();
            }
        }

        private void UpdateNoteToDb(Card card, DataR data)
        {
            using Context database = new();

            var notas = database
                            .Notas
                            .Where(nota => nota.IDBook == card.GetID())
                            .ToList();

            if (notas != null)
            {
                data
                    .GetNotes()
                    .ForEach(nota => 
                    {
                        var notaModel = notas.Single(nt => nt.ID == nota.GetID());
                        notaModel.Title = nota.GetTitle();
                        notaModel.Note = nota.GetNote();
                    });

                database.SaveChanges();
            }
        }

        private void SaveNoteToDb(Card card, List<Model.NotaLectura> readingNotes, DataR data)
        {
            using Context database = new();

            var libroM = database.Libros.SingleOrDefault(lb => lb.ID == card.GetID());
            var readingM = database
                            .Lecturas
                            .Single(read => read.IDTemporadaLectura == Container.GetData().GetID() && read.IDLibro == card.GetID());
            
            var notesData = data.GetNotes();

            var notes = notesData
                            .FindAll(note => readingNotes.SingleOrDefault(noteM => noteM.IDNota == note.GetID()) == null);

            if (libroM != null)
            {
                libroM.Notes = new();
                readingM.NotaLecturas = new();

                notes
                    .ForEach(nota => 
                    {
                        Model.Nota notaM = new() 
                        {
                            Title = nota.GetTitle(),
                            Note = nota.GetNote()
                        };

                        libroM.Notes.Add(notaM);

                        database.SaveChanges();

                        nota.SetID(notaM.ID);
                    });


                libroM
                    .Notes
                    .ForEach(nota => readingM.NotaLecturas.Add(new Model.NotaLectura { IDNota = nota.ID }));

                database.SaveChanges();
            }
        }

        private void UpdateUICard(Card card, DataR data)
        {
            CardData cardData = card.GetData();

            UpdateMetaDataValue(cardData, data);

            cardData.SetDataRaw(data);

            card.SetProgress(data.GetCapTotalCompl(), data.GetCapTotal());

            card.UpdateUI();
        }

        private void UpdateMetaDataValue(CardData cardData, DataR data)
        {
            cardData.SetMetaDataValue(new string[]
            {
                    $"{data.GetCapTotalCompl()}/{data.GetCapTotal()}",
                    $"{data.GetPagTotalCompl()}/{data.GetPagTotal()}",
                    $"{(data.GetPagByDay() > 0 ? data.GetPagByDay() : "N/A")}",
                    $"{(data.GetCapByWeek() > 0 ? data.GetCapByWeek() : "N/A")}",
                    $"{(data.GetHourByDay() > 0 ? data.GetHourByDay() : "N/A")}",
                    $"{data.GetDateEnd() ?? data.GetDateLastReading() ?? "N/A"}",
                    $"{data.GetLastDateLimit() ?? "N/A"}",
                    $"{data.GetLastDateSystem() ?? "N/A"}"
            });
        }

        private void BuildMetaData(Card card, DataR data)
        {
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

            UpdateMetaDataValue(card.GetData(), data);
        }

        public void SetContainer(ContentR container)
        {
            Container = container;
        }

        public void SetData(ContentData data)
        {
            Data = data;
        }

        public void SetEnable(bool val)
        {
            Container.SetEnable(val);
        }

        public void UpdateUI()
        {
            UpdateTitle();
            UpdateContainerDb();
        }

        private void UpdateContainerDb()
        {
            using Context database = new();

            var temporadaReading = database
                                    .TemporadaLecturas
                                    .Where(temp => temp.IDTemporada == GetID())
                                    .OrderBy(temp => temp.ID)
                                    .LastOrDefault();

            if (temporadaReading != null)
            {
                SetDataContainer(temporadaReading);
            }
            else
            {
                ResetDataContainer();
            }
        }

        private void ResetDataContainer()
        {
            ContentR.DataReading dataReading = new();
            Container.SetDataReading(dataReading);
            Container.GetData().SetID(-1);
            //Container.GetData().CleanChildren();
            Container.ClearChildren();
            Container.UpdateUI();
        }

        private void SetDataContainer(Model.TemporadaLectura temporadaReading)
        {
            var dataReading = Container.GetDataReading();

            dataReading.Start = temporadaReading.FechaInicial != "" ? temporadaReading.FechaInicial : null;
            dataReading.End = temporadaReading.FechaFinal != "" ? temporadaReading.FechaFinal : null;

            Container.SetDataReading(dataReading);

            Container.GetData().SetID(temporadaReading.ID > 0 ? temporadaReading.ID : -1);

            Container.ClearChildren();
            
            Container.UpdateUI();

            UpdateContainerMainDb(temporadaReading);
        }

        private void UpdateContainerMainDb(Model.TemporadaLectura temporadaReading)
        {
            using Context database = new();

            var bookReading = database
                                .Lecturas
                                .Where(read => read.IDTemporadaLectura == temporadaReading.ID)
                                .OrderBy(read => read.ID)
                                .ToList();

            var books = bookReading.ConvertAll(bookR => database.Libros.Single(book => book.ID == bookR.IDLibro));


            books.ForEach(book =>
            {
                var lecturasBook = Helper.Lecturas.GetLecturaTrunco(GetID(), book.ID);
                Container.AddChildren(NewCardDb(book, temporadaReading, lecturasBook));
            });

            Container.UpdateUIContainer();
        }

        private Card NewCardDb(Model.Libro book, Model.TemporadaLectura temporadaReading, List<Model.Lecturas> lecturasBook)
        {
            using Context database = new();

            var reading = database.Lecturas.SingleOrDefault(read => read.IDTemporadaLectura == temporadaReading.ID && read.IDLibro == book.ID);

            Card card = new();
            var dataCard = card.GetData();
            dataCard.SetID(book.ID);
            dataCard.SetTitle(book.Title);
            dataCard.SetImageLocation(book.ImageLocation);


            DataR dataR = new();
            dataR.SetID(reading?.ID ?? -1);
            dataR.SetCapTotal(book.Chapters);
            dataR.SetCapTotalCompl(book.ChaptersCompl);
            dataR.SetPagTotal(book.Pages);
            dataR.SetPagTotalCompl(book.PagesCompl);
            dataR.SetLink(book.Url);
            dataR.SetImageLocation(book.ImageLocation);
            dataR.SetCapToday(reading?.CapitulosDeHoy ?? 0);
            dataR.SetPagToday(reading?.PaginasDeHoy ?? 0);
            dataR.SetDateEnd(reading?.FechaFinal);
            dataR.SetDateStart(reading?.FechaInicial);
            dataR.SetHourEnd(reading?.HoraFinal ?? 0);
            dataR.SetHourStart(reading?.HoraInicial ?? 0);
            dataR.SetLastDateLimit(book.LastDate);
            dataR.SetDateLastReading(book.LastReadingDate);
            dataR.SetTitle(book.Title);

            if (lecturasBook.Count > 0)
            {
                dataR.SetLastDateSystem(Helper.Libro.GetDateLastRealBook(lecturasBook, book.ID));
                dataR.SetPagByDay(Helper.Libro.CalcPagByDay(lecturasBook));
                dataR.SetCapByWeek(Helper.Libro.CalcCapByWeek(lecturasBook));
                dataR.SetHourByDay(Helper.Libro.CalcHourByDay(lecturasBook));
            }


            BuildMetaData(card, dataR);

            var noteReading = database
                                .NotaLecturas
                                .Where(nota => nota.IDLecturas == reading.ID)
                                .OrderBy(nota => nota.ID)
                                .ToList();

            if (noteReading.Count > 0)
            {

                var noteBook = noteReading.ConvertAll(noteR => database.Notas.Single(note => note.ID == noteR.IDNota));

                noteBook.ForEach(note =>
                {
                    DataN notaData = new();
                    notaData.SetTitle(note.Title);
                    notaData.SetNote(note.Note);
                    notaData.SetID(note.ID);

                    dataR.GetNotes().Add(notaData);
                });
            }

            card.OnActionEdit(StartNewReading);

            card.SetProgress(dataR.GetCapTotalCompl(), dataR.GetCapTotal());

            card.SetDataRaw(dataR);

            card.UpdateUI();

            return card;
        }

        private void UpdateTitle()
        {
            Container.SetData(Data);
            Container.UpdateUI();
        }

        public void Init()
        {
            Container.OnActionEdit(ActionAdd);
            Container.OnCreateReading(ActionCreateReading);
            Container.OnComplete(ProcessCompleteTemporada);
        }

        private void ProcessCompleteTemporada(int temporadaLecturaID)
        {
            using Context database = new();

            var temporadaLectura = Helper.Lecturas.GetLecturaAll(temporadaLecturaID);

            temporadaLectura
                .ForEach(readingLibro =>
                {
                    var libro = database.Libros.Single(book => book.ID == readingLibro.IDLibro);

                    libro.PagesCompl += readingLibro.PaginasDeHoy;
                    libro.ChaptersCompl += readingLibro.CapitulosDeHoy;
                    libro.LastReadingDate = readingLibro.FechaFinal;

                    database.SaveChanges();
                });
        }

        private void ActionCreateReading(ContentR.DataReading data, IEnable containerMain)
        {
            SetEnableContainerMain(data, containerMain);
            SaveTemporadaReading(data);
        }

        private void SetEnableContainerMain(ContentR.DataReading data, IEnable containerMain)
        {
            if (data.Start != null && data.End == null)
            {
                containerMain.SetEnable(true);
            }
            else
            {
                containerMain.SetEnable(false);
            }
        }

        private void SaveTemporadaReading(ContentR.DataReading data)
        {
            SaveTemporadaReadingToDb(data);
            SetDataReadingContainer(data);
        }

        private void SetDataReadingContainer(ContentR.DataReading data)
        {
            DataReadingContent = data;
        }

        private void SaveTemporadaReadingToDb(ContentR.DataReading data)
        {
            using Context database = new();

            if(data.Start != null && data.End == null)
            {
                SaveDataTemporadaReading(database, data);
            }
            else if(data.Start != null && data.End != null)
            {
                EditDataTemporadaReading(database, data);
            }
        }

        private void EditDataTemporadaReading(Context database, ContentR.DataReading data)
        {
            var temporadaLectura = database.TemporadaLecturas.Single(temp => temp.ID == Container.GetData().GetID());

            if (temporadaLectura.FechaFinal == "" || temporadaLectura.FechaFinal == null)
            {
                temporadaLectura.FechaInicial = data.Start;
                temporadaLectura.FechaFinal = data.End;

                database.SaveChanges();
            }
        }

        private void SaveDataTemporadaReading(Context database, ContentR.DataReading data)
        {
            Model.TemporadaLectura temporadaLectura = new();
            temporadaLectura.IDTemporada = GetID();
            temporadaLectura.FechaInicial = data.Start;
            temporadaLectura.FechaFinal = data.End;

            var save = database.TemporadaLecturas.Add(temporadaLectura);

            database.SaveChanges();

            Container.GetData().SetID(save.Entity.ID);
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
