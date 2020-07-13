#pragma checksum "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "667473def94bbaf87f75f602b4873a9ad26a9c8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"667473def94bbaf87f75f602b4873a9ad26a9c8c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d307d9edf706463a407e13c4dbdc6fed1db3a61", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SmartHomeProject.Models.DeviceManageModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top: 5%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""lib/jquery/dist/jquery.min.js""></script>
<script type=""text/javascript"">

    var soundFile = document.createElement(""audio"");
    soundFile.preload = ""auto"";
    var src = document.createElement(""source"");
    src.src = ""../sound/welcome.mp3"";
    soundFile.appendChild(src);

    soundFile.load();
    soundFile.volume = 0.0;
    soundFile.play();

    function playSound() {
        soundFile.currentTime = 0.00;
        soundFile.volume = 1;
        soundFile.play();
    }

</script>
<div class=""jumbotron"">
    <h1 class=""display-3"">Wilkommen zurück!</h1>
    <p class=""lead"">Mein Name ist Jarvis, ich bin hier, um dich Tag und Nacht zu unterstützen.</p>
    <hr class=""my-4"">
    <p>© David Noll und Tarik Azzouzi</p>
    <p class=""lead"">
        <button class=""btn btn-primary btn-lg"" role=""button"" onclick=""playSound()"">Klicke hier, um mehr zu erfahren.</button>
    </p>
</div>
<div class=""text-center"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "667473def94bbaf87f75f602b4873a9ad26a9c8c4847", async() => {
                WriteLiteral("\r\n        <table class=\"table table-hover\">\r\n            <tr class=\"table-primary\">\r\n                <th>Name</th>\r\n                <th>Raum</th>\r\n                <th>Status</th>\r\n            </tr>\r\n");
#nullable restore
#line 42 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Home\Index.cshtml"
             foreach (var device in Model.DeviceModels)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td class=\"devicename\">");
#nullable restore
#line 45 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Home\Index.cshtml"
                                      Write(device.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 46 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Home\Index.cshtml"
                   Write(device.Location);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td><span");
                BeginWriteAttribute("id", " id=\"", 1516, "\"", 1542, 2);
#nullable restore
#line 47 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Home\Index.cshtml"
WriteAttributeValue("", 1521, device.Name, 1521, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1535, "-status", 1535, 7, true);
                EndWriteAttribute();
                WriteLiteral(" class=\"badge badge-danger\">Offline</span></td>\r\n                </tr>\r\n");
#nullable restore
#line 49 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </table>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <script src=\"js/DeviceStatus.js\"></script>\r\n</div>\r\n");
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
