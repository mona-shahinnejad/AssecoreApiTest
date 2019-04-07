using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common.Helpers
{
    public class CsvHelpers
    {

        public static IEnumerable<T> ReadFileWithoutHeader<T>(TextReader reader, Type map = null) where T : class
        {
            using (var csvReader = new CsvHelper.CsvReader(reader))
            {
                if (map != null)
                    csvReader.Configuration.RegisterClassMap(map);

                csvReader.Configuration.HasHeaderRecord = false;
                csvReader.Configuration.TrimOptions = CsvHelper.Configuration.TrimOptions.Trim;

                return csvReader.GetRecords<T>().ToList();
            }
        }
    }
}
