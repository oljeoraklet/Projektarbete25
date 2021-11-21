// Creates all the shapes and checks if points are inside. 
// maybe the "count points" class should check do the isPointInside check...

using System;
namespace Projektarbete
{
    public class ShapeHandler
    {
        public void MakeShapes()
        {
            Polygon square = new Polygon (3, 2, 2, 2);
            // Point targetPoint = new Point (1, 1, 4);
            // Console.WriteLine("IsPointInside returns " + square.IsPointInside(targetPoint));
            // System.Console.WriteLine(square.GetStats());
            square.GetStats();
        }
    }
}