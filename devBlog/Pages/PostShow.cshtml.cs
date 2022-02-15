using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using devBlog.BLL.Interface;

namespace devBlog.Pages
{
    public class PostShowModel : PageModel
    {
        private readonly IBlog _blog;
        public PostShowModel(IBlog blog)
        {
            _blog = blog;
        }

        public void OnGet()
        {
            post = _blog.GetPostById(Id);
        }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Post post { get; set; }
    }
}
