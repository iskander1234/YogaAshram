#pragma checksum "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f9e385262ed651a5400b9961b083c152f2e4116"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Schedule_PartialViews__AttendanceCheckPartial), @"mvc.1.0.view", @"/Views/Schedule/PartialViews/_AttendanceCheckPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f9e385262ed651a5400b9961b083c152f2e4116", @"/Views/Schedule/PartialViews/_AttendanceCheckPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62354149c70a3597a9f5423422692979c890428d", @"/Views/_ViewImports.cshtml")]
    public class Views_Schedule_PartialViews__AttendanceCheckPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Schedule>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MembershipExtension", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Membership", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "5", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div>

	<H5 class=""text-center"">Посещаемость клиентов</H5>
        	<p>Статус: <span id=""log"" class=""text-danger""></span></p>
		<table class=""table"" id=""absTimes"">
			<thead>
			<tr>
				<th scope=""col"">Клиент</th>
				<th scope=""col"">Количество пропусков</th>
				<th scope=""col"">Осталось заморозок</th>
				<th>Проверено</th>
				<th>Абонемент</th>
				<th>Осталось дней</th>
				<th scope=""col"">Посещение</th>
				<th scope=""col"">Подтверждение</th>
				<th>Комментарии</th>
			</tr>
			</thead>
			<tbody>
        
");
#nullable restore
#line 23 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
             foreach (Attendance attendance in  @Model.Attendances)
			{
        			

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<tr>\n\t\t\t\t\t<th scope=\"row\"");
            BeginWriteAttribute("id", " id=\"", 640, "\"", 670, 2);
            WriteAttributeValue("", 645, "clientName-", 645, 11, true);
#nullable restore
#line 27 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 656, attendance.Id, 656, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 27 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                                                              Write(attendance.Client.NameSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n\t\t\t\t\t<td>\n\t\t\t\t\t\t<div");
            BeginWriteAttribute("id", " id=\"", 728, "\"", 756, 2);
            WriteAttributeValue("", 733, "absTimes-", 733, 9, true);
#nullable restore
#line 29 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 742, attendance.Id, 742, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n\t\t\t\t\t\t\t");
#nullable restore
#line 30 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                       Write(attendance.AttendanceCount.AbsenceTimes);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\t\t\t\t\t\t</div>\n\t\t\t\t\t</td>\n\t\t\t\t\t<td>\n                    ");
#nullable restore
#line 34 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
               Write(attendance.AttendanceCount.FrozenTimes);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n\t\t\t\t\t<td>\n\t\t\t\t\t\t<div");
            BeginWriteAttribute("id", " id=\"", 947, "\"", 980, 2);
            WriteAttributeValue("", 952, "checkToReload-", 952, 14, true);
#nullable restore
#line 37 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 966, attendance.Id, 966, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n");
#nullable restore
#line 38 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                             if (@attendance.IsChecked)
							{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t<p>Проверено</p>\n");
#nullable restore
#line 41 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
							}
							else
							{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t<p>Не проверено</p>\n");
#nullable restore
#line 45 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
							}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t</div>\n\t\t\t\t\t</td>\n\t\t\t\t\t<td>");
#nullable restore
#line 48 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                   Write(attendance.Membership.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\t\t\t\t\t\n");
#nullable restore
#line 50 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                         if(@attendance.AttendanceCount.AttendingTimes < 3 && @attendance.AttendanceCount.AttendingTimes > 1)
						{ 

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div >\n\t\t\t\t\t\t\t<td class=\"bg-warning\">\t\t\t\t\t\t\t\t\t\t\t\t\t        \n\t\t\t\t\t\t\t\t");
#nullable restore
#line 54 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                           Write(attendance.AttendanceCount.AttendingTimes);

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t</td>\n\t\t\t\t\t\t\t</div>\n");
#nullable restore
#line 57 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
						}
						else if (@attendance.AttendanceCount.AttendingTimes == 1)
						{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div >\t\n\t\t\t\t\t\t\t<td class=\"bg-danger\">\t\t\t\t\t\t\t\t\t\t        \n\t\t\t\t\t\t\t\t");
#nullable restore
#line 62 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                           Write(attendance.AttendanceCount.AttendingTimes);

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t        \n\t\t\t\t\t\t\t</td> \n\t\t\t\t\t\t\t</div>\t\n");
#nullable restore
#line 65 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
						}
						else if (@attendance.AttendanceCount.AttendingTimes == 0 && @attendance.IsNotActive == false)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("\t                        <div>\t\n\t\t                        <td class=\"bg-danger\">\t\t\t\t\t\t\t\t\t\t        \n\t\t\t                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f9e385262ed651a5400b9961b083c152f2e411612088", async() => {
                WriteLiteral("Продлить абонемент");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-clientId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                                                                                                                                    WriteLiteral(attendance.ClientId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["clientId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-clientId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["clientId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                                                                                                                                                                          WriteLiteral(attendance.ClientsMembership.DateOfExpiry);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["date"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-date", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["date"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t        \n\t\t                        </td> \n\t                        </div>\n");
#nullable restore
#line 73 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                        }
						else
						{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<div>\n\t\t\t\t\t\t\t\t<td>\t\t\t\t\t\t\t\t\t\t\t\t\t\t        \n\t\t\t\t\t\t\t\t\t");
#nullable restore
#line 78 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                               Write(attendance.AttendanceCount.AttendingTimes);

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t        \n\t\t\t\t\t\t\t\t</td> \n\t\t\t\t\t\t\t</div>\n");
#nullable restore
#line 81 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
						}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\n\t\t\t\t\t<td>\n\t\t\t\t\t\t<input type=\"hidden\" name=\"attendanceId\"");
            BeginWriteAttribute("value", " value=\"", 2527, "\"", 2549, 1);
#nullable restore
#line 84 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 2535, attendance.Id, 2535, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2550, "\"", 2585, 2);
            WriteAttributeValue("", 2555, "inputAttendance-", 2555, 16, true);
#nullable restore
#line 84 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 2571, attendance.Id, 2571, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n\t\t\t\t\t\t<input type=\"hidden\" name=\"attendanceId\"");
            BeginWriteAttribute("value", " value=\"", 2634, "\"", 2662, 1);
#nullable restore
#line 85 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 2642, attendance.ClientId, 2642, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2663, "\"", 2696, 2);
            WriteAttributeValue("", 2668, "inputClientId-", 2668, 14, true);
#nullable restore
#line 85 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 2682, attendance.Id, 2682, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n        \t\t\t\t\t\t\n\t\t\t\t\t\t<select name=\"state\"");
            BeginWriteAttribute("id", " id=\"", 2740, "\"", 2769, 2);
            WriteAttributeValue("", 2745, "cameOrNot-", 2745, 10, true);
#nullable restore
#line 87 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 2755, attendance.Id, 2755, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\"");
            BeginWriteAttribute("onchange", " onchange=\"", 2791, "\"", 2836, 3);
            WriteAttributeValue("", 2802, "attendAndComment(\'", 2802, 18, true);
#nullable restore
#line 87 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 2820, attendance.Id, 2820, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2834, "\')", 2834, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\n\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f9e385262ed651a5400b9961b083c152f2e411619463", async() => {
                WriteLiteral("Пришел");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f9e385262ed651a5400b9961b083c152f2e411620635", async() => {
                WriteLiteral("Не пришел");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f9e385262ed651a5400b9961b083c152f2e411621810", async() => {
                WriteLiteral("Заморозка");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f9e385262ed651a5400b9961b083c152f2e411622985", async() => {
                WriteLiteral("Отмена/Выходной");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\t\t\t\t\t\t</select>\n\t\t\t\t\t</td>\n\t\t\t\t\t<td>\n\t\t\t\t\t\t<button");
            BeginWriteAttribute("onclick", " onclick=\"", 3068, "\"", 3118, 3);
            WriteAttributeValue("", 3078, "checkRegularAttendance(\'", 3078, 24, true);
#nullable restore
#line 95 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 3102, attendance.Id, 3102, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3116, "\')", 3116, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Отметить</button>        \n\t\t\t\t\t</td> \n\t\t\t\t\t<td>\n\t\t\t\t\t\t<div class=\"row\">\n\t\t\t\t\t\t\t<div");
            BeginWriteAttribute("id", " id=\"", 3227, "\"", 3261, 2);
            WriteAttributeValue("", 3232, "commentSection-", 3232, 15, true);
#nullable restore
#line 99 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 3247, attendance.Id, 3247, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n");
#nullable restore
#line 100 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                                 if (@attendance.Client.Comments != null)
								{								       
									

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                                     foreach (Comment comment in @attendance.Client.Comments)
									{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<p class=\"small\">");
#nullable restore
#line 104 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                                                    Write(comment.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 105 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
									}

#line default
#line hidden
#nullable disable
#nullable restore
#line 105 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                                     
								}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t\t<div>\n\t\t\t\t\t\t\t\t<a href=\"#\" data-toggle=\"modal\" data-target=\"#comment-");
#nullable restore
#line 109 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                                                                                 Write(attendance.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n\t\t\t\t\t\t\t\t<img src=\"/Images/SiteImages/comment.png\" alt=\"comment\" class=\"commentIcon\">\n\t\t\t\t\t\t\t\t</a>\n\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t</div>\n\t\t\t\t\t</td>\n\t\t\t\t</tr>\n\t\t\t\t<div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 3762, "\"", 3789, 2);
            WriteAttributeValue("", 3767, "comment-", 3767, 8, true);
#nullable restore
#line 116 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 3775, attendance.Id, 3775, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
					<div class=""modal-dialog modal-dialog-centered"" role=""document"">
						<div class=""modal-content"">
							<div class=""modal-header"">
								<h5 class=""modal-title"" id=""exampleModalLongTitle"">Добавить комментарий</h5>
								<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
									<span aria-hidden=""true"">&times;</span>
								</button>
							</div>
							<div class=""modal-body"">
							<input type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 4329, "\"", 4357, 1);
#nullable restore
#line 126 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 4337, attendance.ClientId, 4337, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 4358, "\"", 4395, 2);
            WriteAttributeValue("", 4363, "attendanceCountId-", 4363, 18, true);
#nullable restore
#line 126 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 4381, attendance.Id, 4381, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n\t\t\t\t\t\t\t\t<textarea type=\"text\" class=\"form-control\"");
            BeginWriteAttribute("id", " id=\"", 4448, "\"", 4480, 2);
            WriteAttributeValue("", 4453, "commentInput-", 4453, 13, true);
#nullable restore
#line 127 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 4466, attendance.Id, 4466, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></textarea>\n\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t\t<div class=\"modal-footer\">\n\t\t\t\t\t\t\t\t<button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4618, "\"", 4657, 3);
            WriteAttributeValue("", 4628, "sendComment(\'", 4628, 13, true);
#nullable restore
#line 130 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 4641, attendance.Id, 4641, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4655, "\')", 4655, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Отправить</button>\n\t\t\t\t\t\t\t\t<button type=\"button\" class=\"btn btn-primary\" data-dismiss=\"modal\">Закрыть</button>\n\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t</div>\n\t\t\t\t\t</div>\n\t\t\t\t</div>\n\t\t\t\t<div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 4847, "\"", 4883, 2);
            WriteAttributeValue("", 4852, "attendAndComment-", 4852, 17, true);
#nullable restore
#line 136 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 4869, attendance.Id, 4869, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
					<div class=""modal-dialog modal-dialog-centered"" role=""document"">
						<div class=""modal-content"">
							<div class=""modal-header"">
								<h5 class=""modal-title"" id=""exampleModalLongTitle"">Причина</h5>
								<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
									<span aria-hidden=""true"">&times;</span>
								</button>
							</div>
							<div class=""modal-body"">
								<textarea type=""text"" class=""form-control""");
            BeginWriteAttribute("id", " id=\"", 5433, "\"", 5474, 2);
            WriteAttributeValue("", 5438, "commentAndAttendInput-", 5438, 22, true);
#nullable restore
#line 146 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 5460, attendance.Id, 5460, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></textarea>\n\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t\t<div class=\"modal-footer\">\n\t\t\t\t\t\t\t\t<button type=\"button\" class=\"btn btn-outline-secondary\" data-dismiss=\"modal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5620, "\"", 5671, 3);
            WriteAttributeValue("", 5630, "regularAttendAndComment(\'", 5630, 25, true);
#nullable restore
#line 149 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
WriteAttributeValue("", 5655, attendance.Id, 5655, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5669, "\')", 5669, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Отметить</button>\n\t\t\t\t\t\t\t\t<button type=\"button\" class=\"btn btn-outline-dark\" data-dismiss=\"modal\">Закрыть</button>\n\t\t\t\t\t\t\t</div>\n\t\t\t\t\t\t</div>\n\t\t\t\t\t</div>\n\t\t\t\t</div>\t\n");
#nullable restore
#line 155 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
				
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t</tbody>\n\t\t</table>\n\t\t\n\t\n\t</div>\n\t<p class=\"text-hide\" id=\"dateForAttendance\">");
#nullable restore
#line 162 "C:\csharp\Yoga\YogaAshram\yogaAshram\Views\Schedule\PartialViews\_AttendanceCheckPartial.cshtml"
                                           Write(ViewBag.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\t");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Schedule> Html { get; private set; }
    }
}
#pragma warning restore 1591
