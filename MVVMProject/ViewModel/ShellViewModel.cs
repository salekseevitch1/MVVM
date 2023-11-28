using Autodesk.Revit.DB;
using MVVMProject.Creators.Interfaces;
using MVVMProject.Readers.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMProject.ViewModel
{
    public class ShellViewModel : BindableBase
    {
        private readonly Document _document;
        private readonly IPointReader _reader;
        private readonly ICreator _creator;
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
            IPointReader reader, 
            ICreator creator)
        {
            _document = document;

            _reader = reader;
            _creator = creator;

            Points = new ObservableCollection<Models.Point>(
                _reader.Read(@"D:\Repos\MVVM\MVVMProject\Resources\points.json"));
            
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
