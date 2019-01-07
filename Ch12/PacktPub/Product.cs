using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 
 
namespace Packt.CS7 
{ 
    public class Product 
    { 
        public int ProductID { get; set; } 
 
        [Required] 
        [StringLength(40)] 
        public string ProductName { get; set; } 
 
        [Column("UnitPrice", TypeName = "money")] 
        public decimal? UnitPrice { get; set; } 

        [Column("UnitsInStock")]
        public short? UnitsInStock { get; set; }

        public bool Discontinued { get; set; }
 
        public int CategoryID { get; set; } 
        public int? SupplierID { get; set; }
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
    } 
} 