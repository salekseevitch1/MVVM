using System.Collections.Generic;
using Autodesk.Revit.DB;
using MVVMProject.Creators.Interfaces;
using Point = MVVMProject.Models.Point;

namespace MVVMProject.Creators.Implementation
{
    public class LineCreator : ICreator
    {
        private readonly Document _document;

        public LineCreator(Document document)
        {
            _document = document;
        }

        public void Create(List<Point> points, double elevation)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                var firstPoint = points[i];
                var secondPoint = points[i + 1];

                var line = Line.CreateBound(firstPoint.AsXYZ(), secondPoint.AsXYZ());

                var directShape = DirectShape.CreateElement(_document, new ElementId(BuiltInCategory.OST_GenericModel));

                directShape.SetShape(new List<GeometryObject> { line });
            }
        }
    }
}