public class Rectangle
{
    public Point TopLeft{ get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public bool Contains(Point point)
    {
        return point.X >= this.TopLeft.X && point.X <= this.BottomRight.X &&
               point.Y <= this.BottomRight.Y && point.Y >= this.TopLeft.Y;
    }
}
