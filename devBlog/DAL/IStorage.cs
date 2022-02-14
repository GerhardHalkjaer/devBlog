using devBlog.DAL;
namespace devBlog.DAL.Interface;


public interface IStorage
{
    public int CreatePost(Post post);
    public List<Post> GetPosts();
}

