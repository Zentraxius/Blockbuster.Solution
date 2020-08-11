using System.Collections.Generic;

namespace Blockbuster.models
{
  public class Video
  {
    public Video()
    {
      this.Customers = new Hashset<CustomerVideo>();
      // this.Actors = new Hashset<VideoActors>();
      // this.Genres = new Hashset<VideoGenres>();
    }
    public int VideoId { get; set; }
    public string Title { get; set; }
    public string Ratings { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<CustomerVideo> Customers { get; }
    // public virtual ICollection<VideoActors> Actors { get; }
    // public virtual ICollection<VideoGenres> Genres { get; }
  }
}