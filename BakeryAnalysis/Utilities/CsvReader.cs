using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.Utilities
{
    public class CsvReader
    {
        public IEnumerable<T> ReadFromFile<T>(string fileName, object configuration, Func<IEnumerable<string>, T> mapper)
        {
            var listOfTModels = new List<T>();

            if (fileName != string.Empty)
            {
                using (var reader = new StreamReader(fileName))
                {

                }
            }
            return listOfTModels;
        }
    }
}
