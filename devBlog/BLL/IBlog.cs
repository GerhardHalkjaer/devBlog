using devBlog.BLL;

namespace devBlog.BLL.Interface;

public interface IBlog
{
    public List<Post>? Posts { get; }
    public void CreatePost(Post post);
    public List<Post> GetPosts();
    public Post GetPostById(int id);

}

