#pragma checksum "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48cc7eccd8955fb40ad117632b0ec239cab22808"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Membership_BuyMembership), @"mvc.1.0.view", @"/Views/Membership/BuyMembership.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48cc7eccd8955fb40ad117632b0ec239cab22808", @"/Views/Membership/BuyMembership.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62354149c70a3597a9f5423422692979c890428d", @"/Views/_ViewImports.cshtml")]
    public class Views_Membership_BuyMembership : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Client>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
   
    ViewBag.Title = "добавить в группу"; 
    Layout = "_Layout"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n <h4>Добавить в группу</h4> \n<hr />\n <div class=\"row\"> \n     <div class=\"col-md-8\"> \n       ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48cc7eccd8955fb40ad117632b0ec239cab228084160", async() => {
                WriteLiteral(" \n          \n           <div class=\"form-group\"> \n                <label  class=\"control-label\">Клиент</label> \n               <input name=\"clientName\"");
                BeginWriteAttribute("value", "  value=\"", 352, "\"", 379, 1);
#nullable restore
#line 15 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
WriteAttributeValue("", 361, Model.NameSurname, 361, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("  disabled=\"disabled\" class=\"form-control\" > \n             <input name=\"clientId\"");
                BeginWriteAttribute("value", "  value=\"", 461, "\"", 479, 1);
#nullable restore
#line 16 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
WriteAttributeValue("", 470, Model.Id, 470, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"  type=""hidden"" class=""form-control"" > 
             </div> 
           <div class=""form-group""> 
                 <label  class=""control-label"">Выберите группу:</label>
               
               <select class=""form-control"" id=""groupSelect"" name=""GroupId"">
");
#nullable restore
#line 22 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                    foreach (var schedule in ViewBag.Schedules)
                   {

#line default
#line hidden
#nullable disable
                WriteLiteral("                       ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48cc7eccd8955fb40ad117632b0ec239cab228085980", async() => {
#nullable restore
#line 24 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                                                                                                                                                   Write(schedule.Group.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                WriteLiteral("{\"group\":\"");
#nullable restore
#line 24 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                                    WriteLiteral(schedule.GroupId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\", \"days\":");
#nullable restore
#line 24 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                                                                              string result = String.Join(",", @schedule.DayOfWeeksString);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"");
#nullable restore
#line 24 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                                                                                                                                 WriteLiteral(result);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"}");
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 25 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                   }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"               </select>
                                
           </div> 
           <div class=""form-group""> 
               <label  class=""control-label"">Выберите абонемент:</label> 
                                           
               <select name=""MembershipId"" id=""membershipSelect"" class=""form-control"">
");
#nullable restore
#line 33 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                    foreach (Membership membership in  @ViewBag.Memberships)
                   {

#line default
#line hidden
#nullable disable
                WriteLiteral("                       ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48cc7eccd8955fb40ad117632b0ec239cab228089592", async() => {
#nullable restore
#line 35 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                                                 Write(membership.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                          WriteLiteral(membership.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 36 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                   }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                               
               </select>          
                                           
           </div>
           <div class=""form-group"">
               <label class=""control-label"">Дата первого занятия:</label>
               <input type=""text"" id=""datepicker"" name=""FirstDay"" class=""form-control"" autocomplete=""off"" required>
           </div>
           
           
           <div class=""form-group""> 
                <input id=""submitCreate"" type=""submit"" value=""Создать"" class=""btn btn-secondary"" /> 
            </div> 
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" \n    </div> \n </div> \n\n <div> \n</div> \n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $('#submitCreate').on('click', function () {
           
            
         if ($('#datepicker').val() === ''){
                $('#errorText').text('Выберите дату');
            }
            else {
                const optionValueGroup = $('#groupSelect').val();                         	  
                let objGroup = $.parseJSON(optionValueGroup);
             
                const optionValueMembership = $('#membershipSelect').val();
                const objMembership = $.parseJSON(optionValueMembership);
                   console.log(objGroup);
                $.ajax({
                    url: '");
#nullable restore
#line 73 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                     Write(Url.Action("BuyMembership", "Membership"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\n                    type: \"POST\",\n                    datatype: \"json\",\n                    data: {\n                      \n                        \"clientId\": ");
#nullable restore
#line 78 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Membership\BuyMembership.cshtml"
                               Write(Model.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
                        ""MembershipId"": objMembership,
                        ""GroupId"": objGroup.group,
                        ""FirstDay"": $('#datepicker').val()
                    }
                   
                })
            }
        })
    </script>
    <script >
    function showHideOptions(){
            const optionValue = $('#groupSelect').val();                         	  
            var obj = $.parseJSON(optionValue);
            var daysArray = ['Воскресенье', 'Понедельник', 'Вторник', 'Среда', 'Четверг', 'Пятница', 'Суббота'];
            var daysSelected = obj.days.split("","");
            let indexes = daysSelected.map(function(word) { return daysArray.indexOf(word); })
            let disabledDays = daysArray.filter( function( el ) {return daysSelected.indexOf( el ) < 0;});
            let disabledIndexes = disabledDays.map(function(word) { return daysArray.indexOf(word); });
            var today = new Date();
           
            let date = today;
            $('#datepicker').");
                WriteLiteral(@"datepicker({
                language: ""ru"",
                startDate: date,
                format: ""dd.mm.yyyy"",
                weekStart: 1,
                todayHighlight: true,
                daysOfWeekDisabled: disabledIndexes,
                daysOfWeekHighlighted: indexes
            });
    }
    $(document).ready(function() {
       showHideOptions();
    $('#groupSelect').on('change',function(){
        $('#datepicker').datepicker('destroy');
        $('#datepicker').val('');
       showHideOptions();
       });
     });
    
    </script>
 
    
    
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Client> Html { get; private set; }
    }
}
#pragma warning restore 1591
