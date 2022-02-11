using devBlog.DAL.SQL.Interface;
using System.Data.SqlClient;

namespace devBlog.DAL.SQL;

public class SqlDatabase : ISqlDatabase
{
    private readonly SqlConnection con;

    public SqlDatabase()
    {
        //TODO:move connection string to a sub folder for more security.
        IConfigurationRoot builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: false).Build();
        string strCon = builder.GetConnectionString("devBlogDb");
        con = new SqlConnection(strCon);
    }



    public void CreatePost(Post post)
    {
        //TODO: CreatePost
        throw new NotImplementedException();
    }

    public List<Post> GetPosts()
    {
        //TODO: getPosts
        throw new NotImplementedException();
    }
}

