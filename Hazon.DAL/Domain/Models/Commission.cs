﻿namespace Hazon.DAL.Domain.Models
{
    public class Commission:BaseEntity
    {
        public Guid PolicyId { get; set; }
        public decimal CommissionPaid { get; set; }
        public decimal ExpectedCommission { get; set; }
        public Guid PaymentType { get; set; }
        public Guid PaymentModel { get; set; }
        public string? Details { get; set; }
    }
}
