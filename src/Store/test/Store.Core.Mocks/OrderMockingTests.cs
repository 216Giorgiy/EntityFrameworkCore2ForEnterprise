﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Core.EntityLayer.Sales;
using Xunit;

namespace Store.Core.Mocks
{
    public class OrderMockingTests
    {
        private async Task CreateData(DateTime startDate, DateTime endDate, Int32 ordersLimitPerDay)
        {
            var date = new DateTime(startDate.Year, startDate.Month, startDate.Day);

            while (date <= endDate)
            {
                if (date.DayOfWeek != DayOfWeek.Sunday)
                {
                    var random = new Random();

                    using (var salesBusinessObject = BusinessObjectMocker.GetSalesBusinessObject())
                    {
                        using (var humanResourcesBusinessObject = BusinessObjectMocker.GetHumanResourcesBusinessObject())
                        {
                            using (var productionBusinessObject = BusinessObjectMocker.GetProductionBusinessObject())
                            {
                                var pageSize = 10;
                                var pageNumber = 1;

                                var customerResponse = await salesBusinessObject.GetCustomersAsync(pageSize, pageNumber);
                                var employeesResponse = await humanResourcesBusinessObject.GetEmployeesAsync(pageSize, pageNumber);
                                var shippersResponse = await salesBusinessObject.GetShippersAsync(pageSize, pageNumber);
                                var productsResponse = await productionBusinessObject.GetProductsAsync(pageSize, pageNumber);

                                var customers = customerResponse.Model.ToList();
                                var employees = employeesResponse.Model.ToList();
                                var shippers = shippersResponse.Model.ToList();
                                var products = productsResponse.Model.ToList();

                                for (var i = 0; i < ordersLimitPerDay; i++)
                                {
                                    var header = new Order();

                                    var selectedCustomer = random.Next(0, customers.Count - 1);
                                    var selectedEmployee = random.Next(0, employees.Count - 1);
                                    var selectedShipper = random.Next(0, shippers.Count - 1);

                                    header.OrderDate = date;
                                    header.OrderStatusID = 100;
                                    header.CustomerID = customers[selectedCustomer].CustomerID;
                                    header.EmployeeID = employees[selectedEmployee].EmployeeID;
                                    header.ShipperID = shippers[selectedShipper].ShipperID;
                                    header.CreationDateTime = date;

                                    var details = new List<OrderDetail>();

                                    var detailsCount = random.Next(1, 3);

                                    for (var j = 0; j < detailsCount; j++)
                                    {
                                        var detail = new OrderDetail
                                        {
                                            ProductID = products[random.Next(0, products.Count - 1)].ProductID,
                                            Quantity = (Int16)random.Next(1, 3)
                                        };

                                        if (details.Count > 0 && details.Where(item => item.ProductID == detail.ProductID).Count() == 1)
                                        {
                                            continue;
                                        }

                                        details.Add(detail);
                                    }

                                    await salesBusinessObject.CreateOrderAsync(header, details.ToArray());
                                }

                            }
                        }
                    }
                }

                date = date.AddDays(1);
            }
        }

        [Fact]
        public async Task CreateOrders()
        {
            await CreateData(
                startDate: new DateTime(DateTime.Now.Year, 1, 1),
                endDate: new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)),
                ordersLimitPerDay: 10
            );
        }
    }
}
