using Autodesk.Revit.DB;

namespace MVVMProject.Models
{
    public class Point
    {
        public double Z { get; set; }
        public double Y { get; set; }
        public double X { get; set; }


        public XYZ AsXYZ() => new XYZ(X, Y, Z);
    }
}
