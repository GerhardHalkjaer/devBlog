namespace devBlog.DAL.SQL.Interface;

public interface ISqlDatabase
{
    public int CreatePost(Post post);
    public List<Post> GetPosts();

    


}

