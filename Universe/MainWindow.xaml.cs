using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Universe.DatabaseLayer;

namespace Universe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly VesmirContext _vesmirContext = new VesmirContext();

        private CollectionViewSource categoryPlanetPropertiesViewSource;
        private CollectionViewSource categoryGalaxyViewSource;

        public MainWindow()
        {
            InitializeComponent();
            categoryPlanetPropertiesViewSource = (CollectionViewSource)FindResource(nameof(categoryPlanetPropertiesViewSource));
            categoryGalaxyViewSource = (CollectionViewSource)FindResource(nameof(categoryGalaxyViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _vesmirContext.Database.EnsureCreated();
            _vesmirContext.Vlastnosts.Load();
            _vesmirContext.Galaxies.Load();
            categoryPlanetPropertiesViewSource.Source = _vesmirContext.Vlastnosts.Local.ToObservableCollection();
            categoryGalaxyViewSource.Source = _vesmirContext.Galaxies.Local.ToObservableCollection();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _vesmirContext.Dispose();
            base.OnClosing(e);
        }
    }
}
