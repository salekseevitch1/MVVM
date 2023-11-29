using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace MVVMProject.Extensions
{
    public static class UiDocumentSelection
    {
        public static List<T> Select<T>(this UIDocument uiDocument)
        {
            var refs = uiDocument.Selection
                .PickObjects(ObjectType.Element, new Filter<T>());

            return refs
                .Select(it => uiDocument.Document.GetElement(it))
                .Cast<T>()
                .ToList();
        }
    }
}