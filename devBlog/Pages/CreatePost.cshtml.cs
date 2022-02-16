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
        //a quick work around for now
        [BindProperty]
        public string link { get; set; } = String.Empty;
        [BindProperty]
        public string file { get; set; } = String.Empty;


        public IActionResult OnPost()
        {
            if (ModelState.IsValid == true)
            {
                Auther auther = new Auther();
                auther.ForNave = "John";
                auther.EfterNavn = "Doh";
                auther.Id = 1;
                post.Forfatter = auther;
                post.Links.Add(link);
                post.Filer.Add(file);
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
