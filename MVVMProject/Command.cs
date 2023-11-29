using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using DryIoc;
using MVVMProject.Core;
using MVVMProject.Creators.Implementation;
using MVVMProject.Creators.Interfaces;
using MVVMProject.Managers;
using MVVMProject.Readers.Implementation;
using MVVMProject.Readers.Interfaces;
using MVVMProject.View;
using MVVMProject.ViewModel;

namespace MVVMProject
{
    [Transaction(TransactionMode.Manual)]
    public class Command : BaseCommand
    {
        public override void RegisterCustomTypes()
        {
            Container.Register<IPointReader, JsonReader>();
            Container.Register<ICreator, LineCreator>();

            Container.Register<PathManager>();

            Container.Register<ActionHandler>();
            Container.Register<MyEventHandler>();

            Container.Register<ShellViewModel>();
        }

        public override void Run()
        {
            var shellViewModel = Container.Resolve<ShellViewModel>();

            var shell = new Shell();
            shell.DataContext = shellViewModel;

            shell.Show();
        }
    }
}
