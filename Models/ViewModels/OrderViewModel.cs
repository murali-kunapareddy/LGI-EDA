﻿using WISSEN.EDA.Data;
using WISSEN.EDA.Models.Entities;

namespace WISSEN.EDA.Models.ViewModels
{
    public class OrderViewModel
    {
        public Order? Order { get; set; } = new Order();
        public List<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
        public List<MasterItem>? ConsigneeTypes { get; set; }
        public List<MasterItem>? ContainerSizes { get; set; }

    }
}
