#pragma checksum "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d9b2a5680ed9c64336c7e82a385ba32a448281b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Housing_Index), @"mvc.1.0.view", @"/Views/Housing/Index.cshtml")]
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
#line 1 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\_ViewImports.cshtml"
using Apartment.App.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\_ViewImports.cshtml"
using Apartment.App.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d9b2a5680ed9c64336c7e82a385ba32a448281b", @"/Views/Housing/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a1edcc16e96f8971bdd1f91521b1b3c3d72f7cc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Housing_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Apartment.App.Web.Models.HousingViewModels.HousingViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1>Daire Y??netim Penceresi</h1>
 
<table class=""table table-striped"">
    <thead>
    <tr>
        <th>Ev Durumu</th>
        <th>Kirac?? M???</th>
        <th>Blok</th>
        <th>Kat</th>
        <th>No</th>
        <th>Tip</th>
        <th>????lemler</th>
    </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
     foreach (var housing in Model.HousingList)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n");
#nullable restore
#line 24 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                 if (housing.IsEmpty)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <b>BO??</b>\r\n");
#nullable restore
#line 27 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <b>DOLU </b>\r\n");
#nullable restore
#line 31 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                    
                   
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n            <td>\r\n");
#nullable restore
#line 36 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                 if (housing.IsHomeowner)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <b>EV SAH??B??</b>\r\n");
#nullable restore
#line 39 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <b>K??RACI</b>\r\n");
#nullable restore
#line 43 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>");
#nullable restore
#line 46 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
           Write(housing.BlockNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 47 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
           Write(housing.FloorNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 48 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
           Write(housing.ApartmentNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 49 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
           Write(housing.ApartmentSizeInfo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n");
#nullable restore
#line 51 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                     if (Model.isUserAdmin)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                         if (housing.IsEmpty == false)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1437, "\"", 1500, 1);
#nullable restore
#line 55 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
WriteAttributeValue("", 1444, Url.Action("Add", "Invoice",new{housingId=@housing.Id}), 1444, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Yeni Fatura Ekle</a>\r\n");
#nullable restore
#line 56 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1659, "\"", 1727, 1);
#nullable restore
#line 59 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
WriteAttributeValue("", 1666, Url.Action("AddHirer", "Housing",new{housingId=@housing.Id}), 1666, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Kirac?? Ekle</a>\r\n");
#nullable restore
#line 60 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1849, "\"", 1907, 1);
#nullable restore
#line 62 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
WriteAttributeValue("", 1856, Url.Action("Index", "Invoice",new{id=@housing.Id}), 1856, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Faturalar?? G??r??nt??le</a>\r\n");
#nullable restore
#line 63 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                    }
                    else 
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 2058, "\"", 2096, 1);
#nullable restore
#line 66 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
WriteAttributeValue("", 2065, Url.Action("Index", "Invoice"), 2065, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Faturalar??ma Git</a>\r\n");
#nullable restore
#line 67 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n        </tr>\r\n");
#nullable restore
#line 70 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n  \r\n");
#nullable restore
#line 74 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
 if (Model.isUserAdmin)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 2267, "\"", 2303, 1);
#nullable restore
#line 76 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
WriteAttributeValue("", 2274, Url.Action("Index", "Block"), 2274, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Yeni Ev Ekle</a>\r\n");
#nullable restore
#line 77 "C:\Users\mac\Desktop\vs2022\Mustafa-Gundogdu_Final_Homework\Apartment.App\Apartment.App.Web\Views\Housing\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Apartment.App.Web.Models.HousingViewModels.HousingViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
