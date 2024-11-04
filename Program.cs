using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        // Path to the XML file
        string xmlFilePath = ("C:/Users/hcosta/source/repos/WAVitDailyReporting/WAVitReporting2/bin/Debug/net8.0/WAVitDailyReporting.xml");

        // Load the XML file
        XDocument xdoc = XDocument.Load(xmlFilePath);

        // Generate HTML from the XML
        string html = GenerateHtmlFromXml(xdoc);

        // Save the HTML to a file
        File.WriteAllText("resultado.html", html);

        Console.WriteLine("HTML gerado com sucesso!");
    }

    static string GenerateHtmlFromXml(XDocument xdoc)
    {
        // Start the HTML document
        string html = "<html><head><title>Document Report</title></head><body>";
        html += "<h1>Document Members Summary</h1>";

        // Iterate through each member in the XML
        var members = xdoc.Descendants("member");
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
            
            Console.WriteLine(name);
            string summary = member.Element("summary")?.Value ?? "No summary available.";
            string remarks = member.Element("remarks")?.Value ?? "No remarks available.";

            html += "<div style='margin-bottom: 20px;'>";
            html += $"<h2>{name}</h2>";
            html += $"<p><strong>Summary:</strong> {summary}</p>";
            html += $"<p><strong>Remarks:</strong> {remarks}</p>";
            html += "</div>";
        }

        // Close the HTML document
        html += "</body></html>";

        return html;
    }
}