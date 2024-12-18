﻿namespace BackendApi.Contracts.Payments
{
    public class CreatePaymentsRequest
    {
        public string PaymentType { get; set; } = null!;
        public int PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? PenaltyAmount { get; set; }
        public int UserId { get; set; }
    }
}
