using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using NPI_Details_Collector.Model;
using NPI_Details_Collector.Tools;

namespace NPI_Details_Collector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string? FilePath;
        private List<CSVReaderDTO> details = new();
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
            Microsoft.Win32.OpenFileDialog openFileDialog = new ();
            openFileDialog.DefaultExt = ".csv";
            openFileDialog.Filter = "csv (.csv)|*.csv";
            openFileDialog.InitialDirectory = @"C:\Downloads\";
            openFileDialog.Multiselect = false;
            bool? result = openFileDialog.ShowDialog();
            FilePath = openFileDialog.FileName;
            details = CSV.Read_CSV(FilePath);
            MessageBox.Show("Successfully Loaded CSV","Loading Complete");
        }
        
        private void SampleCSV_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"SampleCSV_Click");
        }
        private void ExportCSV_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"ExportCSV_Click");
        }
        private void GetUserDetail_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"GetUserDetail_Click");
        }
        private void BasicInfoChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"BasicChecked");
        }
        private void BasicInfoUnChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"BasicUnChecked");
        }
        private void AddressInfoChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"AddressChecked");
        }
        private void AddressInfoUnChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"AddressUnChecked");
        }
        private void TaxonomyInfoChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"TaxonomyChecked");
        }
        private void TaxonomyInfoUnChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"TaxonomyUnChecked");
        }
    }
}
