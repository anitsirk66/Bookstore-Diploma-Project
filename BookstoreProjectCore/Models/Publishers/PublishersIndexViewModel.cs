using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Publishers
{
    public class PublishersIndexViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(200)]
        public string Description { get; set; } = null!;
    }
}
