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
    DateTime _LastPostUpdated;

    public void CreatePost(Post post)
    {
        post.Id = _storage.CreatePost(post);
        Posts.Add(post);
    }

    public List<Post> GetPosts()
    {
        if (0 > DateTime.Compare(_LastPostUpdated, DateTime.Now.AddSeconds(-30)))
        {
            // get from store
            Posts = _storage.GetPosts();
            _LastPostUpdated = DateTime.Now;
            //do more?   
        }
        return Posts;

    }

    public Post GetPostById(int id)
    {
        return Posts.Find(x => x.Id == id);
    }
}
