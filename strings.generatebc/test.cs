using FluentAssertions;
using NUnit.Framework;
using System;

namespace stringsgeneratebc;

[TestFixture]
public class GenerateBCTest
{
    private string[] seps = new string[] { " : ", " / ", " * ", " > ", " + ", " * ", " * ", " # ", " >>> ", " % " };

    private string[] urls = new string[] {
            "mysite.com/pictures/holidays.html",
            "www.codewars.com/users/GiacomoSorbi?ref=CodeWars",
            "www.microsoft.com/docs/index.htm#top",
            "mysite.com/very-long-url-to-make-a-silly-yet-meaningful-example/example.asp",
            "www.very-long-site_name-to-make-a-silly-yet-meaningful-example.com/users/giacomo-sorbi",
            "https://www.linkedin.com/in/giacomosorbi",
            "www.agcpartners.co.uk/",
            "www.agcpartners.co.uk",
            "https://www.agcpartners.co.uk/index.html",
            "http://www.agcpartners.co.uk"
        };

    private string[] anss = new string[] {
            "<a href=\"/\">HOME</a> : <a href=\"/pictures/\">PICTURES</a> : <span class=\"active\">HOLIDAYS</span>",
            "<a href=\"/\">HOME</a> / <a href=\"/users/\">USERS</a> / <span class=\"active\">GIACOMOSORBI</span>",
            "<a href=\"/\">HOME</a> * <span class=\"active\">DOCS</span>",
            "<a href=\"/\">HOME</a> > <a href=\"/very-long-url-to-make-a-silly-yet-meaningful-example/\">VLUMSYME</a> > <span class=\"active\">EXAMPLE</span>",
            "<a href=\"/\">HOME</a> + <a href=\"/users/\">USERS</a> + <span class=\"active\">GIACOMO SORBI</span>",
            "<a href=\"/\">HOME</a> * <a href=\"/in/\">IN</a> * <span class=\"active\">GIACOMOSORBI</span>",
            "<span class=\"active\">HOME</span>",
            "<span class=\"active\">HOME</span>",
            "<span class=\"active\">HOME</span>",
            "<span class=\"active\">HOME</span>"
        };

    [Test]
    public void ExampleTests()
    {
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"\nTest With: {urls[i]}");
            if(i == 5) Console.WriteLine("\nThe one used in the above test was my LinkedIn Profile; if you solved the kata this far and manage to get it, feel free to add me as a contact, message me about the language that you used and I will be glad to endorse you in that skill and possibly many others :)\n\n ");

            Assert.AreEqual(anss[i], BCGenerator.GenerateBC(urls[i], seps[i]));
        }
    }

    [Test]
    public void ShouldReturnOneIfOnlyFirstPart()
    {
        BCGenerator.GenerateBC("www.agcpartners.co.uk/", " * ")
            .Should()
            .Be("<span class=\"active\">HOME</span>");

        BCGenerator.GenerateBC("mysite.com/very-long-url-to-make-a-silly-yet-meaningful-example/example.asp", " > ")
            .Should()
            .Be("<a href=\"/\">HOME</a> > <a href=\"/very-long-url-to-make-a-silly-yet-meaningful-example/\">VLUMSYME</a> > <span class=\"active\">EXAMPLE</span>");

        BCGenerator.GenerateBC("http://twitter.de/kamehameha-pippi-surfer-meningitis-the-bed-to-from/", " . ")
            .Should()
            .Be("<a href=\"/\">HOME</a> . <span class=\"active\">KPSMB</span>");

    }

    [Test]
    public void ShouldReplaceSlashesOnWhitespace()
    {
        BCGenerator
            .GetReplacedSlashesOnWhitespace("https://www.linkedin.com/in/giacomosorbi")
            .Should().Be("https://www.linkedin.com in giacomosorbi");
        BCGenerator
            .GetReplacedSlashesOnWhitespace("https://www.linkedin.com")
            .Should().Be("https://www.linkedin.com");
        BCGenerator
            .GetReplacedSlashesOnWhitespace("https://www.linkedin.com/in")
            .Should().Be("https://www.linkedin.com in");
    }

    [Test]
    public void ShouldRemoveUnnecessaryParameters()
    {
        BCGenerator
            .RemoveParameters("www.codewars.com/users/GiacomoSorbi?ref=CodeWars")
            .Should().Be("www.codewars.com/users/GiacomoSorbi");

        BCGenerator
            .RemoveParameters("www.url.com?codewars=rocks&pippi=rocksToo")
            .Should().Be("www.url.com");
    }

    [Test]
    public void ShouldRemoveAnchors()
    {
        BCGenerator
            .RemoveAnchor("www.microsoft.com/docs/index.htm#top")
            .Should().Be("www.microsoft.com/docs/index.htm");

        BCGenerator
            .RemoveAnchor("www.url.com#lameAnchorExample")
            .Should().Be("www.url.com");
    }

    [Test]
    public void ShouldRemoveIndex()
    {
        BCGenerator
            .RemoveIndex("www.microsoft.com docs index.htm")
            .Should().Be("www.microsoft.com docs");

        BCGenerator
            .RemoveIndex("www.microsoft.com docs index.html")
            .Should().Be("www.microsoft.com docs");

        BCGenerator
            .RemoveIndex("mysite.com very-long-url-to-make-a-silly-yet-meaningful-example index.asp")
            .Should().Be("mysite.com very-long-url-to-make-a-silly-yet-meaningful-example");
    }

    [Test]
    public void ShouldRemoveSuffix()
    {
        BCGenerator
            .RemoveSuffix("mysite.com/very-long-url-to-make-a-silly-yet-meaningful-example/example.asp")
            .Should().Be("mysite.com/very-long-url-to-make-a-silly-yet-meaningful-example/example");
    }

    [Test]
    public void ShouldAcronymize()
    {
        BCGenerator
            .Acronymize("very-long-url-to-make-a-silly-yet-meaningful-example")
            .Should().Be("vlumsyme");
    }
}
