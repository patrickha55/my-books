#pragma checksum "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43f29c4efde042fbda1ad6228bb259653f4a9014"
// <auto-generated/>
#pragma warning disable 1591
namespace myBooksBlazorWASAP.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using myBooksBlazorWASAP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using myBooksBlazorWASAP.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using my_books_data.DTOs.AuthorDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\_Imports.razor"
using myBooksBlazorWASAP.Services.AuthorServices;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-ude436raza");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "sidebar");
            __builder.AddAttribute(5, "b-ude436raza");
            __builder.OpenComponent<myBooksBlazorWASAP.Shared.NavMenu>(6);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n\r\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "main");
            __builder.AddAttribute(10, "b-ude436raza");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "top-row px-4 auth");
            __builder.AddAttribute(13, "b-ude436raza");
            __builder.OpenComponent<myBooksBlazorWASAP.Shared.LoginDisplay>(14);
            __builder.CloseComponent();
            __builder.AddMarkupContent(15, "\r\n            ");
            __builder.AddMarkupContent(16, "<a href=\"https://docs.microsoft.com/aspnet/\" target=\"_blank\" b-ude436raza>About</a>");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n\r\n        ");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "content px-4");
            __builder.AddAttribute(20, "b-ude436raza");
            __builder.AddContent(21, 
#nullable restore
#line 15 "C:\Users\diepv\source\repos\ProjectAspNet\Core\my-books\myBooksBlazorWASAP\Shared\MainLayout.razor"
             Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591