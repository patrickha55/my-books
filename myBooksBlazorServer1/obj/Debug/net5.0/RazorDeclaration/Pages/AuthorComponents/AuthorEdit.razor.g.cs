// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace myBooksBlazorServer1.Pages.AuthorComponents
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using myBooksBlazorServer1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using myBooksBlazorServer1.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using my_books_data.DTOs.AuthorDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\_Imports.razor"
using myBooksBlazorServer1.Services.AuthorServices;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/authorEdit/{id:int}")]
    public partial class AuthorEdit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer1\Pages\AuthorComponents\AuthorEdit.razor"
       
    [Parameter]
    public int id { get; set; }
    private UpdateAuthorDTO authorUpdate = new UpdateAuthorDTO();
    private AuthorDTO author = new();

    protected async override Task OnParametersSetAsync()
    {
        if (id != 0) author = await AuthorService.GetAuthorAsync(id);
    }

    private async Task updateAuthor()
    {
        authorUpdate.Id = author.Id;
        authorUpdate.FirstName = author.FirstName;
        authorUpdate.LastName = author.LastName;
        await AuthorService.UpdateAsync(authorUpdate);

        NavManager.NavigateTo("/authors");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthorService AuthorService { get; set; }
    }
}
#pragma warning restore 1591