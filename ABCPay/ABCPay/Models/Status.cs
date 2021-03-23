using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Models
{
    public class Status
    {
        [Column("StatusId")]
        public int Id { get; set; }

        [Column("StatusName")]
        public string Name { get; set; }
    }
}
