

using System;

public class PostVm
{
  public Guid Id { get; set; }
  public string Post { get; set; }
  public int TotalLikes { get; set; }
  public bool IsSharedPost { get; set; }
  public int TotalComments { get; set; }
  public DateTime PostedDate { get; set; }
  public PostedByVm PostedBy { get; set; }

}