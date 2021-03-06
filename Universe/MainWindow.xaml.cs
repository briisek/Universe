using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Autofac;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db.Dao;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db.DaoFactory;
using Nielsen.Admosphere.Fw2.DataAccess.Linq2db.Transactions;
using Universe.Entities;
using Universe.Entities.Dao;

namespace Universe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CollectionViewSource vlastnostViewSource;
        private CollectionViewSource galaxieViewSource;
        private readonly IEntitiesSource m_entitiesSource; 
        
        public MainWindow()
        {
            InitializeComponent();

            AutofacInit init = new AutofacInit();
            init.Init();

            m_entitiesSource = AutofacInit.Scope.Resolve<IEntitiesSource>();
            
            
                
                
            vlastnostViewSource = (CollectionViewSource) FindResource(nameof(vlastnostViewSource));
            galaxieViewSource = (CollectionViewSource) FindResource(nameof(galaxieViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrids();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //_context.Dispose();
            base.OnClosing(e);
        }

        #region Planets Properties

        private void BtnAddProperty_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPropertyName.Text))
            {
                return;
            }

            UniverseContext.InsertVlastnost(txtPropertyName.Text);
            RefreshDataGrids();
            
            /*PlanetsDataGrid_SelectionChanged(planetsDataGrid, null);*/
        }

        private void BtnRemoveProperties_Click(object sender, RoutedEventArgs e)
        {
            RemoveProperties();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((DataGrid)sender).SelectedItem == null)
            {
                return;
            }

            Vlastnost vlastnost = ((Vlastnost)((DataGrid)sender).SelectedItem);
            UniverseContext.UpdateVlastnost(vlastnost.Id,vlastnost.Nazev);
            RefreshDataGrids();
        }
        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                RemoveProperties();
            }
        }

        private void RemoveProperties()
        {
            List<Vlastnost> vlastnosts = new();

            foreach (Vlastnost vlastnost in propertiesDataGrid.SelectedItems)
            {
                UniverseContext.DeleteVlastnost(vlastnost);
            }

            RefreshDataGrids();
            /*PlanetsDataGrid_SelectionChanged(planetsDataGrid, null);*/
        }

        private void RefreshDataGrids()
        {
            vlastnostViewSource.Source = m_entitiesSource.GetAllVlastnosts();
            
            galaxieViewSource.Source = new ObservableCollection<Galaxie>(m_entitiesSource.GetAllGalaxies());
            
            propertiesDataGrid.Items.Refresh();
            planetsDataGrid.Items.Refresh();
        }

        #endregion

        #region Galaxies and Planets

        /// <summary>
        /// Load planets from mulitple galaxies.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GalaxiesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*ICollection<Planetum> planetum = new ObservableCollection<Planetum>();

            foreach (Galaxie galaxie in galaxiesDataGrid.SelectedItems)
            {
                foreach (Planetum planeta in ((Universe.DatabaseLayer.Model.Galaxie)galaxie).Planeta)
                {
                    planetum.Add(planeta);
                }
            }
            planetsDataGrid.ItemsSource = planetum;*/
        }

        /// <summary>
        /// Create checkboxes representing planets properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlanetsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*stCheckBoxes.Children.Clear();

            if (((DataGrid)sender).SelectedItem == null)
            {
                return;
            }

            int planetaId = ((Planetum)((DataGrid)sender).SelectedItem).Id;

            foreach (Vlastnost item in _context.Vlastnosts.ToList())
            {
                bool result = _context.VlastnostiPlanets.Any(x => x.VlastnostId == item.Id && x.PlanetaId == planetaId);
                CheckBox chk = new() { Content = item.Nazev, IsChecked = result, Margin = new Thickness(0, 0, 10, 0) };
                chk.Checked += CheckBoxOnChecked;
                chk.Unchecked += CheckBoxOnUnchecked;
                _ = stCheckBoxes.Children.Add(chk);
            }*/
        }

        private void CheckBoxOnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            /*int planetaId = ((Planetum)planetsDataGrid.SelectedItem).Id;
            string vlastnostNazev = ((CheckBox)sender).Content.ToString();

            Vlastnost vlastnost = _context.Vlastnosts.SingleOrDefault(x => x.Nazev == vlastnostNazev);
            int vlastnostId = _context.Vlastnosts.Where(x => x.Nazev == vlastnostNazev).FirstOrDefault().Id;

            VlastnostiPlanet vlastnostiPlanet = new() { PlanetaId = planetaId, VlastnostId = vlastnostId };
            _ = _context.VlastnostiPlanets.Add(vlastnostiPlanet);
            _ = _context.SaveChanges();
            RefreshDataGrids();*/
        }

        private void CheckBoxOnUnchecked(object sender, RoutedEventArgs routedEventArgs)
        {
            /*int planetaId = ((Planetum)planetsDataGrid.SelectedItem).Id;
            int vlastnostId = _context.Vlastnosts.Where(x => x.Nazev == ((CheckBox)sender).Content.ToString()).FirstOrDefault().Id;

            VlastnostiPlanet vlastnostiPlanet = _context.VlastnostiPlanets.FirstOrDefault(x => x.VlastnostId == vlastnostId && x.PlanetaId == planetaId);

            if (vlastnostiPlanet != null)
            {
                _ = _context.VlastnostiPlanets.Remove(vlastnostiPlanet);
            }
            _ = _context.SaveChanges();
            RefreshDataGrids();*/
        }

        private void BtnAddPlanet_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Doplnim");

            /*if (string.IsNullOrEmpty(txtPlanetName.Text))
            {
                return;
            }

            Galaxie galaxy = (Galaxie)galaxiesDataGrid.SelectedItem;
            Planetum planetum = new() { Jmeno = txtPlanetName.Text, Id = _context.Planeta.Max(x => x.Id) + 1, Galaxie = galaxy };
            _ = _context.Planeta.Add(planetum);
            _ = _context.SaveChanges();
            PlanetsDataGrid_SelectionChanged(planetsDataGrid, null);*/
        }

        private void BtnRemovePlanets_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Doplnim");
        }

        #endregion
    }
}