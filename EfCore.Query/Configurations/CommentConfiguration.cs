using EfCore.Query.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Query.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x=>x.Content).IsRequired();
            builder.Property(x=>x.Content).HasMaxLength(350);
            builder.HasOne(x=>x.Blog).WithMany(x=>x.Comments).HasForeignKey(x=>x.BlogId);
        }
    }
}
