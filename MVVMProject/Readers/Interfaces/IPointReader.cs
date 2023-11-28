using System.Collections.Generic;

namespace MVVMProject.Readers.Interfaces
{
    public interface IPointReader
    {
        List<Models.Point> Read(string path);
        void Write();
    }
}