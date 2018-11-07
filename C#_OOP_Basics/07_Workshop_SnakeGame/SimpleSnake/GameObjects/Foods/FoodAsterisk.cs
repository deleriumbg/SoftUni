namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char foodSymbol = '*';
        private const int foodPoints = 1;

        public FoodAsterisk() 
            : base(foodSymbol, foodPoints)
        {
        }
    }
}
