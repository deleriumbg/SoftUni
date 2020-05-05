﻿namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;

    public interface IHotel
    {
        int Capacity { get; }
        IReadOnlyDictionary<string, IAnimal> Animals { get; }

        void Accommodate(IAnimal animal);
        void Adopt(string animalName, string owner);
    }
}
