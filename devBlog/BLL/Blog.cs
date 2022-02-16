using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using devBlog.BLL.Interface;
using devBlog.DAL.Interface;
namespace devBlog.BLL;

public class Blog : IBlog
{
    readonly IStorage _storage;
    public Blog(IStorage storage)
    {
        _storage = storage;
    }

    public List<Post> Posts { get; private set; } = new();
    //time stand when the Storage was last called to reduce the amount of storage calls, as there may not have been any changes since last time.
    DateTime _LastPostUpdated;

    /// <summary>
    /// create post in storage and add to local list of posts.
    /// </summary>
    /// <param name="post"></param>
    public void CreatePost(Post post)
    {
        post.Id = _storage.CreatePost(post);
        Posts.Add(post);
    }

    /// <summary>
    /// get list of posts, but first check if last call is more then 30sec, if not just return current list, since odds of changes is small.
    /// </summary>
    /// <returns></returns>
    public List<Post> GetPosts()
    {
        if (0 > DateTime.Compare(_LastPostUpdated, DateTime.Now.AddSeconds(-30)))
        {
            // get from store
            Posts = _storage.GetPosts();
            //update time for last storage get call was made.
            _LastPostUpdated = DateTime.Now;
            //do more?   
        }
        return Posts;

    }

    /// <summary>
    /// get a post by id from local List Posts, and fill in links and files from storage if local is count 0.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Post GetPostById(int id)
    {
        Post post = Posts.Find(x => x.Id == id);
        if (post.Links.Count == 0)
        {
            post.Links = _storage.GetLinksByPostId(post.Id);
        }
        if (post.Filer.Count == 0)
        {
            post.Filer = _storage.GetfileByPostId(post.Id);
        }
        return post;
    }
}
