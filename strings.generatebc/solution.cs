using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace stringsgeneratebc;

class BCGenerator
{
    private const int AcronymizeLimit = 30;
    private static readonly HashSet<string> IgnoreWords = new()
    {
            "the", "of", "in", "from", "by", "with", "and", "or", "for", "to", "at", "a"
    };

    internal static string GenerateBC(string url, string separator)
    {
        string replacedString = GetReplacedSlashesOnWhitespace(url);
        string removedParameters = RemoveParameters(replacedString);
        string removedAnchor = RemoveAnchor(removedParameters);
        string removedIndex = RemoveIndex(removedAnchor);
        string preparedString = RemoveSuffix(removedIndex);
        //string preparedString = removedSuffix.ToUpper();

        List<string> result = preparedString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        if(result.Count == 1)
        {
            Index homeIndex = 0;
            result[homeIndex] = GetSpanElement("home");
        }
        else
        {
            Index homeIndex = 0;
            result[homeIndex] = GetAElement("/", "home");
            Index lastIndex = result.Count - 1;
            result[lastIndex] = GetSpanElement(GetAcronomyze(result[lastIndex]));
            for(int index = homeIndex.Value + 1; index < lastIndex.Value; index++)
            {
                result[index] = GetAElement($"/{result[index]}/", GetAcronomyze(result[index]));
            }
        }

        return string.Join(separator, result);
    }

    private static string GetAcronomyze(string word)
    {
        if(word.Length >= AcronymizeLimit)
        {
            return Acronymize(word);
        }
        else
        {
            word = Regex.Replace(word, @"-", " ");
            return word;
        }
    }

    internal static string GetSpanElement(string name) =>
        $"<span class=\"active\">{name.ToUpper()}</span>";

    internal static string GetAElement(string href, string name) =>
        $"<a href=\"{href}\">{name.ToUpper()}</a>";

    internal static string GetReplacedSlashesOnWhitespace(string url) =>
        Regex.Replace(url, @"([^\/])\/([^\/])", "$1 $2");
    //Regex.Replace(url, @"\/", " ");

    internal static string RemoveParameters(string url) =>
        Regex.Replace(url, @"\?.+", "");

    internal static string RemoveAnchor(string url) =>
        Regex.Replace(url, @"#.+", "");

    internal static string RemoveIndex(string url) =>
        Regex.Replace(url, @" index\.(html|asp|htm|php)", "");

    internal static string RemoveSuffix(string url) =>
        Regex.Replace(url, @"\.(html|asp|htm|php)", "");

    internal static string Acronymize(string str) => new(
        str
            .Split(new char[] { '-' })
            .Where(word => !IgnoreWords.Contains(Regex.Replace(word, @"/", "")))
            .Select(word => word[0])
            .ToArray()
        );
}
