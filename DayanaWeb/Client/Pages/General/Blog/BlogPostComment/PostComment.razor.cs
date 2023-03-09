using Microsoft.AspNetCore.Components;
namespace DayanaWeb.Client.Pages.General.Blog.BlogPostComment;

public partial class PostComment
{
    [Parameter]
    public string PostText { get; set; }
}
