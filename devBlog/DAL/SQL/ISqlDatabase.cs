namespace devBlog.DAL.SQL.Interface;

public interface ISqlDatabase
{
    public void CreatePost(Post post);
    public List<Post> GetPosts();
}

