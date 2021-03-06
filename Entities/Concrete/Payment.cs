﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Payment:IEntity
    {
        public int Id { get; set; }
        public string NameOnCard { get; set; }
        public string LastNameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string ExpirationDateMonth { get; set; }
        public string ExpirationDateYear { get; set; }
        public decimal MoneyInCard { get; set; }

    }
}
