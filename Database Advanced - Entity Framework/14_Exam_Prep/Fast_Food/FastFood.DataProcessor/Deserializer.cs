using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using DataAnnotations = System.ComponentModel.DataAnnotations;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
		    var deserializedEmployees = JsonConvert.DeserializeObject<EmployeesDto[]>(jsonString);
		    StringBuilder sb = new StringBuilder();
		    List<Employee> resultEmployees = new List<Employee>();

		    foreach (var employeeDto in deserializedEmployees)
		    {
		        if (!IsValid(employeeDto))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        Position position = context.Positions.SingleOrDefault(p => p.Name == employeeDto.Position);

		        if (position == null)
		        {
		            position = new Position
		            {
		                Name = employeeDto.Position
		            };

		            context.Positions.Add(position);
		            context.SaveChanges();
		        }

		        Employee currentEmployee = new Employee
		        {
		            Position = context.Positions.SingleOrDefault(p => p.Name == employeeDto.Position),
		            Name = employeeDto.Name,
		            Age = employeeDto.Age
		        };

		        resultEmployees.Add(currentEmployee);
		        sb.AppendLine(string.Format(SuccessMessage, currentEmployee.Name));
		    }

		    context.Employees.AddRange(resultEmployees);
		    context.SaveChanges();

		    return sb.ToString().Trim();
		}

	    public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
		    var deserializedItems = JsonConvert.DeserializeObject<ItemsDto[]>(jsonString);
		    StringBuilder sb = new StringBuilder();
		    List<Item> resultItems = new List<Item>();

		    foreach (var itemsDto in deserializedItems)
		    {
		        if (!IsValid(itemsDto) || resultItems.Any(x => x.Name == itemsDto.Name))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        Category category = context.Categories.SingleOrDefault(p => p.Name == itemsDto.Category);

		        if (category == null)
		        {
		            category = new Category
		            {
		                Name = itemsDto.Category
		            };

		            context.Categories.Add(category);
		            context.SaveChanges();
		        }

		        Item currentItem = new Item
		        {
		            Name = itemsDto.Name,
                    Price = itemsDto.Price,
                    Category = category
		        };

		        resultItems.Add(currentItem);
		        sb.AppendLine(string.Format(SuccessMessage, currentItem.Name));
		    }

		    context.Items.AddRange(resultItems);
		    context.SaveChanges();

		    return sb.ToString().Trim();
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
		    var serializer = new XmlSerializer(typeof(OrdersDto[]), new XmlRootAttribute("Orders"));
		    var deserizlizedOrders = (OrdersDto[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
		    var resultOrders = new List<Order>();

		    foreach (var orderDto in deserizlizedOrders)
		    {
		        if (!IsValid(orderDto))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        if (!orderDto.OrderItemsDto.All(i => context.Items.Any(dbItem => dbItem.Name == i.Name)))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        Employee employee = context.Employees.FirstOrDefault(x => x.Name == orderDto.Employee);
		        if (employee == null)
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        var date = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
		        var type = Enum.Parse<OrderType>(orderDto.Type);

		        var order = new Order
		        {
		            Customer = orderDto.Customer,
		            Employee = employee,
		            DateTime = date,
		            Type = type
		        };

		        foreach (var item in orderDto.OrderItemsDto)
		        {
		            var orderItem = new OrderItem
		            {
		                Order = order,
		                Item = context.Items.FirstOrDefault(x => x.Name == item.Name),
		                Quantity = item.Quantity
		            };

                    order.OrderItems.Add(orderItem);
		        }

		        resultOrders.Add(order);
		        sb.AppendLine($"Order for {order.Customer} on {order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
		    }

            context.Orders.AddRange(resultOrders);
		    context.SaveChanges();
		    return sb.ToString().Trim();
		}

	    public static bool IsValid(object obj)
	    {
	        var validationContext = new DataAnnotations.ValidationContext(obj);
	        var validationResults = new List<DataAnnotations.ValidationResult>();

	        return DataAnnotations.Validator.TryValidateObject(obj, validationContext, validationResults, true);
	    }
	}
}