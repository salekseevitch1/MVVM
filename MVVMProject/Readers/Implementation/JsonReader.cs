using System.Collections.Generic;
using System.IO;
using Autodesk.Revit.DB;
using MVVMProject.Readers.Interfaces;
using Newtonsoft.Json;

namespace MVVMProject.Readers.Implementation
{
    public class JsonReader : IPointReader
    {
        public JsonReader()
        {

        }

        public List<Models.Point> Read(string path)
        {
            return JsonConvert.DeserializeObject<List<Models.Point>>(File.ReadAllText(path));
        }

        public void Write()
        {
            var points = new List<XYZ>
            {
                XYZ.BasisX,
                XYZ.BasisY,
                XYZ.BasisZ,
                new XYZ(10, 10, 10)
            };

            var @string = JsonConvert.SerializeObject(points);

            File.WriteAllText(@"C:\Users\salek\OneDrive\Рабочий стол\points1.json", @string);
        }
    }
}

