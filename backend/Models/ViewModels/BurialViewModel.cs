using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.ViewModels
{
    public class BurialViewModel
    {
        public IQueryable<Burialmain> Burialmains { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}