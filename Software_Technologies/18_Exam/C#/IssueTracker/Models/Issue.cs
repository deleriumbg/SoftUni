﻿namespace IssueTracker.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Issue
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Priority { get; set; }
    }
}
