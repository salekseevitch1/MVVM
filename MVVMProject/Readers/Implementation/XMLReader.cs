using System.Collections.Generic;
using System.IO;
using MVVMProject.Models;
using MVVMProject.Readers.Interfaces;
using Newtonsoft.Json;

namespace MVVMProject.Readers.Implementation
{
    public class XMLReader : IPointReader
    {
        public List<Point> Read(string path)
        {
            // read xml

            return JsonConvert.DeserializeObject<List<Models.Point>>(File.ReadAllText(path));
        }

        public void Write()
        {
            
        }
    }
}