using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using MudBlazor;
using System.Net;

namespace DayanaWeb.Client.Pages.General.Blog.BlogPostComment;

public partial class AddPostComment
{
    PostCategoryDto model = new();

    public async Task Add()
    {
        var response = await _httpService.PostValue(Routes.PostFeedback + "add-post-feedback", model);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            _snackbar.Add("Post Comment Created Succesfully", Severity.Success);
        }
        else
        {
            _snackbar.Add("Operation Failed", Severity.Error);
        }
    }
}
