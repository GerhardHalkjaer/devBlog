namespace devBlog.DAL.SQL.Interface;

public interface ISqlDatabase
{
    public int CreatePost(Post post);
    public List<Post> GetPosts();
    public List<string> GetLinksByPostId(int postId);
    public List<string> GetfileByPostId(int postId);
}

