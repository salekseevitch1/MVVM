using System;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DryIoc;

namespace MVVMProject.Core
{
    public abstract class BaseCommand : IExternalCommand
    {
        public Container Container;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Container = new Container();

            Container.RegisterInstance(commandData.Application);
            Container.RegisterInstance(commandData.Application.ActiveUIDocument);
            Container.RegisterInstance(commandData.Application.ActiveUIDocument.Document);

            RegisterCustomTypes();

            try
            {
                Run();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

                return Result.Failed;
            }

            return Result.Succeeded;
        }

        public abstract void RegisterCustomTypes();

        public abstract void Run();
    }
}