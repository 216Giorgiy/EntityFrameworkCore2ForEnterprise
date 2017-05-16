﻿using Microsoft.Extensions.Options;
using Store.Core;
using Store.Core.BusinessLayer;
using Store.Core.BusinessLayer.Contracts;
using Store.Core.DataLayer;
using Store.Core.DataLayer.Mapping;

namespace Store.API.Tests
{
    public static class BusinessObjectMocker
    {
        public static IHumanResourcesBusinessObject GetHumanResourcesBusinessObject()
        {
            var userInfo = new UserInfo { Name = "admin" };

            var appSettings = Options.Create(AppSettingsMocker.Default);

            var entityMapper = new StoreEntityMapper() as IEntityMapper;

            return new HumanResourcesBusinessObject(null, userInfo, new StoreDbContext(appSettings, entityMapper)) as IHumanResourcesBusinessObject;
        }

        public static IProductionBusinessObject GetProductionBusinessObject()
        {
            var userInfo = new UserInfo { Name = "admin" };

            var appSettings = Options.Create(AppSettingsMocker.Default);

            var entityMapper = new StoreEntityMapper() as IEntityMapper;

            return new ProductionBusinessObject(null, userInfo, new StoreDbContext(appSettings, entityMapper)) as IProductionBusinessObject;
        }

        public static ISalesBusinessObject GetSalesBusinessObject()
        {
            var userInfo = new UserInfo { Name = "admin" };

            var appSettings = Options.Create(AppSettingsMocker.Default);

            var entityMapper = new StoreEntityMapper() as IEntityMapper;

            return new SalesBusinessObject(null, userInfo, new StoreDbContext(appSettings, entityMapper)) as ISalesBusinessObject;
        }
    }
}
