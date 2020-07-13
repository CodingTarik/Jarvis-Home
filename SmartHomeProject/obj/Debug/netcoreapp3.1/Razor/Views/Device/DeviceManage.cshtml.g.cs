#pragma checksum "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c249861ef92c8b1f60fde5ded28afcf3314838a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Device_DeviceManage), @"mvc.1.0.view", @"/Views/Device/DeviceManage.cshtml")]
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
#line 1 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\_ViewImports.cshtml"
using SmartHomeProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\_ViewImports.cshtml"
using SmartHomeProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
using System.Data.Entity.Core.Metadata.Edm;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c249861ef92c8b1f60fde5ded28afcf3314838a0", @"/Views/Device/DeviceManage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d307d9edf706463a407e13c4dbdc6fed1db3a61", @"/Views/_ViewImports.cshtml")]
    public class Views_Device_DeviceManage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SmartHomeProject.Models.DeviceManageModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Device", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditDevice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteDevice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_DeviceLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Geräte verwalten</h1>\r\n");
#nullable restore
#line 11 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
      
        if (!Model.deleteErrored && !String.IsNullOrEmpty(Model.deletedDeviceName))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert alert-dismissible alert-success\">\r\n                <button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n                <strong>Löschung Erfolgreich!</strong> Das Gerät <strong>");
#nullable restore
#line 16 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
                                                                    Write(Model.deletedDeviceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> wurde erfolgreich gelöscht.\r\n            </div>\r\n");
#nullable restore
#line 18 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
        }
        else if (Model.deleteErrored && !String.IsNullOrEmpty(Model.deletedDeviceName))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert alert-dismissible alert-danger\">\r\n                <button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n                <strong>Löschung nicht Erfolgreich!</strong> Das Gerät <strong>");
#nullable restore
#line 24 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
                                                                          Write(Model.deletedDeviceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> konnte nicht gelöscht werden.\r\n            </div>\r\n");
#nullable restore
#line 26 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""alert alert-dismissible alert-secondary"">
                <button type=""button"" class=""close"" data-dismiss=""alert"">&times;</button>
                <strong>Tipp:</strong> Mit ""Add Device"" kannst du neue Geräte hinzufügen.
            </div>
");
#nullable restore
#line 33 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
        }
       
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-hover"">
        <tr class=""table-primary"">
            <th>Device name</th>
            <th>Symbol</th>
            <th>Type</th>
            <th>Location</th>
            <th>IP</th>
            <th>Port</th>
            <th>Status</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
");
#nullable restore
#line 48 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
         foreach (var device in Model.DeviceModels)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"devicename\">");
#nullable restore
#line 51 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
                                  Write(device.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 1987, "\"", 2074, 1);
#nullable restore
#line 53 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
WriteAttributeValue("", 1993, String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(device.Image)), 1993, 81, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"20%\" height=\"20%\" />\r\n                </td>\r\n                <td>");
#nullable restore
#line 55 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
               Write(device.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 56 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
               Write(device.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 57 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
               Write(device.ip);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 58 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
               Write(device.port);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><span");
            BeginWriteAttribute("id", " id=\"", 2311, "\"", 2337, 2);
#nullable restore
#line 59 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
WriteAttributeValue("", 2316, device.Name, 2316, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2330, "-status", 2330, 7, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"badge badge-danger\">Offline</span></td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c249861ef92c8b1f60fde5ded28afcf3314838a010982", async() => {
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"model\"");
                BeginWriteAttribute("value", " value=\"", 2556, "\"", 2576, 1);
#nullable restore
#line 62 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
WriteAttributeValue("", 2564, device.Name, 2564, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"submit\" class=\"btn btn-primary\" name=\"Edit\" value=\"Edit\" />\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c249861ef92c8b1f60fde5ded28afcf3314838a013479", async() => {
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"model\"");
                BeginWriteAttribute("value", " value=\"", 2947, "\"", 2967, 1);
#nullable restore
#line 68 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
WriteAttributeValue("", 2955, device.Name, 2955, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"submit\" class=\"btn btn-danger\" name=\"Delete\" value=\"Delete\" />\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnURL", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
                                                                                     WriteLiteral(Context.Request.Path);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnURL"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnURL", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnURL"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n    <script src=\"../js/DeviceStatus.js\"></script>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SmartHomeProject.Models.DeviceManageModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
