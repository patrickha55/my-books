#pragma checksum "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "edc9e76d287bc447e79bb824c57a25d5f71f7bfc"
// <auto-generated/>
#pragma warning disable 1591
namespace myBooksBlazorServer.Pages.AuthorComponents
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using myBooksBlazorServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using myBooksBlazorServer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\_Imports.razor"
using my_books_data.DTOs.AuthorDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
using System.Text.Json.Serialization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/authors")]
    public partial class Author : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Author</h3>");
#nullable restore
#line 8 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
 if (getAuthorsError)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<span class=\"alert alert-danger\">Unable to get authors from api.</span>");
#nullable restore
#line 11 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "container");
            __builder.OpenElement(4, "table");
            __builder.AddAttribute(5, "class", "table table-hover table-striped");
            __builder.AddMarkupContent(6, "<thead><tr><th>ID</th>\r\n                    <th>First Name</th>\r\n                    <th>Last Name</th>\r\n                    <th colspan=\"2\"></th></tr></thead>\r\n            ");
            __builder.OpenElement(7, "tbody");
            __builder.OpenElement(8, "tr");
#nullable restore
#line 26 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
                     foreach (var author in authors)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(9, "td");
            __builder.AddContent(10, 
#nullable restore
#line 28 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
                             author.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n                        ");
            __builder.OpenElement(12, "td");
            __builder.AddContent(13, 
#nullable restore
#line 29 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
                             author.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n                        ");
            __builder.OpenElement(15, "td");
            __builder.AddContent(16, 
#nullable restore
#line 30 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
                             author.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                        ");
            __builder.OpenElement(18, "td");
            __builder.OpenElement(19, "a");
            __builder.AddAttribute(20, "class", "btn btn-warning");
            __builder.AddAttribute(21, "href", "/authorEdit/" + (
#nullable restore
#line 31 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
                                                                          author.Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(22, "Edit");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n                        ");
            __builder.OpenElement(24, "td");
            __builder.OpenElement(25, "a");
            __builder.AddAttribute(26, "class", "btn btn-danger");
            __builder.AddAttribute(27, "href", "/authorEdit/" + (
#nullable restore
#line 32 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
                                                                         author.Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(28, "Delete");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 33 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 38 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 40 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorServer\Pages\AuthorComponents\Author.razor"
       
    private IEnumerable<AuthorDTO> authors = Array.Empty<AuthorDTO>();
    private bool getAuthorsError;
    private bool shouldRender;

    protected override bool ShouldRender()
    {
        return shouldRender;
    }

    protected override async Task OnInitializedAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:15203/api/authors/");

        var client = ClientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            authors = await JsonSerializer.DeserializeAsync<IEnumerable<AuthorDTO>>(responseStream);
        }
        else
        {
            getAuthorsError = true;
        }

        shouldRender = true;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpClientFactory ClientFactory { get; set; }
    }
}
#pragma warning restore 1591