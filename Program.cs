using System.Xml.Linq;

class Program
{
    static void Main()
    {
        // Give the project/documentation a name.
        string fileName = "WAVit Daily Reporting";
        // Creating new directory with that name.
        Directory.CreateDirectory($"./{fileName}");
        // Path to the XML file
        string xmlFilePath = ("C:/Users/hcosta/source/repos/WAVitDailyReporting/WAVitReporting2/bin/Debug/net8.0/WAVitDailyReporting.xml");

        // Load the XML file
        XDocument xdoc = XDocument.Load(xmlFilePath);

        // Generate HTML from the XML
        string html = GenerateHtmlFromXml(xdoc);

        // Save the HTML to a file
        File.WriteAllText($"{fileName}/index.html", html);

        File.WriteAllText($"{fileName}/README.md", html);

        Console.WriteLine("HTML gerado com sucesso!");
    }

    static string GenerateHtmlFromXml(XDocument xdoc)
    {
        // Start the HTML document

        string html = @"<html><head><title>Document Report</title>
        <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH"" crossorigin=""anonymous"">
        </head><body>";


        html += @"<h1 class=""text-center mt-5"">Document Members Summary</h1>";
        html += @"<div class=""accordion px-5 my-5"" id=""accordionExample"">";
        // Iterate through each member in the XML
        var members = xdoc.Descendants("member");
        int idTest = 0;
        foreach (var member in members)
        {
            string? name = member.Attribute("name")?.Value;

            // TODO - Implement rules for 4 types of members.
            /**
            T:: Indica um tipo (type), que geralmente é uma classe ou estrutura. Por exemplo, T:WAVitReporting2.Controllers.HomeController refere-se à classe HomeController dentro do namespace WAVitReporting2.Controllers.
            M:: Indica um método (method). Por exemplo, M:WAVitReporting2.Controllers.HomeController.SignIn refere-se ao método SignIn da classe HomeController.
            P:: Indica uma propriedade (property). Por exemplo, P:WAVitReporting2.Models.OrganizationUnitProduct.OrganizationUnitId refere-se à propriedade OrganizationUnitId da classe OrganizationUnitProduct.
            E:: Indica um evento (event), caso apareça
            */

            // Console.WriteLine(name);
            string summary = member.Element("summary")?.Value ?? "No summary available.";
            string remarks = member.Element("remarks")?.Value ?? "No remarks available.";
            var param = member.Elements("param");

            // Accordion item
            html += @"<div class=""accordion-item"">";
            html += @$"<h2 class=""accordion-header""><button class=""accordion-button collapsed"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#{idTest}"" aria-expanded=""true"" aria-controls=""{idTest}"">"; 
            
            html += @$"{name}</button></h2>";
            html += @$"<div id=""{idTest}"" class=""accordion-collapse collapse"" data-bs-parent=""#accordionExample"" style='margin-bottom: 20px;'>";
            html += @$"<div class=""accordion-body""";
            html += $"<p><strong>Summary:</strong> {summary}</p>";
            foreach (var item in param)
            {
                html += $"<p><strong>Params: {item.Attribute("name")}</strong> - {item.ToString()}</p>";
            }
            html += $"<p><strong>Remarks:</strong> {remarks}</p>";
            html += "</div></div></div>";
            idTest++;
        }

        html += "</div>";
        // Close the HTML document
        html += @"<script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"" integrity=""sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz"" crossorigin=""anonymous""></script></body></html>";

        return html;
    }
}