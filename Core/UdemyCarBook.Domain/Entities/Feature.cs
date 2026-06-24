using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class Feature
    {
        [Key]
        public int FutureId { get; set; }
        public string Name { get; set; }

    }
}
