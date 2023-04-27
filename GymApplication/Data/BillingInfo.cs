﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymApplication.Data
{
    public class BillingInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }
    }
}

