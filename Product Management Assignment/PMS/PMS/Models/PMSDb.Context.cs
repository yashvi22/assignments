﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PMSEntities : DbContext
    {
        public PMSEntities()
            : base("name=PMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    
        public virtual int insertdata(string name, string categoryName, Nullable<decimal> price, Nullable<int> quantity, string smallImage, string largeImage, string smallDescription, string largeDescription)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var categoryNameParameter = categoryName != null ?
                new ObjectParameter("CategoryName", categoryName) :
                new ObjectParameter("CategoryName", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(int));
    
            var smallImageParameter = smallImage != null ?
                new ObjectParameter("SmallImage", smallImage) :
                new ObjectParameter("SmallImage", typeof(string));
    
            var largeImageParameter = largeImage != null ?
                new ObjectParameter("LargeImage", largeImage) :
                new ObjectParameter("LargeImage", typeof(string));
    
            var smallDescriptionParameter = smallDescription != null ?
                new ObjectParameter("SmallDescription", smallDescription) :
                new ObjectParameter("SmallDescription", typeof(string));
    
            var largeDescriptionParameter = largeDescription != null ?
                new ObjectParameter("LargeDescription", largeDescription) :
                new ObjectParameter("LargeDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertdata", nameParameter, categoryNameParameter, priceParameter, quantityParameter, smallImageParameter, largeImageParameter, smallDescriptionParameter, largeDescriptionParameter);
        }
    }
}
