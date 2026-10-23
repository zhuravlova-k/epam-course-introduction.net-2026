using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuplicateWords;

public static class TextProcessor
{
    public static int CountDuplicateWords(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return 0;
        }

        List<char> wordChars = [];
        List<string> words = [];
        List<int> counters = [];

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            bool isSpace = c == ' ';

            if (!isSpace)
            {
                wordChars.Add(c);
            }

            bool isSpaceAfterWord = isSpace && wordChars.Count > 0;
            bool isLastChar = !isSpace && i == text.Length - 1;

            if (isSpaceAfterWord || isLastChar)
            {
                string word = new string(wordChars.ToArray());
                int wordIndex = words.IndexOf(word);

                if (wordIndex < 0)
                {
                    words.Add(word);
                    counters.Add(1);
                }
                else
                {
                    counters[wordIndex]++;
                }

                wordChars.Clear();
            }
        }

        int duplicateCounter = 0;
        for (int j = 0; j < words.Count; j++)
        {
            if (counters[j] > 1)
            {
                duplicateCounter++;
            }
        }

        return duplicateCounter;
    }

    public static int GetTotalDuplicateWordsNumber(IList<string> lines)
    {
        ArgumentNullException.ThrowIfNull(lines);

        var builder = new StringBuilder();
        Dictionary<string, int> counters = [];

        for (int i = 0; i < lines.Count; i++)
        {
            string line = lines[i];
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            for (int j = 0; j < line.Length; j++)
            {
                char c = line[j];
                bool isLetterOrDigit = char.IsLetterOrDigit(c);

                if (isLetterOrDigit)
                {
                    _ = builder.Append(c);
                }

                bool isEndOfWord = (!isLetterOrDigit && builder.Length > 0) || (isLetterOrDigit && j == line.Length - 1);

                if (isEndOfWord)
                {
                    string word = builder.ToString();
                    if (counters.TryGetValue(word, out var value))
                    {
                        counters[word] = ++value;
                    }
                    else
                    {
                        counters[word] = 1;
                    }

                    _ = builder.Clear();
                }
            }
        }

        int totalDuplicates = 0;
        foreach (var kvp in counters)
        {
            if (kvp.Value > 1)
            {
                totalDuplicates += kvp.Value;
            }
        }

        return totalDuplicates;
    }

    public static IList<string> GetDuplicateWords(ICollection<string>? lines)
    {
        ArgumentNullException.ThrowIfNull(lines);

        HashSet<string> words = [];
        HashSet<string> duplicates = [];

        foreach (string line in lines)
        {
            int i = 0;
            while (i < line.Length)
            {
                int spaceIndex = line.IndexOf(' ', i);
                if (spaceIndex < 0)
                {
                    spaceIndex = line.Length;
                }

                if (spaceIndex > i)
                {
                    string word = line[i..spaceIndex];
                    if (!words.Add(word))
                    {
                        _ = duplicates.Add(word);
                    }
                }

                i = spaceIndex + 1;
            }
        }

        return duplicates.ToList();
    }

    public static ICollection<string> GetUniqueWords(IEnumerable<string>? lines, bool ignoreCase)
    {
        ArgumentNullException.ThrowIfNull(lines);

        StringComparer comparer = ignoreCase ? StringComparer.InvariantCultureIgnoreCase : StringComparer.InvariantCulture;
        HashSet<string> seen = new HashSet<string>(comparer);
        HashSet<string> duplicates = new HashSet<string>(comparer);

        foreach (string line in lines)
        {
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (string word in words)
            {
                if (!seen.Add(word))
                {
                    _ = duplicates.Add(word);
                }
            }
        }

        seen.ExceptWith(duplicates);

        List<string> result = new List<string>(seen);
        result.Sort(comparer);

        return result;
    }

    public static void RemoveDuplicateWordsInStringBuilder(StringBuilder? stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        var wordChars = new StringBuilder();
        HashSet<string> words = [];

        string text = stringBuilder.ToString();
        _ = stringBuilder.Clear();

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];

            if (char.IsLetterOrDigit(c))
            {
                _ = wordChars.Append(c);
            }
            else
            {
                if (wordChars.Length > 0)
                {
                    string word = wordChars.ToString();
                    if (words.Add(word))
                    {
                        _ = stringBuilder.Append(word);
                    }

                    _ = wordChars.Clear();
                }

                _ = stringBuilder.Append(c);
            }
        }

        if (wordChars.Length > 0)
        {
            string word = wordChars.ToString();
            if (words.Add(word))
            {
                _ = stringBuilder.Append(word);
            }
        }
    }

    public static void RemoveDuplicateWordsInString(ref string? text, bool ignoreCase)
    {
        ArgumentNullException.ThrowIfNull(text);

        StringComparer comparer = ignoreCase ? StringComparer.InvariantCultureIgnoreCase : StringComparer.InvariantCulture;
        HashSet<string> seen = new HashSet<string>(comparer);
        StringBuilder result = new StringBuilder();

        int start = -1;

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];

            if (char.IsLetterOrDigit(c))
            {
                if (start == -1)
                {
                    start = i;
                }
            }
            else
            {
                if (start != -1)
                {
                    string word = text[start..i];
                    if (seen.Add(word))
                    {
                        _ = result.Append(word);
                    }

                    start = -1;
                }

                _ = result.Append(c);
            }
        }

        if (start != -1)
        {
            string word = text[start..^0];
            if (seen.Add(word))
            {
                _ = result.Append(word);
            }
        }

        text = result.ToString();
    }
}
