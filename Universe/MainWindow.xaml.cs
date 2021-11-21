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
using Universe.DatabaseLayer.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Universe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly VesmirContext _context = new VesmirContext();

        private CollectionViewSource vlastnostViewSource;
        private CollectionViewSource galaxieViewSource;

        public MainWindow()
        {
            InitializeComponent();
            
            vlastnostViewSource = (CollectionViewSource)FindResource(nameof(vlastnostViewSource));
            galaxieViewSource = (CollectionViewSource)FindResource(nameof(galaxieViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();

            _context.Vlastnosts.Load();
            _context.Galaxies.Load();
            _context.Planeta.Load();
            _context.VlastnostiPlanets.Load();

            vlastnostViewSource.Source = _context.Vlastnosts.Local.ToObservableCollection();
            galaxieViewSource.Source = _context.Galaxies.Local.ToObservableCollection();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Dispose();
            base.OnClosing(e);
        }

        private void galaxiesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ICollection<Planetum> planetum = new ObservableCollection<Planetum>();

            foreach (var galaxie in galaxiesDataGrid.SelectedItems)
            {
                foreach (var planeta in ((Universe.DatabaseLayer.Model.Galaxie)galaxie).Planeta)
                {
                    planetum.Add(planeta);
                }
            }
            planetsDataGrid.ItemsSource = planetum;
        }

        private void planetsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            st1.Children.Clear();

            if (((DataGrid)sender).SelectedItem == null) return;


            int planeta_id = ((Planetum)((DataGrid)sender).SelectedItem).Id;

            foreach (var item in _context.Vlastnosts.ToList())
            {
                bool result = _context.VlastnostiPlanets.Any(x => x.VlastnostId == item.Id && x.PlanetaId == planeta_id);
                CheckBox chk = new() { Content = item.Nazev, IsChecked = result };
                chk.Checked += this.CheckBoxOnChecked;
                chk.Unchecked += this.CheckBoxOnUnchecked;
                st1.Children.Add(chk);
            }

        }

        private void CheckBoxOnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            if (sender is CheckBox checkBox)
            {
                int planeta_id = ((Planetum)planetsDataGrid.SelectedItem).Id;
                string vlastnost_nazev = checkBox.Content.ToString();

                Vlastnost vlastnost = _context.Vlastnosts.SingleOrDefault(x => x.Nazev == vlastnost_nazev);
                int vlastnost_id = _context.Vlastnosts.Where(x => x.Nazev == vlastnost_nazev).AsNoTracking().FirstOrDefault().Id;

                VlastnostiPlanet vlastnostiPlanet = new VlastnostiPlanet() { PlanetaId = planeta_id, VlastnostId = vlastnost_id };
                _context.VlastnostiPlanets.Add(vlastnostiPlanet);
                int result = _context.SaveChanges();
                planetsDataGrid.Items.Refresh();
            }
        }

        private void CheckBoxOnUnchecked(object sender, RoutedEventArgs routedEventArgs)
        {
            if (sender is CheckBox checkBox)
            {
                int planeta_id = ((Planetum)planetsDataGrid.SelectedItem).Id;
                int vlastnost_id = _context.Vlastnosts.Where(x => x.Nazev == checkBox.Content.ToString()).AsNoTracking().FirstOrDefault().Id;

                VlastnostiPlanet vlastnostiPlanet = _context.VlastnostiPlanets.AsNoTracking().FirstOrDefault(x => x.VlastnostId == vlastnost_id && x.PlanetaId == planeta_id);

                if (vlastnostiPlanet != null)
                {
                    _context.VlastnostiPlanets.Remove(vlastnostiPlanet);
                }
                int result = _context.SaveChanges();
                planetsDataGrid.Items.Refresh();
            }
        }

    }
}

