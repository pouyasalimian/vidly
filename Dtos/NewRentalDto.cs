﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly3.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }

        public List<int> MoviesId { get; set; }
    }
}