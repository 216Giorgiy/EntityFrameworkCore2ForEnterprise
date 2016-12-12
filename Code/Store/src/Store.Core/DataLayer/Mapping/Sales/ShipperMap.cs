﻿using Microsoft.EntityFrameworkCore;
using Store.Core.EntityLayer.Sales;

namespace Store.Core.DataLayer.Mapping.Sales
{
    public class ShipperMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Shipper>();

            entity.ToTable("Shipper", "Sales");

            entity.HasKey(p => p.ShipperID);

            entity.Property(p => p.ShipperID).UseSqlServerIdentityColumn();
        }
    }
}
