using MVVMProject.Core;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using MVVMProject.Managers;

namespace MVVMProject.ViewModel
{
    public class ShellViewModel : BindableBase
    {
        private readonly ActionHandler _actionHandler;
        private readonly PathManager _pathManager;

        private string _elevation;

        public string Elevation
        {
            get => _elevation;
            set => SetProperty(ref _elevation, value);
        }

        public DelegateCommand CreateCommand { get; set; }

        public ObservableCollection<Models.Point> Points { get; set; }


        public ShellViewModel(
            ActionHandler actionHandler,
            PathManager pathManager)
        {
            _actionHandler = actionHandler;
            _pathManager = pathManager;

            Points = new ObservableCollection<Models.Point>(pathManager.Points);

            CreateCommand = new DelegateCommand(CreateConduit);
        }

        public void CreateConduit()
        {
            _actionHandler.Run(application =>
            {
                var doc = application.ActiveUIDocument.Document;

                _pathManager.CreatePath(doc, Elevation);
            });
        }
    }
}
