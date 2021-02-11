using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestToDyeFor.Models
{
    public class MXRecipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DyeColor { get; set; }

        public MXRecipe() { }

        public MXRecipe(string name, string dyeColor)
        {
            Name = name;
            DyeColor = dyeColor;
        }




        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is MXRecipe recipe &&
                   Id == recipe.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
