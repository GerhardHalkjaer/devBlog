using devBlog.DAL.Interface;
using devBlog.DAL.SQL.Interface;

namespace devBlog.DAL;

public class Storage : IStorage
{
    readonly ISqlDatabase _db;

    //TODO: setup to determin what type of saving needs to happen.
    //Storage is a general facade for if it needs to save to sql or txt fike or xml file and call the correct repository.

    public Storage(ISqlDatabase sqlDb)
    {

        _db = sqlDb;
    }

    public int CreatePost(Post post)
    {
         return _db.CreatePost(post);
    }

    public List<Post> GetPosts()
    {
        return _db.GetPosts();
    }
}

