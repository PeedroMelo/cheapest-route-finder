﻿using System.ComponentModel.DataAnnotations;

namespace BestCostRouteFinder.Domain.AggregateModels.Route
{
    public class Route
    {
        [Key]
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destiny { get; set; }

        public decimal Cost { get; set; }
    }
}