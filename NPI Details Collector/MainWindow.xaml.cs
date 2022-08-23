using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using NPI_Details_Collector.Model;
using NPI_Details_Collector.Tools;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;

namespace NPI_Details_Collector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string? FilePath;
        private List<CSVReaderDTO> details = new();
        private List<HCPDetailsDTO> hcpDetails = new();
        private bool AddressStatus = false;
        private bool TaxonomyStatus = false;
        private bool BasicStatus = true;
        private List<CSVWriterDTO> responses = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoadCSV_Click(object sender, RoutedEventArgs e)
        {
            details.Clear();
            Microsoft.Win32.OpenFileDialog openFileDialog = new ();
            openFileDialog.DefaultExt = ".csv";
            openFileDialog.Filter = "CSV Files|*.csv";
            openFileDialog.InitialDirectory = @"C:\Downloads\";
            openFileDialog.Multiselect = false;
            bool? result = openFileDialog.ShowDialog();
            FilePath = openFileDialog.FileName;
            details = CSV.Read_CSV(FilePath);
            ListViewNPI.ItemsSource = details;
        }
        
        private void SampleCSV_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"SampleCSV_Click");
        }
        private void ExportCSV_Click(object sender, RoutedEventArgs e)
        {

            float divi = details.Count / 100.0f;

            foreach(var hcp in hcpDetails)
            {
                string taxonomyDetails = String.Empty;
                Address addressDetails = new Address();
                foreach (var taxonomy in hcp.HCPDetails[0].Taxonomies)
                {
                    if (taxonomy.Primary)
                    {
                        taxonomyDetails = taxonomy.Description;
                    }
                }

                foreach (var address in hcp.HCPDetails[0].Addresses)
                {
                    if (address.AddressPurpose == "LOCATION")
                    {
                        addressDetails = address;
                    }
                }

                CSVWriterDTO hcpDetail = new CSVWriterDTO()
                {
                    UserWaveId = hcp.UserWaveID,
                    NPI = hcp.HCPDetails[0].NPI,
                    FirstName = hcp.HCPDetails[0].UserDetails.FirstName,
                    LastName = hcp.HCPDetails[0].UserDetails.LastName,
                    CertificateLastUpdatedDate = hcp.HCPDetails[0].UserDetails.CertificationDate,
                    Status = hcp.HCPDetails[0].UserDetails.Status == "A" ? "Active" : "InActive",
                    HouseAddress = addressDetails.HouseAddress,
                    StreetAddress = addressDetails.StreetAddress,
                    City = addressDetails.City,
                    State = addressDetails.State,
                    PostalCode = addressDetails.PostalCode,
                    Taxonomy = taxonomyDetails
                };
                this.Dispatcher.Invoke(() =>
                {
                    ProgressLevel.Value = (int)responses.Count / divi;
                });
                responses.Add(hcpDetail);
                if(responses.Count == hcpDetails.Count)
                {

                    using (var writer = new StreamWriter(@$"{Environment.GetEnvironmentVariable("USERPROFILE")}\Downloads\HCPDetails.csv"))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(responses);
                        }
                    }
                    MessageBox.Show($@"Export Complete", "Success");
                }
            };
        }
        private void GetUserDetail_Click(object sender, RoutedEventArgs e)
        {
            hcpDetails.Clear();
            float i = 1.0f;
            float divi = details.Count / 100.0f;
            var client = API.GetHCPDetails();
            Parallel.ForEach(details, new ParallelOptions() { MaxDegreeOfParallelism = 3 }, async index =>
            {
                i = (i + 1) / divi;
                var response = await client.GetAsync(@$"?number={index.NPI.ToString()}&version=2.1");
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<HCPDetailsDTO>(content);
                if (result != null)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        ProgressLevel.Value = (int)hcpDetails.Count / divi;                        
                    });
                    hcpDetails.Add(new HCPDetailsDTO()
                    {
                        UserWaveID = index.UserWaveID,
                        HCPDetails = result.HCPDetails,
                    });
                    if (details.Count == hcpDetails.Count)
                    {
                        MessageBox.Show("Data Import Completed", "Success");
                    }
                }
            });
        }
        private void BasicInfoChecked(object sender, RoutedEventArgs e)
        {
            BasicStatus = true;
        }
        private void BasicInfoUnChecked(object sender, RoutedEventArgs e)
        {
            BasicStatus = false;
        }
        private void AddressInfoChecked(object sender, RoutedEventArgs e)
        {
            AddressStatus = true;
        }
        private void AddressInfoUnChecked(object sender, RoutedEventArgs e)
        {
            AddressStatus = false;
        }
        private void TaxonomyInfoChecked(object sender, RoutedEventArgs e)
        {
            TaxonomyStatus = true;
        }
        private void TaxonomyInfoUnChecked(object sender, RoutedEventArgs e)
        {
            TaxonomyStatus = false;
        }
    }
}
