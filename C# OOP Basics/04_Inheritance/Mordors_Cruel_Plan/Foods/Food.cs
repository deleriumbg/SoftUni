namespace Mordors_Cruel_Plan.Foods
{
    public abstract class Food
    {
        public int Happiness { get; }

        protected Food(int happiness)
        {
            this.Happiness = happiness;
        } 
    }
}
