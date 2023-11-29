using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace MVVMProject.Extensions
{
    public static class DocumentExtensions
    {
        public static List<Wall> GetWalls(this Document document)
        {
            return new FilteredElementCollector(document)
                .OfClass(typeof(Wall))
                .Cast<Wall>()
                .Where(it => it.WallType.Kind == WallKind.Basic)
                .ToList();
        }

        public static List<T> GetElements<T>(this Document document)
        {
            return new FilteredElementCollector(document)
                 .OfClass(typeof(T))
                 .Cast<T>()
                 .ToList();
        }
    }
}
