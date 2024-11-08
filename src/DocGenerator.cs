
using System.Xml.Linq;

namespace DocGenerator.src;
public class DocGenerator
{

    /// <summary>
    /// This is the method to generate a HTML doc based on the XML input file. 
    /// It uses the bootstrap to styles all the HTML. 
    /// 
    /// </summary>
    /// <param name="xdoc">XML File</param>
    /// <returns>Returns a HTML doc.</returns>
    public string GenerateHtmlFromXml(XDocument xdoc)
    {
        string fileName = "WAVit Daily Reporting";
        // Start the HTML document
        string html = @$"<html class=""""><head><title>{fileName}</title>
        <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH"" crossorigin=""anonymous"">
        </head><body>";

        html += @"<main class=""bg-dark text-light"">";
        html += @$"<h1 class=""text-center pt-5"">{fileName}</h1>";
        html +=
         @$"<div class=""d-flex justify-content-center""> <button class=""btn btn-secondary mx-2"" type=""button"">
                <a class=""text-decoration-none text-light"" href=""index.html"">
                    Home Page
                </a>
            </button>";
        html +=
        @$" <button class=""btn btn-secondary mx-2"" type=""button"">
                <a class=""text-decoration-none text-light"" href=""docs.html"">
                    Doc page
                </a>
            </button></div>";

        html += @"<div class=""accordion px-5 mx-auto my-5"" style=""max-width: 1600px;"" id=""accordionExample"">";
        // Iterate through each member in the XML
        var members = xdoc.Descendants("member");
        int idTest = 0;
        foreach (var member in members)
        {
            string? name = member.Attribute("name")?.Value;
            string[] parts = name!.Split('.');


            // TODO - Implement rules for 4 types of members.
            /**
            T:: Indica um tipo (type), que geralmente é uma classe ou estrutura. Por exemplo, T:WAVitReporting2.Controllers.HomeController refere-se à classe HomeController dentro do namespace WAVitReporting2.Controllers.
            M:: Indica um método (method). Por exemplo, M:WAVitReporting2.Controllers.HomeController.SignIn refere-se ao método SignIn da classe HomeController.
            P:: Indica uma propriedade (property). Por exemplo, P:WAVitReporting2.Models.OrganizationUnitProduct.OrganizationUnitId refere-se à propriedade OrganizationUnitId da classe OrganizationUnitProduct.
            E:: Indica um evento (event), caso apareça
            */

            // Console.WriteLine(name); 
            string summary = member.Element("summary")?.Value ?? "No summary available.";
            string remarks = member.Element("remarks")?.Value ?? null!;
            var param = member.Elements("param");

            // Accordion item
            html += @"<div class=""accordion-item border border-secondary bg-black text-light"">";
            html += @$"<h2 class=""accordion-header ""><button class=""accordion-button collapsed text-light bg-black"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#{idTest}"" aria-expanded=""true"" aria-controls=""{idTest}"">";

            html += @$"{name}</button></h2>";
            html += @$"<div id=""{idTest}"" class=""accordion-collapse collapse bg-body-secondary text-light"" data-bs-parent=""#accordionExample"" style='margin-bottom: 15px;'>";

            // Accordion body / content.
            html += @$"<div class=""accordion-body bg-secondary"">";
            html += $"<h3>{parts.Last()}</h3>";
            html += $"<p>{summary}</p>";
            html += $"<p><strong>Params:</strong></p>";
            foreach (var item in param)
            {
                html += $"<p><strong>{item.Attribute("name")}: </strong>{item}</p>";
            }
            if (remarks != null)
            {
                html += $"<p><strong>Remarks:</strong> {remarks}</p>";
            }
            html += "</div></div></div>";
            idTest++;
        }

        html += "</div>";
        // Close the HTML document
        html += @"<script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"" integrity=""sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz"" crossorigin=""anonymous""></script></main></body></html>";

        return html;
    }
    public string GenerateMarkDownDoc(XDocument xdoc, string? fileName)
    {
        if (fileName == null)
        {
            fileName = "Project";
        }
        // Start the HTML document
        string md = @$"<html><head><title>{fileName}</title>
        <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH"" crossorigin=""anonymous"">
        </head><body>";

        md += @$"<h1 class=""text-center mt-5"">{fileName}</h1>";
        md +=
         @$" <button class=""btn btn-secondary mx-2"" type=""button"">
                <a class=""text-decoration-none text-light"" href=""index.html"">
                    Home Page
                </a>
            </button>";
        md +=
        @$" <button class=""btn btn-secondary mx-2"" type=""button"">
                <a class=""text-decoration-none text-light"" href=""docs.html"">
                    Doc page
                </a>
            </button>";

        md += @"<div class=""accordion px-5 my-5"" id=""accordionExample"">";
        // Iterate through each member in the XML
        var members = xdoc.Descendants("member");
        int idTest = 0;
        foreach (var member in members)
        {
            string? name = member.Attribute("name")?.Value;
            string[] parts = name!.Split('.');

            // TODO - Implement rules for 4 types of members.
            /**
            T:: Indica um tipo (type), que geralmente é uma classe ou estrutura. Por exemplo, T:WAVitReporting2.Controllers.HomeController refere-se à classe HomeController dentro do namespace WAVitReporting2.Controllers.
            M:: Indica um método (method). Por exemplo, M:WAVitReporting2.Controllers.HomeController.SignIn refere-se ao método SignIn da classe HomeController.
            P:: Indica uma propriedade (property). Por exemplo, P:WAVitReporting2.Models.OrganizationUnitProduct.OrganizationUnitId refere-se à propriedade OrganizationUnitId da classe OrganizationUnitProduct.
            E:: Indica um evento (event), caso apareça
            */

            string summary = member.Element("summary")?.Value ?? "No summary available.";
            string remarks = member.Element("remarks")?.Value ?? null!;
            var param = member.Elements("param");

            // Accordion item
            md += @"<div class=""accordion-item"">";
            md += @$"<h2 class=""accordion-header""><button class=""accordion-button collapsed"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#{idTest}"" aria-expanded=""true"" aria-controls=""{idTest}"">";

            md += @$"{name}</button></h2>";
            md += @$"<div id=""{idTest}"" class=""accordion-collapse collapse"" data-bs-parent=""#accordionExample"" style='margin-bottom: 15px;'>";
            md += @$"<div class=""accordion-body"">";

            md += $"<h3>{parts.Last()} title</h3>";
            md += $"<p>{summary}</p>";
            foreach (var item in param)
            {
                md += $"<p><strong>Params: {item.Attribute("name")}</strong> - {item.ToString()}</p>";
            }
            if (remarks != null)
            {
                md += $"<p><strong>Remarks:</strong> {remarks}</p>";
            }
            md += "</div></div></div>";
            idTest++;
        }

        md += "</div>";
        // Close the HTML document
        md += @"<script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"" integrity=""sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz"" crossorigin=""anonymous""></script></body></html>";

        return md;
    }
}