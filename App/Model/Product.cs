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

        public int ProductName { get; set; }
        public int CategoryId { get; set; }

    }
    public class Category
    {
      

        [Key]
        public int Id { get; set; }

        public String CategoryName { get; set; }


    }


    public class User
    {

        [Key]
        public int UserID { get; set; }

        public int PassCode { get; set; }

        public int StoreID { get; set; }

        public String UserName { get; set; }
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












}
