using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using devBlog.BLL.Interface;
namespace devBlog.BLL;

public class Blog : IBlog
{
    public List<Post>? Posts { get; set; }
}
