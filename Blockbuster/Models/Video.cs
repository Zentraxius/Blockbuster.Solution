using System.Collections.Generic;

namespace Blockbuster.Models
{
  public class Video
  {
    public Video()
    {
      this.Customers = new HashSet<CustomerVideo>();
      // this.Actors = new Hashset<VideoActors>();
      // this.Genres = new Hashset<VideoGenres>();
    }
    public int VideoId { get; set; }
    public string Title { get; set; }
    public string Rating { get; set; }
    public int Stock { get; set; }
    // public virtual ApplicationUser User { get; set; }
    public virtual ICollection<CustomerVideo> Customers { get; }
    // public virtual ICollection<VideoActors> Actors { get; }
    // public virtual ICollection<VideoGenres> Genres { get; }

    public int CurrentStock()
    {
      return Stock - Customers.Count;
    }
  }
}