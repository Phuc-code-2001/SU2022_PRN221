#pragma checksum "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\PartialViews\_DoctorInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8716839a08ba0e470ba8a08486f1a13eb74f2c66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ShinyTeeth.Pages.PartialViews.Pages_PartialViews__DoctorInfo), @"mvc.1.0.view", @"/Pages/PartialViews/_DoctorInfo.cshtml")]
namespace ShinyTeeth.Pages.PartialViews
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
#line 1 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\_ViewImports.cshtml"
using ShinyTeeth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\PartialViews\_DoctorInfo.cshtml"
using ShinyTeeth.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8716839a08ba0e470ba8a08486f1a13eb74f2c66", @"/Pages/PartialViews/_DoctorInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b586d0190c7d21d984ecefa2ceb32205e69fb228", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_PartialViews__DoctorInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Doctor>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"card\" style=\"min-width: 350px\">\r\n\t<div class=\"card-body\">\r\n\t\t<h4>Doctor</h4>\r\n\t\t<hr />\r\n\t\t<p>\r\n\t\t\t<u>FullName: </u>\r\n\t\t\t<i>");
#nullable restore
#line 11 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\PartialViews\_DoctorInfo.cshtml"
          Write(Model.User.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n\t\t</p>\r\n\t\t<p>\r\n\t\t\t<u>Qualification: </u>\r\n");
#nullable restore
#line 15 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\PartialViews\_DoctorInfo.cshtml"
             if(Model.QualificationURL != null)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 302, "\"", 332, 1);
#nullable restore
#line 17 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\PartialViews\_DoctorInfo.cshtml"
WriteAttributeValue("", 309, Model.QualificationURL, 309, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" >View</a>\r\n");
#nullable restore
#line 18 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\PartialViews\_DoctorInfo.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t</p>\r\n\t\t<p>\r\n\t\t\t<u>Major: </u>\r\n\t\t\t<i>");
#nullable restore
#line 22 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\PartialViews\_DoctorInfo.cshtml"
          Write(Model.Major);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n\t\t</p>\r\n\t\t<p>\r\n\t\t\t<u>Created: </u>\r\n\t\t\t<i>");
#nullable restore
#line 26 "D:\SUMMER 2022\PRN221\Assignment\ShinyTeeth\Pages\PartialViews\_DoctorInfo.cshtml"
          Write(Model.Created.ToLocalTime());

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n\t\t</p>\r\n\t</div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Doctor> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
