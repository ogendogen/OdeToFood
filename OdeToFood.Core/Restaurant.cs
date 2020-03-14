﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant : IValidatableObject
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }

        // just for my information
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
