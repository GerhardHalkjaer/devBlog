using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devBlog.Models;

public class Post
{
    public int Id { get; set; }
    public string Overskrift { get; set; } = string.Empty;
    public string BrødText { get; set; } = string.Empty;
    public List<string> Links { get; set; } = new();
    public List<string> Filer { get; set; } = new();
    public Auther? Forfatter { get; set; }
    public List<Tag>? Tags { get; set; }


}
