#pragma checksum "D:\Programmierprojekte\GitHub Projekte\SmartHomeProject\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "132861207efffd21adfb2b6d71163b2234620d22"
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
#line 1 "D:\Programmierprojekte\GitHub Projekte\SmartHomeProject\SmartHomeProject\SmartHomeProject\Views\_ViewImports.cshtml"
using SmartHomeProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Programmierprojekte\GitHub Projekte\SmartHomeProject\SmartHomeProject\SmartHomeProject\Views\_ViewImports.cshtml"
using SmartHomeProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"132861207efffd21adfb2b6d71163b2234620d22", @"/Views/Device/DeviceManage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d307d9edf706463a407e13c4dbdc6fed1db3a61", @"/Views/_ViewImports.cshtml")]
    public class Views_Device_DeviceManage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SmartHomeProject.Models.DeviceModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Programmierprojekte\GitHub Projekte\SmartHomeProject\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n    <p>Hallo</p>\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 298, "\"", 333, 3);
            WriteAttributeValue("", 304, "../devices/", 304, 11, true);
#nullable restore
#line 10 "D:\Programmierprojekte\GitHub Projekte\SmartHomeProject\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
WriteAttributeValue("", 315, Model.Image, 315, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 329, ".jpg", 329, 4, true);
            EndWriteAttribute();
            WriteLiteral("></img>\r\n    <p>");
#nullable restore
#line 11 "D:\Programmierprojekte\GitHub Projekte\SmartHomeProject\SmartHomeProject\SmartHomeProject\Views\Device\DeviceManage.cshtml"
   Write(Model.Image);

#line default
#line hidden
#nullable disable
            WriteLiteral(".jpg\"</p>\r\n    <script src=\"../js/alertTest.js\"></script>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SmartHomeProject.Models.DeviceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
