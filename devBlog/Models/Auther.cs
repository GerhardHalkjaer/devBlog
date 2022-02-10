using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devBlog.Models;

public class Auther : User
{
    public List<Post>? Posts { get; set; }

}
