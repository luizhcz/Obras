using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Obras.Commom.Models.AuthorsModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obras.Repositories.Mapping
{
    public class AuthorsMap : IEntityTypeConfiguration<FluentAuthors>
    {

        public void Configure(EntityTypeBuilder<FluentAuthors> builder)
        {
            builder.HasKey(c => c.Id)
                    .HasName("Id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("Name")
                .HasMaxLength(500);
        }
    }
}
