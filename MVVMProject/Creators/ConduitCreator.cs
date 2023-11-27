using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Point = MVVMProject.Models.Point;

namespace MVVMProject.Creators
{
    public class ConduitCreator
    {
        private readonly Document _document;

        public ConduitCreator(Document document)
        {
            _document = document;
        }

        public void Create(List<Point> points, double elevation)
        {
            var conduitTypeId = _document.GetDefaultElementTypeId(ElementTypeGroup.ConduitType);

            var levelId = new FilteredElementCollector(_document).OfClass(typeof(Level)).FirstElement().Id;

            points = points.Select(it => new Point { X = it.X, Y = it.Y, Z = elevation }).ToList();

            for (int i = 0; i < points.Count - 1; i++)
            {
                var firstPoint = points[i];
                var secondPoint = points[i + 1];

                Conduit.Create(
                    _document,
                    conduitTypeId,
                    firstPoint.AsXYZ(),
                    secondPoint.AsXYZ(),
                    levelId);
            }
        }
    }
}