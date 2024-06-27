using Microsoft.EntityFrameworkCore;

namespace BetUp.CommonInterfaces
{
    public class BaseObject
    {
        public Guid Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}