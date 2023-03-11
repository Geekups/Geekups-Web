using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using Microsoft.AspNetCore.Components;
using MudBlazor;

using System.Net;

namespace DayanaWeb.Client.Pages.General.Blog.BlogPostComment;

public partial class PostComments
{
    [Parameter]
    public string PostId { get; set; }
    List<PostFeedBackDto> model= new();
    private int _selected = 1;
    private int _totalPagesCount = 3;
    protected override async Task OnInitializedAsync()
    {
        await GetPostCommentsDtosAsync();
    }

    private async Task GetPostCommentsDtosAsync()
    {
        DefaultPaginationFilter paginationFilter = new(_selected, 10);
        var paginatedData = await _httpService.GetPagedValue<PostFeedBackDto>(Routes.PostFeedback + "get-post-feedback-list-by-filter", paginationFilter);
        model = paginatedData.Data;
        _totalPagesCount = paginatedData.TotalPages;
        this.StateHasChanged();
    }

    private async Task OnPageChange(int pageNumber)
    {
        _selected = pageNumber;
        await GetPostCommentsDtosAsync();
    }
}
