using System;
using System.Collections.Generic;
using System.Globalization;
namespace Projektarbete 
{
    public class InputHandler
    {
        // Variables with Command line arguments
        string pointArgs;
        string shapeArgs;
        string shapeScoreArgs;

        // List with all points
        public List<Point> Points { get; private set; } = new List<Point>();
        // List with all shapes
        public List<IShape> Shapes { get; private set; } = new List<IShape>();
        // Dictionary with shape-names and their respective ShapeScore
        public Dictionary<string, int> ShapeScoreDictionary = new Dictionary<string, int>();

        //Constructor
        public InputHandler(string[] args)
        {
            this.pointArgs = args[0].TrimEnd(';');
            this.shapeArgs = args[1].TrimEnd(';');
            this.shapeScoreArgs = args[2].TrimEnd(';');
        }

        public void MakeShapeScoreDictionary()
        {
            try{
                string[] shapeScoresArr = shapeScoreArgs.Split(';');
                foreach (string s in shapeScoresArr)
                {
                    string[] shapeScoreArr = s.Split(',');
                    string shape = shapeScoreArr[0];
                    shape = shape.Trim();
                    Int32.TryParse(shapeScoreArr[1], out int shapeScore);
                    // Add string shape as key and int shapeScore as value to ShapeScoreDictionary
                    ShapeScoreDictionary.Add(shape, shapeScore);
                }
            }
            catch
            {
                Console.WriteLine("Your input for the shape scores is incorrect. It should follow this format: SHAPE, SHAPE_SCORE. Each point should also be separated with a ‘;’");
                Environment.Exit(0);
            }

        }

        // Method to create shapes in the IShapes list
        public void MakeShapes()
        {
            try{
            string[] shapesArr = shapeArgs.Split(';');

            foreach (string s in shapesArr)
            {
                // Split shapesArr at ',' and put in shapeArr
                string[] shapeArr = s.Split(',');
                // Put the contents of shapeArr in correct variables
                string shape = shapeArr[0];
                shape = shape.Trim();
                Int32.TryParse(shapeArr[1].Trim(), System.Globalization.NumberStyles.AllowLeadingSign, NumberFormatInfo.InvariantInfo, out int centreX);
                Int32.TryParse(shapeArr[2].Trim(), System.Globalization.NumberStyles.AllowLeadingSign, NumberFormatInfo.InvariantInfo, out int centreY);
                Int32.TryParse(shapeArr[3].Trim(), out int perimeter);
                // Create shapes and put in list
                switch (shape)
                {
                    case "CIRCLE":   Shapes.Add(new Circle (centreX, centreY, perimeter, shape)); break;
                    case "TRIANGLE": Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 3)); break;
                    case "SQUARE":   Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 4)); break;
                    case "PENTAGON": Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 5)); break;
                    case "HEXAGON":  Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 6)); break;
                    case "HEPTAGON": Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 7)); break;
                    case "OCTAGON":  Shapes.Add(new Polygon(centreX, centreY, perimeter, shape, 8)); break;
                    // Felhantering:
                    default: 
                        Console.WriteLine("Your input for the shapes is incorrect. It should follow this format: SHAPE, X, Y, PERIMETER. Each point should also be separated with a ‘;’"); 
                        Environment.Exit(0); 
                        break;
                }
            }
            }
            catch(SystemException)
            {
                Console.WriteLine("Your input for the shapes is incorrect. It should follow this format: SHAPE, X, Y, PERIMETER. Each point should also be separated with a ‘;’"); 
                Environment.Exit(0); 
            }
        }

        // Method to create points in the points list
        public void MakePoints()
        {
            try
            {
                string[] pointsArr = pointArgs.Split(';');

                foreach (string s in pointsArr)
                {            
                    // Split pointArr at ',' and put in pointArr
                    string[] pointArr = s.Split(',');

                    // Convert strings to int
                    Int32.TryParse(pointArr[0].Trim(), System.Globalization.NumberStyles.AllowLeadingSign, NumberFormatInfo.InvariantInfo, out int x);
                    Int32.TryParse(pointArr[1].Trim(), System.Globalization.NumberStyles.AllowLeadingSign, NumberFormatInfo.InvariantInfo, out int y);
                    Int32.TryParse(pointArr[2], out int pointScore);
                    // Instantiate new Point and add to the "points" list
                    Points.Add(new Point(x, y, pointScore));
                }
            
            }
            catch (System.Exception)
            {
                Console.WriteLine("Your input for the points is incorrect. It should follow this format: X, Y, SCORE. Each point should also be separated with a ‘;’");
                Environment.Exit(0);
            }
        }
    }
}