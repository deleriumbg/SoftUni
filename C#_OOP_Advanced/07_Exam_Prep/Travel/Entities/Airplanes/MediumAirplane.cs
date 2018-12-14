namespace Travel.Entities.Airplanes
{
    public class MediumAirplane : Airplane
    {
        private new const int Seats = 10;
        private new const int BaggageCompartments = 14;

        public MediumAirplane()
            : base(Seats, BaggageCompartments)
        {
        }
    }
}