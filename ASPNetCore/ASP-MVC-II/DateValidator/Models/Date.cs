using System;
using System.ComponentModel.DataAnnotations;
using DateValidator.Validatitors;

namespace DateValidator.Models
{
    public class Date
    {
        [FutureDate]
        [DataType(DataType.Date)]
        public DateTime ThisDate{set; get;}
    }
}