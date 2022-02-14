using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using devBlog.BLL.Interface;

namespace devBlog.Pages
{
    public class CreatePostModel : PageModel
    {

        private readonly IBlog _blog;

        public CreatePostModel(IBlog blog)
        {
            _blog = blog;
        }

        [BindProperty]
        public Post post { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == true)
            {
                Auther auther = new Auther();
                auther.ForNave = "John";
                auther.EfterNavn = "Doh";
                post.Forfatter = auther;
                //TODO: fix current hardcoded auther.
                _blog.CreatePost(post);
                return RedirectToAction("Index");
            }
            else
            {
                return  Page();
            }
        }
        public void OnGet()
        {

        }
    }
}
