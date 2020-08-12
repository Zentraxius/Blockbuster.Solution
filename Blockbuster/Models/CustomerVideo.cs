namespace Blockbuster.Models
{
public class CustomerVideo
  {
    public int CustomerVideoId { get; set; }
    public string CustomerId { get; set; }
    public int VideoId { get; set; }
    public Customer Customer { get; set; }
    public Video Video { get; set; }
  }
}