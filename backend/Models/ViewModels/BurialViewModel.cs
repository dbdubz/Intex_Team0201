using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.ViewModels
{
    public class BurialViewModel
    {
        public IQueryable<Burialmain> Burialmains { get; set; }
        public IQueryable<BurialmainBodyanalysischart> BurialmainBodyanalysischarts { get; set;}
        public IQueryable<Bodyanalysischart> Bodyanalysischarts { get; set;}
        public IQueryable<BurialmainTextile> BurialmainTextiles { get; set;}
        public IQueryable<Textile> Textiles { get; set;}
        public IQueryable<ColorTextile> ColorTextiles { get; set;}
        public IQueryable<Color> Colors {get; set;}
        public IQueryable<TextilefunctionTextile> TextilefunctionTextiles { get; set;}
        public IQueryable<Textilefunction> Textilefunctions { get; set;}
        public IQueryable<StructureTextile> StructureTextiles { get; set;}
        public IQueryable<Structure> Structures {get; set;} 

public PageInfo PageInfo { get; set; }
    }
}