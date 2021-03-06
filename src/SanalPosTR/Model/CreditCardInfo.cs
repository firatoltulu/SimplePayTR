﻿using System.Collections.Generic;

namespace SanalPosTR.Model
{
    
    public class CreditCardInfo
    {
        public string CardNumber { get; set; }

        public string ExpireMonth { get; set; }

        public string ExpireYear { get; set; }

        public string CVV2 { get; set; }

        public string CardHolderName { get; set; }

        public List<SanalPosTRAttribute> Attributes { get; set; } = new List<SanalPosTRAttribute>();
    }
}