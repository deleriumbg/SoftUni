public class Rectangle
{
    public string Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    public Rectangle(string id, double width, double height, double x, double y)
    {
        Id = id;
        Width = width;
        Height = height;
        X = x;
        Y = y;
    }

    public bool Intersect(Rectangle otherRectangle)
    {
        return otherRectangle.X >= this.X - otherRectangle.Width && otherRectangle.X <= this.X + this.Width &&
               otherRectangle.Y >= this.Y - otherRectangle.Height && otherRectangle.Y <= this.Y + this.Height;
    }
}
