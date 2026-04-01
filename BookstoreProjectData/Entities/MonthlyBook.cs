using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Entities
{
    public class MonthlyBook   
    {
        public Guid MonthlyBookSelectionId { get; set; }
        public MonthlyBookSelection MonthlyBookSelection { get; set; } = null!;

        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;

    }
}
