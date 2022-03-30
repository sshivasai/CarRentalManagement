using CarRentalManagement_DAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement_DAL.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ListItem { get;set; }
       // public double CartTotal { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
