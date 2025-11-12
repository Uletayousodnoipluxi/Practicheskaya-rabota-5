using System.IO;
using System.Text;

namespace ReportingModule.Export
{
    public class Exporter
    {
        public void ExportToCsv<T>(IEnumerable<T> data, string filePath)
        {
            using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

            var properties = typeof(T).GetProperties();
            var headerRow = string.Join(",", properties.Select(p => p.Name));
            writer.WriteLine(headerRow);

            foreach (var item in data)
            {
                var rowData = string.Join(",", properties.Select(p => p.GetValue(item)));
                writer.WriteLine(rowData);
            }
        }
    }
}
