using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

public class ProgrammingLanguage
{
    public string Name { get; set; }
    public int Appeared { get; set; }
    public string Creator { get; set; }
}

public class Languages
{
    public List<ProgrammingLanguage> LanguageList { get; set; } = new List<ProgrammingLanguage>();
}

public static class XmlParser
{
    public static Languages ParseXmlToLanguages(string xmlFilePath)
    {
        XDocument doc = XDocument.Load(xmlFilePath);
        Languages languages = new Languages();

        foreach (XElement langElement in doc.Descendants("lang"))
        {
            ProgrammingLanguage language = new ProgrammingLanguage
            {
                Name = langElement.Attribute("name")?.Value.Trim(),
                Appeared = int.Parse(langElement.Element("appeared")?.Value.Trim()),
                Creator = langElement.Element("creator")?.Value.Trim()
            };

            languages.LanguageList.Add(language);
        }

        return languages;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string xmlFilePath = @"C:\Users\plesk\source\repos\ConsoleApp6\XMLFile1.xml";

        Languages languages = XmlParser.ParseXmlToLanguages(xmlFilePath);

        Console.WriteLine("Programming Languages:");
        foreach (var language in languages.LanguageList)
        {
            Console.WriteLine($"Name: {language.Name}");
            Console.WriteLine($"Appeared: {language.Appeared}");
            Console.WriteLine($"Creator: {language.Creator}");
            Console.WriteLine();
        }
    }
}
