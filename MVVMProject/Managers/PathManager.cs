using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using MVVMProject.Creators.Interfaces;
using MVVMProject.Readers.Interfaces;
using Point = MVVMProject.Models.Point;

namespace MVVMProject.Managers
{
    public class PathManager
    {
        private readonly IPointReader _reader;
        private readonly ICreator _creator;

        public List<Point> Points { get; set; }


        public PathManager(IPointReader reader, ICreator creator)
        {
            _reader = reader;
            _creator = creator;

            Points = _reader.Read(@"D:\Repos\MVVM\MVVMProject\Resources\points.json");
        }


        public void CreatePath(Document document, string elevation)
        {
            using (var tr = new Transaction(document, "Create"))
            {
                tr.Start();

                _creator.Create(Points.ToList(), Convert.ToDouble(elevation));

                tr.Commit();
            }
        }
    }
}