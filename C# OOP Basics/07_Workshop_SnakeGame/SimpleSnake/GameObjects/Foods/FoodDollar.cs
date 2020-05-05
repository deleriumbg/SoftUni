namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char foodSymbol = '$';
        private const int foodPoints = 2;

        public FoodDollar() 
            : base(foodSymbol, foodPoints)
        {
        }
    }
}
