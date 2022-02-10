using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using devBlog.BLL.Interface;

namespace devBlog.Pages;

public class IndexModel : PageModel
{
    private readonly IBlog _blog;

    public IndexModel(IBlog blog) => _blog = blog;

    [BindProperty]
    public List<Post>? postList { get; set; }

    public void OnGet()
    {
        // get all posts from repository
    }
}
