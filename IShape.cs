namespace Projektarbete
{
    public interface IShape
    {
        bool IsPointInside(Point targetPoint);
        double CalculateArea();
        string GetName();
    }
}