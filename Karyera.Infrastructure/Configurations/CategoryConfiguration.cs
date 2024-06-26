﻿using Karyera.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
        //    builder.HasMany(c => c.Categories) // Bir kategorinin birden çok alt kategorisi olabilir
        //.WithOne() // Her bir alt kategori, yalnızca bir üst kategoriye sahip olabilir
        //.HasForeignKey(c => c.MainCategory).OnDelete(deleteBehavior: DeleteBehavior.NoAction)// Her alt kategori, bir üst kategoriye ait bir anahtar taşımalıdır
        //.IsRequired(false);
        builder.HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
    //public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    //{
    //    public void Configure(EntityTypeBuilder<Company> builder)
    //    {
    //        builder.HasMany(x=>x.Jobs).WithOne(x=>x.Company);
    //    }
    //}
}
