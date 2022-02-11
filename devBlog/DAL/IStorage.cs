using devBlog.DAL;
namespace devBlog.DAL.Interface;


public interface IStorage
{
    public void CreatePost(Post post);
    public List<Post> GetPosts();
}

