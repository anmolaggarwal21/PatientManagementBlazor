#pragma checksum "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "553fefd097d34fafc4d06576b7cfff6b08c8d64b"
// <auto-generated/>
#pragma warning disable 1591
namespace WarehouseManger.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 2 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using Blazored.FluentValidation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Identity.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Identity.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Identity.Roles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Identity.RoleClaims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Identity.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Preferences;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Interceptors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Catalog.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Catalog.Brand;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Dashboard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Communication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Audit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Misc.Document;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Managers.Misc.DocumentType;

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Shared.Constants.Permission;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Shared.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Shared.Dialogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Settings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Application.Requests.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Pages.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Infrastructure.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
using WarehouseManger.Client.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<WarehouseManger.Client.Shared.Components.UserCard>(0);
            __builder.CloseComponent();
            __builder.AddMarkupContent(1, "\r\n");
            __builder.OpenComponent<MudBlazor.MudNavMenu>(2);
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudNavLink>(4);
                __builder2.AddAttribute(5, "Href", "/");
                __builder2.AddAttribute(6, "Match", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 6 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                NavLinkMatch.All

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(7, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 6 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                         Icons.Material.Outlined.Home

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 6 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(9, _localizer["Home"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 7 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
     if (_canViewHangfire)
    {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(10);
                __builder2.AddAttribute(11, "Href", "/jobs");
                __builder2.AddAttribute(12, "Target", "_blank");
                __builder2.AddAttribute(13, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 9 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                        Icons.Material.Outlined.Work

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(14, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 10 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(15, _localizer["Hangfire"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 12 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
    }

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(16);
                __builder2.AddAttribute(17, "Href", "https://codewithmukesh.com/blog/blazor-hero-quick-start-guide/");
                __builder2.AddAttribute(18, "Target", "_blank");
                __builder2.AddAttribute(19, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 13 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                                                                             Icons.Material.Outlined.ReadMore

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 14 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(21, _localizer["Quick Start Guide"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(22, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudNavLink>(23);
                __builder2.AddAttribute(24, "Href", "/swagger/index.html");
                __builder2.AddAttribute(25, "Target", "_blank");
                __builder2.AddAttribute(26, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 16 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                                  Icons.Material.Outlined.LiveHelp

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(27, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 17 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(28, _localizer["Swagger"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(29, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudListSubheader>(30);
                __builder2.AddAttribute(31, "Class", "mt-2 mb-n2");
                __builder2.AddAttribute(32, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 19 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(33, _localizer["Personal"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 20 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
     if (_canViewDashboards)
    {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(34);
                __builder2.AddAttribute(35, "Href", "/dashboard");
                __builder2.AddAttribute(36, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 22 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                             Icons.Material.Outlined.Dashboard

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(37, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 23 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(38, _localizer["Dashboard"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 25 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
    }

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(39);
                __builder2.AddAttribute(40, "Href", "/account");
                __builder2.AddAttribute(41, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 26 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                       Icons.Material.Outlined.SupervisorAccount

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(42, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 27 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(43, _localizer["Account"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 29 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
     if (_canViewAuditTrails)
    {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(44);
                __builder2.AddAttribute(45, "Href", "/audit-trails");
                __builder2.AddAttribute(46, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                Icons.Material.Outlined.Security

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(47, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 32 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(48, _localizer["Audit Trails"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 34 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
     if (_canViewDocuments || _canViewDocumentTypes)
    {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudListSubheader>(49);
                __builder2.AddAttribute(50, "Class", "mt-2 mb-n2");
                __builder2.AddAttribute(51, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 37 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(52, _localizer["Document Management"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 38 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
         if (_canViewDocuments)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(53);
                __builder2.AddAttribute(54, "Href", "/document-store");
                __builder2.AddAttribute(55, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 40 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                      Icons.Material.Outlined.AttachFile

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(56, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 41 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(57, _localizer["Document Store"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 43 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
         if (_canViewDocumentTypes)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(58);
                __builder2.AddAttribute(59, "Href", "/document-types");
                __builder2.AddAttribute(60, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 46 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                      Icons.Material.Outlined.FileCopy

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(61, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 47 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(62, _localizer["Document Types"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 49 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
         
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
     if (_canViewUsers || _canViewRoles)
    {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudListSubheader>(63);
                __builder2.AddAttribute(64, "Class", "mt-2 mb-n2");
                __builder2.AddAttribute(65, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 54 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(66, _localizer["Administrator"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 55 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
         if (_canViewUsers)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(67);
                __builder2.AddAttribute(68, "Href", "/identity/users");
                __builder2.AddAttribute(69, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 57 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                      Icons.Material.Outlined.Person

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(70, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 58 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(71, _localizer["Users"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 60 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
         if (_canViewRoles)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(72);
                __builder2.AddAttribute(73, "Href", "/identity/roles");
                __builder2.AddAttribute(74, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 63 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                      Icons.Material.Outlined.Person

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(75, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 63 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(76, _localizer["Roles"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 64 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
         
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
     if (_canViewChat)
    {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudListSubheader>(77);
                __builder2.AddAttribute(78, "Class", "mt-2 mb-n2");
                __builder2.AddAttribute(79, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 68 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(80, _localizer["Communication"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(81, "\r\n        ");
                __builder2.OpenComponent<MudBlazor.MudNavLink>(82);
                __builder2.AddAttribute(83, "Href", "/chat");
                __builder2.AddAttribute(84, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 69 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                        Icons.Material.Outlined.Chat

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(85, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 70 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(86, _localizer["Chat"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 72 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
     if (_canViewProducts || _canViewBrands)
    {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudListSubheader>(87);
                __builder2.AddAttribute(88, "Class", "mt-2 mb-n2");
                __builder2.AddAttribute(89, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 75 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(90, _localizer["Catalog Management"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 76 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
         if (_canViewProducts)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(91);
                __builder2.AddAttribute(92, "Href", "/catalog/products");
                __builder2.AddAttribute(93, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 78 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                        Icons.Material.Outlined.CallToAction

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(94, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 79 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(95, _localizer["Products"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 81 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
         if (_canViewBrands)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudNavLink>(96);
                __builder2.AddAttribute(97, "Href", "/catalog/brands");
                __builder2.AddAttribute(98, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 84 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                      Icons.Material.Outlined.CallToAction

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(99, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 85 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
__builder3.AddContent(100, _localizer["Brands"]);

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 87 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
         

    }

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<MudBlazor.MudListSubheader>(101);
                __builder2.AddAttribute(102, "Class", "mt-2 mb-n2");
                __builder2.AddAttribute(103, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(104, "Patient Management");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(105, "\r\n        \r\n            ");
                __builder2.OpenComponent<MudBlazor.MudNavLink>(106);
                __builder2.AddAttribute(107, "Href", "/clinic/patient");
                __builder2.AddAttribute(108, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 93 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                      Icons.Material.Outlined.CallToAction

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(109, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(110, "\r\n               PatientDetails\r\n            ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(111, "\r\n         ");
                __builder2.OpenComponent<MudBlazor.MudNavLink>(112);
                __builder2.AddAttribute(113, "Href", "/clinic/doctordetails");
                __builder2.AddAttribute(114, "Icon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 96 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
                                                         Icons.Material.Outlined.CallToAction

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(115, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(116, "\r\n               Doctor\r\n            ");
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 105 "D:\Repositories\WarehouseManger\src\Client\Shared\NavMenu.razor"
       
    private ClaimsPrincipal _authenticationStateProviderUser;

    private bool _canViewHangfire;
    private bool _canViewDashboards;
    private bool _canViewDocuments;
    private bool _canViewDocumentTypes;
    private bool _canViewAuditTrails;
    private bool _canViewRoles;
    private bool _canViewUsers;
    private bool _canViewChat;
    private bool _canViewProducts;
    private bool _canViewBrands;

    protected override async Task OnParametersSetAsync()
    {
        _authenticationStateProviderUser = await _stateProvider.GetAuthenticationStateProviderUserAsync();
        _canViewHangfire = (await _authorizationService.AuthorizeAsync(_authenticationStateProviderUser, Permissions.Hangfire.View)).Succeeded;
        _canViewDashboards = (await _authorizationService.AuthorizeAsync(_authenticationStateProviderUser, Permissions.Dashboards.View)).Succeeded;
        _canViewDocuments = (await _authorizationService.AuthorizeAsync(_authenticationStateProviderUser, Permissions.Documents.View)).Succeeded;
        _canViewDocumentTypes = (await _authorizationService.AuthorizeAsync(_authenticationStateProviderUser, Permissions.DocumentTypes.View)).Succeeded;
        _canViewAuditTrails = (await _authorizationService.AuthorizeAsync(_authenticationStateProviderUser, Permissions.AuditTrails.View)).Succeeded;
        _canViewRoles = (await _authorizationService.AuthorizeAsync(_authenticationStateProviderUser, Permissions.Roles.View)).Succeeded;
        _canViewUsers = (await _authorizationService.AuthorizeAsync(_authenticationStateProviderUser, Permissions.Users.View)).Succeeded;
        _canViewChat = (await _authorizationService.AuthorizeAsync(_authenticationStateProviderUser, Permissions.Communication.Chat)).Succeeded;
        _canViewProducts = (await _authorizationService.AuthorizeAsync(_authenticationStateProviderUser, Permissions.Products.View)).Succeeded;
        _canViewBrands = (await _authorizationService.AuthorizeAsync(_authenticationStateProviderUser, Permissions.Brands.View)).Succeeded;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<NavMenu> _localizer { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime _jsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService _localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserManager _userManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ClientPreferenceManager _clientPreferenceManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpInterceptorManager _interceptor { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _httpClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDialogService _dialogService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISnackbar _snackBar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthorizationService _authorizationService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorHeroStateProvider _stateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountManager _accountManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationManager _authenticationManager { get; set; }
    }
}
#pragma warning restore 1591
