#pragma checksum "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f37a0955222b5ea43fc8ae2f3d539368ac9bfa75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clients_ClientInfo), @"mvc.1.0.view", @"/Views/Clients/ClientInfo.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\_ViewImports.cshtml"
using yogaAshram;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\_ViewImports.cshtml"
using yogaAshram.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\_ViewImports.cshtml"
using yogaAshram.Models.ModelViews;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
using yogaAshram.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f37a0955222b5ea43fc8ae2f3d539368ac9bfa75", @"/Views/Clients/ClientInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62354149c70a3597a9f5423422692979c890428d", @"/Views/_ViewImports.cshtml")]
    public class Views_Clients_ClientInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TrialUsers>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BuyMembership", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Membership", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mb-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "WriteComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Clients", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 5 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
  
    ViewBag.Title = "title";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h3>Информация о клиенте</h3>\n<p>Фио: ");
#nullable restore
#line 11 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
   Write(Model.Client.NameSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n<p> Номер телефона: ");
#nullable restore
#line 12 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
               Write(Model.Client.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n<p>Состояние: ");
#nullable restore
#line 13 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
         Write(GetEnumDescription.GetDescription(@Model.Client.ClientType));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n<p>Группа: ");
#nullable restore
#line 14 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
      Write(Model.Client.Group.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n<p> Создал: ");
#nullable restore
#line 15 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
       Write(Model.Client.Creator.NameSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n<p> Дата добавления: ");
#nullable restore
#line 16 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                Write(Model.Client.DateCreate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n\n");
#nullable restore
#line 18 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
 if (@Model.Client.ClientType == ClientType.Probe)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f37a0955222b5ea43fc8ae2f3d539368ac9bfa757626", async() => {
                WriteLiteral("Сделать активным");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-clientId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                                                                      WriteLiteral(Model.Client.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["clientId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-clientId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["clientId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                                                                                                            WriteLiteral(Model.Group.BranchId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["branchId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-branchId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["branchId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 21 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<table class=\"table\" id=\"customers\">\n    <tr>\n      \n        <th>Дата пробного</th>\n        <th>Посещение</th>\n         <th>Статус</th>\n        <th>Коментарии</th>\n          <th></th>\n    </tr>\n");
#nullable restore
#line 32 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
     foreach (var client in @ViewBag.Lessons)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n           \n            <td>");
#nullable restore
#line 36 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
           Write(client.LessonTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            \n            <td");
            BeginWriteAttribute("style", " style=\"", 1032, "\"", 1075, 2);
            WriteAttributeValue("", 1040, "background:", 1040, 11, true);
#nullable restore
#line 38 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
WriteAttributeValue(" ", 1051, client.GetColorTrial(), 1052, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 38 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                                                        Write(client.GetValueOfState());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>   \n            <td");
            BeginWriteAttribute("style", " style=\"", 1127, "\"", 1179, 2);
            WriteAttributeValue("", 1135, "background:", 1135, 11, true);
#nullable restore
#line 39 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
WriteAttributeValue(" ", 1146, client.Client.GetColorOfState(), 1147, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 39 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                                                                Write(GetEnumDescription.GetDescription(@client.Client.ClientType));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>\n");
#nullable restore
#line 41 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                 if (@client.SellerComments != null)
                             {
                                 

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                                  foreach (var comment in @client.SellerComments)
                                 {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                     <p class=\"small\">");
#nullable restore
#line 45 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                                                 Write(comment.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 46 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                                 }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                                  
                             }

#line default
#line hidden
#nullable disable
            WriteLiteral("<br/>\n              \n            </td>\n            <td>\n                <a type=\"button\" class=\"open-AddBookDialog btn btn-primary\" data-toggle=\"modal\" data-target=\"#sendComment\" data-id=\"");
#nullable restore
#line 51 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
                                                                                                                               Write(client.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n                    Коментировать\n                </a>\n            </td>\n        </tr>\n");
#nullable restore
#line 56 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Clients\ClientInfo.cshtml"
        
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</table>


<div class=""modal"" id=""sendComment"">
  <div class=""modal-dialog"">
    <div class=""modal-content"">

      <!-- Modal Header -->
      <div class=""modal-header"">
        <h4 class=""modal-title"">Написать коментари</h4>
        <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
      </div>

      <!-- Modal body -->
      <div class=""modal-body"">
          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f37a0955222b5ea43fc8ae2f3d539368ac9bfa7515910", async() => {
                WriteLiteral("\n               <input  name=\"clientId\" id=\"clientId\"");
                BeginWriteAttribute("value", " value=\"", 2421, "\"", 2429, 0);
                EndWriteAttribute();
                WriteLiteral(" type=\"hidden\">\n              <textarea name=\"SellerComment\" required cols=\"40\" rows=\"2\" class=\"form-control\"></textarea><br/>\n              <input type=\"submit\" value=\"Сохранить\" class=\"btn btn-success\">\n          ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n      </div>\n\n      <!-- Modal footer -->\n      <div class=\"modal-footer\">\n        <button type=\"button\" class=\"btn btn-danger\" data-dismiss=\"modal\">Закрыть</button>\n      </div>\n\n    </div>\n  </div>\n</div>\n\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    <script>$(document).on(\"click\", \".open-AddBookDialog\", function () {\n                     var myBookId = $(this).data(\'id\');\n                     $(\".modal-body #clientId\").val( myBookId );\n                  \n                });</script>\n    \n");
            }
            );
            WriteLiteral("\n\n\n\n\n\n  ");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TrialUsers> Html { get; private set; }
    }
}
#pragma warning restore 1591