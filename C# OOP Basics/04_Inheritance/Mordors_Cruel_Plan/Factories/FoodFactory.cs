namespace Mordors_Cruel_Plan.Factories
{
    using Foods;

    class FoodFactory
    {
        public Food CreateFood(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                 case "apple":
                    return new Apple();
                 case "cram":
                     return new Cram();
                 case "honeycake":
                     return new HoneyCake();
                 case "lembas":
                     return new Lembas();
                 case "melon":
                     return new Melon();
                 case "mushrooms":
                     return new Mushrooms();
                 default:
                     return new Unspecified();
            }
        }
    }
}
