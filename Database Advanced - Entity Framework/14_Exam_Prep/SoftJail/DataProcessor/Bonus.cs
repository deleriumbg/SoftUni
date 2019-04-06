﻿namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            var prisoner = context.Prisoners.Find(prisonerId);

            if (prisoner.ReleaseDate == null)
            {
                return $"Prisoner {prisoner.FullName} is sentenced to life";
            }

            prisoner.ReleaseDate = DateTime.Now;
            prisoner.CellId = null;
            context.Prisoners.Update(prisoner);

            return $"Prisoner {prisoner.FullName} released";
        }
    }
}
