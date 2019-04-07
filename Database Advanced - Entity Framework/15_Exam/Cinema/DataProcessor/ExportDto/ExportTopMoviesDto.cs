using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DataProcessor.ExportDto
{
    //    "MovieName": "SIS",
    //    "Rating": "10.00",
    //    "TotalIncomes": "184.04",
    //    "Customers": [
    //{
    //    "FirstName": "Davita",
    //    "LastName": "Lister",
    //    "Balance": "279.76"
    //}

    public class ExportTopMoviesDto
    {
        public string MovieName { get; set; }

        public string Rating { get; set; }

        public string TotalIncomes { get; set; }

        public ExportCustomersDto[] Customers { get; set; }
    }

    public class ExportCustomersDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Balance { get; set; }
    }
}
