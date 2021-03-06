﻿using SanalPosTR.Helper;

namespace SanalPosTR.Model
{
    public class Refund
    {
        public string ProvisionNumber { get; set; }

        public string ReferanceNumber { get; set; }

        public decimal RefundAmount { get; set; }

        public string OrderId { get; set; }

        public string CurrencyCode { get; set; }

        public Refund Clone()
        {
            var clonedObj = ObjectCopier.Clone(this); ;
            return clonedObj;
        }

    }
}