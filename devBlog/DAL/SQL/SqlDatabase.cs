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


    /// <summary>
    /// save the post to the database
    /// </summary>
    /// <param name="post"></param>
    public int CreatePost(Post post)
    {

        //TODO: CreatePost
        int postId = -1;
        using (SqlConnection con = new SqlConnection(_strCon))
        {
            SqlCommand cmd = new SqlCommand("dbo.CreatePost", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("title", post.Overskrift);
            cmd.Parameters.AddWithValue("content", post.BrødText);
            cmd.Parameters.AddWithValue("autherId", post.Forfatter.Id);

            SqlDataReader dr;

            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        postId = dr.GetInt32(0);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

        }
        post.Id = postId;
        CreateLink(post);
        CreateFile(post);

        return postId;
    }

   
    /// <summary>
    /// Create File entry for posts
    /// </summary>
    /// <param name="post"></param>
    private void CreateFile(Post post)
    {
        using (SqlConnection con = new SqlConnection(_strCon))
        {

            SqlCommand cmd = new SqlCommand("dbo.CreateFiles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("postId", post.Id);
            cmd.Parameters.AddWithValue("fileLocation", post.Filer[0]); //work around only 1 file.

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }


        }
    }

    /// <summary>
    /// create link entry for the post
    /// </summary>
    /// <param name="post"></param>
    private void CreateLink(Post post)
    {
        using (SqlConnection con = new SqlConnection(_strCon))
        {

            SqlCommand cmd = new SqlCommand("dbo.CreateLinks", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("postId", post.Id);
            cmd.Parameters.AddWithValue("link", post.Links[0]); //work around only 1 link.

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }


        }
    }

    /// <summary>
    /// get all the posts from databse
    /// </summary>
    /// <returns>a List of posts</returns>
    public List<Post> GetPosts()
    {
        List<Post> posts = new();

        using (SqlConnection con = new SqlConnection(_strCon))
        {

            SqlCommand cmd = new SqlCommand("dbo.GetAllPosts", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader dr;

            try
            {

                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Post post = new();
                        Auther auther = new();
                        post.Id = dr.GetInt32(0);
                        post.Overskrift = dr.GetString(1);
                        post.BrødText = dr.GetString(2);
                        auther.Id = dr.GetInt32(4);
                        auther.ForNave = dr.GetString(5);
                        auther.EfterNavn = dr.GetString(6);
                        post.Forfatter = auther;
                        // auther.Posts.Add(post);
                        //TODO: fix auther, as i dont think it works as intended


                        posts.Add(post);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

        }




        return posts;
    }




}

