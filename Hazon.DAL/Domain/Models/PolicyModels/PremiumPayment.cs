﻿namespace Hazon.DAL.Domain.Models.PolicyModels
{
    public class PremiumPayment:BaseEntity
    {
        public Guid ClientId { get; set; }
        public Guid PolicyId { get; set; }
        public Guid BranchId { get; set; }
        public Guid PaymentModelId { get; set; }
        public Guid PaymentTypeId { get; set; }
        public string? PaymentDetails { get; set; }
        public string? UnderwritingDocumentNumber { get; set; }
        public string? Narration { get; set; }
        public string? PremiumDocumentNumber { get; set; }
        public DateTime CoverStartDate { get; set; }
        public DateTime CoverEndDate { get; set; }
        public decimal OutStanding { get; set; }
    }
}
