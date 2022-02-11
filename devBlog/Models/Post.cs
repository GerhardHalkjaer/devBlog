using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devBlog.Models;

public class Post
{
    public int Id { get; set; }
    public string Overskrift { get; set; } = "Overskrift";
    public string BrødText { get; set; } = "Indhold";
    public List<string>? Links { get; set; }
    public List<string>? Filer { get; set; }
    public Auther? Forfatter { get; set; }
    public List<Tag> Tags { get; set; }


}
