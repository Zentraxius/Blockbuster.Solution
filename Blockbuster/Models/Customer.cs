using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Blockbuster.Models
{
  public class Customer : IdentityUser
  {
    public Customer()
    {
      this.Videos = new HashSet<CustomerVideo>();
    }

    public int CustomerId {get; set; }
    public int VideoId {get; set; }
    public string CustomerName {get; set;}
    // public virtual ApplicationUser User { get; set; }
    public ICollection<CustomerVideo> Videos { get; }  
  }
}
    
