using NPI_Details_Collector.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NPI_Details_Collector.Tools
{
    internal class CSV
    {
        public static List<CSVReaderDTO> Read_CSV(string FilePath)
        {
            List<CSVReaderDTO> details = new List<CSVReaderDTO>();
            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string[] columns = sr.ReadLine().Split(",");
                    while (!sr.EndOfStream)
                    {
                        string[] row = sr.ReadLine().Split(",");
                        details.Add(new CSVReaderDTO()
                        {
                            UserWaveID = long.Parse(row[0]),
                            NPI = long.Parse(row[1]),
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return details;
        }
    }
}
