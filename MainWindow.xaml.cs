using InterstellarApp.Data;
using InterstellarApp.Models;
using System.Windows;
using System.Windows.Controls;

namespace InterstellarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyDbContext _dbContext;
        private readonly UnitOfWork _unitOfWork;
        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new MyDbContext();
            _unitOfWork = new UnitOfWork(_dbContext);
            PopulateDataAsync();
        }

        private async Task AddNewPlanet()
        {
            string planetname = txtName.Text;
            string planetdesc = txtDesc.Text;
            string planetKilom = txtKilom.Text;
            bool result;
            int kilometer;
            result = int.TryParse(planetKilom, out kilometer);

            if (planetname != null && planetdesc != null && result == true)
            {
                Planet planet = new Planet()
                {
                    Name = planetname,
                    Description = planetdesc,
                    Kilometers = kilometer
                };

                await _unitOfWork.PlanetRepo.AddPlanetAsync(planet);
                await _unitOfWork.SaveChangesAsync();
            }

            else
            {
                MessageBox.Show("Pleas fill in all fields");
            }

        }

        private void RePopulateList()
        {
            lstPlanets.Items.Clear();
            PopulateDataAsync();
        }

        private async Task RemovePlanetAsync()
        {
            ListViewItem selected = (ListViewItem)lstPlanets.SelectedItem;
            Planet casted = (Planet)selected.Tag;
            if (casted != null)
            {
                await _unitOfWork.PlanetRepo.RemovePlanetAsync(casted.Id);
                await _unitOfWork.SaveChangesAsync();

            }
        }

        private async void PopulateDataAsync()
        {
            try
            {
                List<Planet> planets = await _unitOfWork.PlanetRepo.GetAllAsync();
                foreach (Planet planet in planets)
                {
                    ListViewItem item = new ListViewItem();
                    item.Content = planet.ToString();
                    item.Tag = planet;
                    lstPlanets.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _dbContext.Dispose();
        }

        private async void btnAddPlanet_Click(object sender, RoutedEventArgs e)
        {
            await AddNewPlanet();
            RePopulateList();
            txtDesc.Text = string.Empty;
            txtKilom.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        private async void btnRemovePlanet_Click(object sender, RoutedEventArgs e)
        {
            await RemovePlanetAsync();
            RePopulateList();
        }

    }
}