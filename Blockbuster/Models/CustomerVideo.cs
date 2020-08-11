namespace Blockbuster.models
{
public class CustomerVideo
  {
    public int CustomerVideo { get; set; }
    public int CustomerId { get; set; }
    public int VideoId { get; set; }
    public Customer Customer { get; set; }
    public Video Video { get; set; }
  }
}