using System.Xml.Linq;
using Markdig;
class Program
{
    static void Main()
    {
        Console.WriteLine("Starting the generation...");
        // STARTING THE PROGRAM
        string inputFilePath = "./README.md";
        string outputFilePath = "output.html";
        try
        {
            // Read the Markdown file
            string markdown = File.ReadAllText(inputFilePath);

            // Convert Markdown to HTML
            string htmlToMd = Markdown.ToHtml(markdown);
            string htmlToMd2 = Markdown.ToPlainText(markdown);
            
            // Write the HTML to a file
            File.WriteAllText(outputFilePath, htmlToMd);
            File.WriteAllText("testing.txt", htmlToMd2);

            Console.WriteLine("Markdown successfully converted to HTML!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // Creating the instance of the doc generator
        DocGenerator.src.DocGenerator gen = new DocGenerator.src.DocGenerator();
        // Give the project/documentation a name.
        string fileName = "WAVit Daily Reporting";
        // Creating new directory with that name.
        Directory.CreateDirectory($"./{fileName}");
        // Path to the XML file
        string xmlFilePath = "C:/Users/hcosta/source/repos/WAVitDailyReporting/WAVitReporting2/bin/Debug/net8.0/WAVitDailyReporting.xml";

        // Load the XML file
        XDocument xdoc = XDocument.Load(xmlFilePath);

        // Generate HTML from the XML
        string html = gen.GenerateHtmlFromXml(xdoc);
        string myMdDoc = gen.GenerateMarkDownDoc(xdoc, "Name of the file");

        // Save the HTML to a file
        File.WriteAllText($"{fileName}/index.html", html);
        File.WriteAllText($"{fileName}/docs.html", myMdDoc);
        File.WriteAllText($"{fileName}/README.md", fileName);


        Console.WriteLine("HTML generated succesfully!");
    }

   
}

