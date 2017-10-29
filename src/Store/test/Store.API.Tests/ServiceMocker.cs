﻿using Microsoft.EntityFrameworkCore;
using Store.Core;
using Store.Core.BusinessLayer;
using Store.Core.BusinessLayer.Contracts;
using Store.Core.DataLayer;
using Store.Core.DataLayer.Mapping;

namespace Store.API.Tests
{
    public static class ServiceMocker
    {
        private static string ConnectionString
            => "server=(local);database=Store;integrated security=yes;MultipleActiveResultSets=True;";

        public static IHumanResourcesService GetHumanResourcesService()
        {
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            return new HumanResourcesService(null, new UserInfo { Name = "admin" }, new StoreDbContext(options, new StoreEntityMapper()));
        }

        public static IProductionService GetProductionService()
        {
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            return new ProductionService(null, new UserInfo { Name = "admin" }, new StoreDbContext(options, new StoreEntityMapper()));
        }

        public static ISalesService GetSalesService()
        {
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            return new SalesService(null, new UserInfo { Name = "admin" }, new StoreDbContext(options, new StoreEntityMapper()));
        }
    }
}
