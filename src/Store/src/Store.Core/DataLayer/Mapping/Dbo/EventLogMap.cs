﻿using System.Composition;
using Microsoft.EntityFrameworkCore;
using Store.Core.EntityLayer.Dbo;

namespace Store.Core.DataLayer.Mapping
{
    [Export(typeof(IEntityMap))]
    public class EventLogMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLog>(entity =>
            {
                // Mapping for table
                entity.ToTable("EventLog", "dbo");

                // Set key for entity
                entity.HasKey(p => p.EventLogID);

                // Set mapping for columns
                entity.Property(p => p.EventType).HasColumnType("int").IsRequired();
                entity.Property(p => p.Key).HasColumnType("varchar(255)").IsRequired();
                entity.Property(p => p.Message).HasColumnType("varchar(max)").IsRequired();
                entity.Property(p => p.EntryDate).HasColumnType("datetime").IsRequired();
            });
        }
    }
}
