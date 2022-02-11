using devBlog.BLL;

namespace devBlog.BLL.Interface;

public interface IBlog
{
    public List<Post>? Posts { get; set; }
    public void CreatePost(Post post);
}

