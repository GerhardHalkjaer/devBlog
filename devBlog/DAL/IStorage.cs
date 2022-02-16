using devBlog.DAL;
namespace devBlog.DAL.Interface;


public interface IStorage
{
    public int CreatePost(Post post);
    public List<Post> GetPosts();
    public List<string> GetLinksByPostId(int postId);
    public List<string> GetfileByPostId(int postId);

}

