using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using Autodesk.Revit.DB;
using MVVMProject.Creators;
using Point = Autodesk.Revit.DB.Point;

namespace MVVMProject.ViewModel
{
    public class ShellViewModel : BindableBase
    {
        private readonly Document _document;
        private readonly JsonReader _reader;
        private readonly ConduitCreator _creator;
        private string _elevation;

        public string Elevation
        {
            get => _elevation;
            set => SetProperty(ref _elevation, value);
        }

        public DelegateCommand CreateCommand { get; set; }

        public ObservableCollection<Models.Point> Points { get; set; }


        public ShellViewModel(
            Document document,
            JsonReader reader, 
            ConduitCreator creator)
        {
            _document = document;
            _reader = reader;
            _creator = creator;

            Points = new ObservableCollection<Models.Point>(
                _reader.Read(@"C:\Users\salek\OneDrive\Рабочий стол\points.json"));
            
            CreateCommand = new DelegateCommand(CreateConduit);
        }

        public void CreateConduit()
        {
            using (var tr = new Transaction(_document, "Create"))
            {
                tr.Start();

                _creator.Create(Points.ToList(), Convert.ToDouble(Elevation));

                tr.Commit();
            }
        }
    }
}
