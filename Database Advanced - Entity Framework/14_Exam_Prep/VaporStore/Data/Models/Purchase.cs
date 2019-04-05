﻿using System;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    //•	Id – integer, Primary Key
    //•	Type – enumeration of type PurchaseType, with possible values (“Retail”, “Digital”) (required) 
    //•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes (ex. “ABCD-EFGH-1J3L”) (required)
    //•	Date – Date (required)
    //•	CardId – integer, foreign key (required)
    //•	Card – the purchase’s card (required)
    //•	GameId – integer, foreign key (required)
    //•	Game – the purchase’s game (required)

    public class Purchase
    {
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression("^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        public string ProductKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CardId { get; set; }

        public Card Card { get; set; }

        [Required]
        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
