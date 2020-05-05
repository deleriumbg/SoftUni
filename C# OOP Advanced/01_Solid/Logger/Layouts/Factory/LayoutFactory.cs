namespace Logger.Layouts.Factory
{
    using System;
    using Logger.Layouts.Contracts;
    using Contracts;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            type = type.ToLower();
            switch (type)
            {
                 case "simplelayout":
                     return new SimpleLayout();
                 case "xmllayout":
                     return new XmlLayout();
                 default:
                     throw new ArgumentException("Invalid layout type");
            }
        }
    }
}
