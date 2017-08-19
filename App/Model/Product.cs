using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class Product
    {
       

        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }
        public int CategoryId { get; set; }
       
        public Decimal UnitPrice { get; set; }
        public Decimal DiscountForLocation { get; set; }
        public Decimal MinimumSPForLocation { get; set; }
        public virtual Category Category { get; set; }
        public String Color { get; set; }
        public String Image { get; set; }
        public Boolean IsAvailable { get; set; }
        public Boolean? IsRateChangable { get; set; }
    }
    public class Category
    {
      

        [Key]
        public int Id { get; set; }

        public String CategoryName { get; set; }
        public String Color { get; set; }
        
        public virtual List<Product> Products { get; set; }
    }


    public class User
    {

        [Key]
        public int UserID { get; set; }

        public int PassCode { get; set; }

        public int StoreID { get; set; }

        public String UserName { get; set; }

        public virtual Store Store { get; set; }
    }



    public class Store
    {

        [Key]
        public int StoreID { get; set; }

        public String StoreName { get; set; }

        public String  StoreAddress { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<ControlDiemension> ControlDiemensions { get; set; }
        

    }

    public class Company
    {
        public String CompanyId
        {
            get;
            set;
        }
        public String Name
        {
            get;
            set;
        }
      
    }



    public class Table
    {

        [Key]
        public int TableID { get; set; }

       
        public int StoreID { get; set; }

        public String TableName { get; set; }

        public virtual Store Store { get; set; }

        public String Color { get; set; }
    }




    public class Customer
    {

        [Key]
        public int CustomerID { get; set; }


        public int StoreID { get; set; }

        public String CustomerName { get; set; }

        public string PhoneNumber { get; set; }

        public string CustomerDetails { get; set; }

        public virtual Store Store { get; set; }

        public String Color { get; set; }
    }


    public class Invoicemaster
    {

        [Key]
        public int InvoicemasterID { get; set; }


        public int StoreID { get; set; }
        public int UserID { get; set; }


        public String CustomerName { get; set; }

        public string PhoneNumber { get; set; }

        public string CustomerDetails { get; set; }

        public virtual Store Store { get; set; }
        public virtual User User { get; set; }

        public String Color { get; set; }
    }

}
