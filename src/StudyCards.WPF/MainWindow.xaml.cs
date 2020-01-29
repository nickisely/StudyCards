using StudyCards.MVVM;
//using StudyCards.Local.Repositories;
//using StudyCards.Local.Services;
//using StudyCards.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudyCards.Quiz;
using StudyCards.Remote;

namespace StudyCards.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ServicesManager? servicesManager;

        public MainWindow()
        {
            InitializeComponent();


            var port = 10987;
            var host = "localhost";

            

            //var categoryService = new CategoryService(new CategoryRepository(new DataContextFactory()));
            //var groupService = new GroupService(new GroupRepository(new DataContextFactory()));
            //var studyCardService = new StudyCardService(new StudyCardRepository(new DataContextFactory()));

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                this.servicesManager = new ServicesManager(host, port);

                this.DataContext = new MainViewModel(servicesManager.CategoryService,
                    servicesManager.GroupService,
                    servicesManager.StudyCardService,
                    new RandomizedQuizFactory());
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.servicesManager?.DisposeAsync().AsTask().Wait();
            base.OnClosing(e);
        }
    }
}
