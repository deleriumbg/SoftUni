namespace Travel.Entities.Airplanes
{
    public class LightAirplane : Airplane
    {
        private new const int Seats = 5;
        private new const int BaggageCompartments = 8;

        public LightAirplane()
            : base(Seats, BaggageCompartments)
        {
        }
    }
}