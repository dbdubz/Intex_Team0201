﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace backend.Models
{
    public partial class Structure
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public int? Structureid { get; set; }
    }
}
