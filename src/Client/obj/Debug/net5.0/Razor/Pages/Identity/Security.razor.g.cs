#pragma checksum "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de982caa062b8d5a3bbd2de60d538ffce4bc3741"
// <auto-generated/>
#pragma warning disable 1591
namespace WarehouseManger.Client.Pages.Identity
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
#line 49 "D:\Repositories\WarehouseManger\src\Client\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    public partial class Security : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 3 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                  _passwordModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 3 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                 ChangePasswordAsync

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Blazored.FluentValidation.FluentValidationValidator>(4);
                __builder2.AddComponentReferenceCapture(5, (__value) => {
#nullable restore
#line 4 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                     _fluentValidationValidator = (Blazored.FluentValidation.FluentValidationValidator)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudCard>(7);
                __builder2.AddAttribute(8, "Elevation", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 5 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                        25

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudCardHeader>(10);
                    __builder3.AddAttribute(11, "CardHeaderContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudText>(12);
                        __builder4.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
#nullable restore
#line 8 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
__builder5.AddContent(14, _localizer["Change Password"]);

#line default
#line hidden
#nullable disable
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(15, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudCardContent>(16);
                    __builder3.AddAttribute(17, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudGrid>(18);
                        __builder4.AddAttribute(19, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<MudBlazor.MudItem>(20);
                            __builder5.AddAttribute(21, "xs", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 13 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                             12

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(22, "md", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 13 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                     6

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(23, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.OpenComponent<MudBlazor.MudTextField<string>>(24);
                                __builder6.AddAttribute(25, "For", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<string>>>(
#nullable restore
#line 14 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                             () => _passwordModel.NewPassword

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(26, "Label", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                        _localizer["Password"]

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(27, "Variant", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 14 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                         Variant.Outlined

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(28, "InputType", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.InputType>(
#nullable restore
#line 14 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                      _newPasswordInput

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(29, "Adornment", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Adornment>(
#nullable restore
#line 14 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                                                    Adornment.End

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(30, "AdornmentIcon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                                                                                   _newPasswordInputIcon

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(31, "OnAdornmentClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                                                                                                                              () => TogglePasswordVisibility(true)

#line default
#line hidden
#nullable disable
                                )));
                                __builder6.AddAttribute(32, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(
#nullable restore
#line 14 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                          _passwordModel.NewPassword

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(33, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<string>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<string>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _passwordModel.NewPassword = __value, _passwordModel.NewPassword))));
                                __builder6.CloseComponent();
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(34, "\r\n                ");
                            __builder5.OpenComponent<MudBlazor.MudItem>(35);
                            __builder5.AddAttribute(36, "xs", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 16 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                             12

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(37, "md", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 16 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                     6

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(38, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.OpenComponent<MudBlazor.MudTextField<string>>(39);
                                __builder6.AddAttribute(40, "For", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<string>>>(
#nullable restore
#line 17 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                    () => _passwordModel.ConfirmNewPassword

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(41, "Label", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                      _localizer["Password Confirmation"]

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(42, "Variant", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 17 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                    Variant.Outlined

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(43, "InputType", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.InputType>(
#nullable restore
#line 17 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                                                 _newPasswordInput

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(44, "Adornment", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Adornment>(
#nullable restore
#line 17 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                                                                               Adornment.End

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(45, "AdornmentIcon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                                                                                                              _newPasswordInputIcon

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(46, "OnAdornmentClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                                                                                                                                                         () => TogglePasswordVisibility(true)

#line default
#line hidden
#nullable disable
                                )));
                                __builder6.AddAttribute(47, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(
#nullable restore
#line 17 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                          _passwordModel.ConfirmNewPassword

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(48, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<string>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<string>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _passwordModel.ConfirmNewPassword = __value, _passwordModel.ConfirmNewPassword))));
                                __builder6.CloseComponent();
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(49, "\r\n                ");
                            __builder5.OpenComponent<MudBlazor.MudItem>(50);
                            __builder5.AddAttribute(51, "xs", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 19 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                             12

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(52, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.OpenComponent<MudBlazor.MudTextField<string>>(53);
                                __builder6.AddAttribute(54, "For", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<string>>>(
#nullable restore
#line 20 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                          () => _passwordModel.Password

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(55, "Label", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 20 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                  _localizer["Current Password"]

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(56, "Variant", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 20 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                           Variant.Outlined

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(57, "InputType", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.InputType>(
#nullable restore
#line 20 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                        _currentPasswordInput

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(58, "Adornment", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Adornment>(
#nullable restore
#line 20 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                                                          Adornment.End

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(59, "AdornmentIcon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 20 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                                                                                         _currentPasswordInputIcon

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(60, "OnAdornmentClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                                                                                                                                                                                                                                        () => TogglePasswordVisibility(false)

#line default
#line hidden
#nullable disable
                                )));
                                __builder6.AddAttribute(61, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(
#nullable restore
#line 20 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                          _passwordModel.Password

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(62, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<string>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<string>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _passwordModel.Password = __value, _passwordModel.Password))));
                                __builder6.CloseComponent();
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(63, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudCardActions>(64);
                    __builder3.AddAttribute(65, "Class", "pb-4 pl-4");
                    __builder3.AddAttribute(66, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudButton>(67);
                        __builder4.AddAttribute(68, "Variant", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 25 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                Variant.Filled

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(69, "Disabled", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 25 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                            !Validated

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(70, "Color", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 25 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                Color.Primary

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(71, "ButtonType", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.ButtonType>(
#nullable restore
#line 25 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
                                                                                                           ButtonType.Submit

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(72, "Class", "ml-auto");
                        __builder4.AddAttribute(73, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
#nullable restore
#line 25 "D:\Repositories\WarehouseManger\src\Client\Pages\Identity\Security.razor"
__builder5.AddContent(74, _localizer["Change Password"]);

#line default
#line hidden
#nullable disable
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<Security> _localizer { get; set; }
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
