﻿using System;
using StreetNaming.Domain.Models.Interfaces;

namespace StreetNaming.Domain.Models
{
    public class Transaction : ICreatable
    {
        // WORK IN PROGRESS

        public long TransactionId { get; set; }

        public long RequestId { get; set; }

        public Request Request { get; set; }

        public string Provider { get; set; }

        public Guid Reference { get; set; }

        public decimal Amount { get; set; }

        public char Currency { get; set; }

        public int? ResponseCode { get; set; }

        public string ResponseDescription { get; set; }

        public DateTime? ResponseDate { get; set; }

        public TransactionStatus TransactionStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public enum TransactionStatus
    {
        Pending = 1 << 0,
        Complete = 1 << 1,
        Cancelled = 1 << 2
    }
}