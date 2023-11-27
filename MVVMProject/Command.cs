using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using MVVMProject.Creators;
using MVVMProject.View;
using MVVMProject.ViewModel;

namespace MVVMProject
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var document = commandData.Application.ActiveUIDocument.Document;

            var reader = new JsonReader();
            var creator = new ConduitCreator(document);

            var shell = new Shell();
            var shellViewModel = new ShellViewModel(document, reader, creator);

            shell.DataContext = shellViewModel;

            shell.ShowDialog();

            return Result.Succeeded;
        }
    }
}
