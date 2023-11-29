using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace MVVMProject.Extensions
{
    public class Filter<T> : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem is T;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new System.NotImplementedException();
        }
    }
}