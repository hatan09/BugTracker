
namespace BugTracker.Core.Entities
{
    public class Admin : User
    {
        public virtual Company? Company { get; set; }
    }
}
