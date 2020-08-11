using System.Collections.Generic;

namespace Blockbuster.models
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

    public virtual Video Video { get; set;}
    public ICollection<CustomerVideo> Videos {get; }
    

  
  
  }
}