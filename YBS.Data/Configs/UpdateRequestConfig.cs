﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBS.Data.Models;

namespace YBS.Data.Configs
{
    public class UpdateRequestConfig : IEntityTypeConfiguration<UpdateRequest>
    {
        public void Configure(EntityTypeBuilder<UpdateRequest> builder)
        {
            builder.ToTable("UpdateRequest");
            builder.HasKey(updateRequest => updateRequest.Id);

            builder.Property(updateRequest => updateRequest.Id).ValueGeneratedOnAdd();
            builder.Property(updateRequest => updateRequest.Name).HasColumnType("nvarchar(100)");
            builder.Property(updateRequest => updateRequest.Address).HasColumnType("nvarchar(200)");
            builder.Property(updateRequest => updateRequest.Hotline).HasColumnType("varchar(15)");
            builder.Property(updateRequest => updateRequest.Logo).HasColumnType("varchar(255)");
            builder.Property(updateRequest => updateRequest.FacebookURL).HasColumnType("varchar(255)").IsRequired(false);
            builder.Property(updateRequest => updateRequest.InstagramURL).HasColumnType("varchar(255)").IsRequired(false);
            builder.Property(updateRequest => updateRequest.LinkedInURL).HasColumnType("varchar(255)").IsRequired(false);

            builder.HasOne(updateRequest => updateRequest.Company)
                .WithMany(company => company.UpdateRequests)
                .HasForeignKey(updateRequest => updateRequest.CompanyId)
                .IsRequired(false);
        }
    }
}
