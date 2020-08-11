using System.Collections.Generic;

namespace Blockbuster.Models
{
  public class Customer
  {
    public Customer()
    {
      this.Videos = new HashSet<CustomerVideo>();
    }

    public int CustomerId {get; set; }
    public int VideoId {get; set; }
    public string CustomerName {get; set;}
    public virtual ApplicationUser User { get; set; }
    public ICollection<CustomerVideo> Videos {get; }  
  }
}
    
