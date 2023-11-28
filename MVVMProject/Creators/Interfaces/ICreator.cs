using System.Collections.Generic;
using MVVMProject.Models;

namespace MVVMProject.Creators.Interfaces
{
    public interface ICreator
    {
        void Create(List<Point> points, double elevation);
    }
}