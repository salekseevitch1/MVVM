using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using MVVMProject.Extensions;

namespace MVVMProject
{
    [Transaction(TransactionMode.Manual)]
    public class ExtensionCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiDocument = commandData.Application.ActiveUIDocument;
            var document = uiDocument.Document;

            var wall = uiDocument.Select<Wall>().FirstOrDefault();

            // System parameters
            var systemParameter = wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET);

            // Other parameters
            var otherParameter = wall.LookupParameter("Other Parameter");
            
            return Result.Succeeded;
        }
    }
}