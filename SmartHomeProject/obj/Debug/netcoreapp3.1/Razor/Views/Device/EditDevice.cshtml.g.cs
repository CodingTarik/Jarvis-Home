#pragma checksum "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fdf200e7412c5636d4dacbdf255f36318948f0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Device_EditDevice), @"mvc.1.0.view", @"/Views/Device/EditDevice.cshtml")]
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
#line 1 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
using System.Security.Cryptography.X509Certificates;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fdf200e7412c5636d4dacbdf255f36318948f0f", @"/Views/Device/EditDevice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d307d9edf706463a407e13c4dbdc6fed1db3a61", @"/Views/_ViewImports.cshtml")]
    public class Views_Device_EditDevice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DeviceEditModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("deviceName"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Raspberry Pi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Arduino", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Philips hue", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Sonstige", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Device", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditDeviceSettings", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
  
    ViewData["Title"] = "Edit Devie";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    var devices = new Array();\r\n");
#nullable restore
#line 10 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
     foreach (var device in Model.DeviceModels)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            WriteLiteral("devices.push({name: \"");
#nullable restore
#line 12 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                          Write(device.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", description: \"");
#nullable restore
#line 12 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                                       Write(Html.Raw(device.description.Replace(System.Environment.NewLine, "\\n")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\", type: \"");
#nullable restore
#line 12 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                                                                                                                         Write(device.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", location: \"");
#nullable restore
#line 12 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                                                                                                                                                   Write(device.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", port: \"");
#nullable restore
#line 12 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                                                                                                                                                                             Write(device.port);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", ip: \"");
#nullable restore
#line 12 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                                                                                                                                                                                                 Write(device.ip);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"});\r\n");
#nullable restore
#line 13 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    function SelectionUpdate() {
        var name= document.getElementById(""deviceSelect"").value;
        for (i = 0; i < devices.length; i++)
        {
            if (devices[i].name == name) {
                document.getElementById(""deviceNameNew"").value = devices[i].name;
                document.getElementById(""deviceType"").value = devices[i].type;
                document.getElementById(""deviceDescription"").value = devices[i].description;
                document.getElementById(""deviceLocation"").value = devices[i].location;
                document.getElementById(""deviceIP"").value = devices[i].ip;
                document.getElementById(""devicePort"").value = devices[i].port;
                return;
            }
        }
    }
</script>
<h1 class=""display-4 text-center"">Geräte bearbeiten</h1>
");
#nullable restore
#line 31 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
  
    if (!Model.editingFailed && !String.IsNullOrEmpty(Model.deviceNameEdited))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-dismissible alert-success\">\r\n            <button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n            <strong>Bearbeitung erfolgreich!</strong> Das Gerät <strong>");
#nullable restore
#line 36 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                                                   Write(Model.deviceNameEdited);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> wurde erfolgreich aktualisiert.\r\n        </div>\r\n");
#nullable restore
#line 38 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
    }
    else if (Model.editingFailed && !String.IsNullOrEmpty(Model.deviceNameEdited))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-dismissible alert-danger\">\r\n            <button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>\r\n            <strong>Bearbeitung nicht erfolgreich!</strong> Das Gerät <strong>");
#nullable restore
#line 43 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                                                         Write(Model.deviceNameEdited);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> konnte nicht aktualisiert werden.\r\n        </div>\r\n");
#nullable restore
#line 45 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""alert alert-dismissible alert-secondary"">
    <button type=""button"" class=""close"" data-dismiss=""alert"">&times;</button>
    <strong>Hinweis:</strong> Hier kannst du Geräteeigenschaften ändern. Um Funktioninen zu verwalten, klicke auf den Register <strong>""Funktionen""</strong> 
</div>
<div class=""text-center"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fdf200e7412c5636d4dacbdf255f36318948f0f12876", async() => {
                WriteLiteral("\r\n        <label for=\"exampleSelect1\">Select Device</label>\r\n        <select name=\"selectedDevice\" class=\"form-control\" id=\"deviceSelect\" name=\"deviceName\" onchange=\"SelectionUpdate()\"  >\r\n");
#nullable restore
#line 55 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
             foreach (var device in Model.DeviceModels)
            {
                if (!(device.Name == Model.selectedDeviceName))
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fdf200e7412c5636d4dacbdf255f36318948f0f13727", async() => {
#nullable restore
#line 59 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                                              Write(device.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                         WriteLiteral(device.Name);

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
                WriteLiteral("\r\n");
#nullable restore
#line 60 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fdf200e7412c5636d4dacbdf255f36318948f0f16043", async() => {
#nullable restore
#line 63 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                                                                  Write(device.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                                                             WriteLiteral(device.Name);

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
                WriteLiteral("\r\n");
#nullable restore
#line 64 "C:\Users\Tarik\Documents\GitHub\SmartHomeProject\SmartHomeProject\Views\Device\EditDevice.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        </select>
        <div class=""form-group"">
            <label for=""deviceNameNew"">Geräte Name</label>
            <input type=""text"" class=""form-control"" id=""deviceNameNew""  name=""deviceNameNew"" placeholder=""Geräte Name eingeben"">
        </div>
        <div class=""form-group"">
            <label for=""deviceType"">Geräte Typ</label>
            <select class=""form-control"" id=""deviceType""");
                BeginWriteAttribute("value", " value=\"", 3577, "\"", 3585, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"deviceType\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fdf200e7412c5636d4dacbdf255f36318948f0f19063", async() => {
                    WriteLiteral("Raspberry Pi");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fdf200e7412c5636d4dacbdf255f36318948f0f20309", async() => {
                    WriteLiteral("Arduino");
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
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fdf200e7412c5636d4dacbdf255f36318948f0f21550", async() => {
                    WriteLiteral("Philips hue");
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
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fdf200e7412c5636d4dacbdf255f36318948f0f22795", async() => {
                    WriteLiteral("Sonstige");
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
                WriteLiteral(@"
            </select>
        </div>
        <div class=""form-group"">
            <label for=""deviceDescription"">Beschreibung</label>
            <textarea class=""form-control"" id=""deviceDescription""  name=""deviceDescription"" rows=""3""></textarea>
        </div>
        <div class=""form-group"">
            <label for=""deviceIP"">Geräte-IP</label>
            <input type=""text""  class=""form-control"" id=""deviceIP"" name=""deviceIP"" placeholder=""IP-Addresse eingeben"">
        </div>
        <div class=""form-group"">
            <label for=""devicePort"">Geräte-Port</label>
            <input type=""text"" class=""form-control"" id=""devicePort""  name=""devicePort"" placeholder=""Port Eingeben"">
        </div>
        <div class=""form-group"">
            <label for=""deviceLocation"">Gerätestandort</label>
            <input type=""text"" class=""form-control"" id=""deviceLocation""  name=""deviceLocation"" placeholder=""Standort eingeben"">
        </div>
        <input type=""submit"" value=""Speichern"" class=""btn btn-pr");
                WriteLiteral("imary\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n    <script>\r\n        SelectionUpdate();\r\n    </script>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DeviceEditModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
