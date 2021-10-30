using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerBookFinal.Component.View;
using ManagerBookFinal.Window.Popup;
using ManagerBookFinal.Module;
using System.Diagnostics;

namespace ManagerBookFinal
{
    public partial class Form1 : Form
    {
        private readonly BehaviorR HandleReadView = new();
        private readonly BehaviorB<BehaviorR> HandleBookView = new();
        private readonly BehaviorT<BehaviorB<BehaviorR>> HandleMainView = new();

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ConfigAllView();
        }

        private void ConfigAllView()
        {
            ConfigBookView();
            ConfigReadView();
            ConfigMainView();
        }

        private void ConfigReadView()
        {
            HandleReadView.SetContainer(ReadView);
            HandleReadView.Init();

            HandleReadView.GetData().SetTitle("Lectura:");
            HandleReadView.UpdateUI();
        }

        private void ConfigBookView()
        {
            HandleBookView.SetContainer(BookView);
            HandleBookView.SetHandleContainer(HandleReadView);
            HandleBookView.SetTab(TabView);
            HandleBookView.Init();

            HandleBookView.GetData().SetTitle("Libros:");
            HandleBookView.UpdateUI();
        }

        private void ConfigMainView()
        {
            HandleMainView.SetContainer(MainView);
            HandleMainView.SetHandleContainer(HandleBookView);
            HandleMainView.Init();

            HandleMainView.GetData().SetTitle("Temporadas:");
            HandleMainView.UpdateUI();
        }
    }
}
