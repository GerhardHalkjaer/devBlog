using devBlog.DAL.SQL.Interface;
using System.Data.SqlClient;

namespace devBlog.DAL.SQL;

public class SqlDatabase : ISqlDatabase
{
    private readonly string _strCon;

    public SqlDatabase()
    {
        //move connection string to a sub folder for more security.
        IConfigurationRoot builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: false).Build();
        _strCon = builder.GetConnectionString("devBlogDb");
        
    }



    public void CreatePost(Post post)
    {
        SqlConnection con = new SqlConnection(_strCon);
        //TODO: CreatePost
        throw new NotImplementedException();
    }

    public List<Post> GetPosts()
    {
        SqlConnection con = new SqlConnection(_strCon);
        //TODO: getPosts
        throw new NotImplementedException();
    }
}

