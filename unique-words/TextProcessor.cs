using System;
using System.Collections.Generic;

namespace UniqueWords;

public static class TextProcessor
{
    public static List<string> GetUniqueWordsFromArray(string[] words)
    {
        ArgumentNullException.ThrowIfNull(words);

        List<string> list = new List<string>();

        for (int i = 0; i < words.Length; i++)
        {
            if (!list.Contains(words[i]))
            {
                list.Add(words[i]);
            }
        }

        return list;
    }

    public static int CountUniqueWordsInText(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return 0;
        }

        List<string> list = new List<string>();
        int position = 0;

        while (position < text.Length)
        {
            int spaceIndex = text.IndexOf(' ', position);

            if (spaceIndex == position)
            {
                position++;
            }
            else
            {
                if (spaceIndex < 0)
                {
                    spaceIndex = text.Length;
                }

                string word = text[position..spaceIndex];

                if (!list.Contains(word))
                {
                    list.Add(word);
                }

                position = spaceIndex + 1;
            }
        }

        return list.Count;
    }

    public static IEnumerable<string> GetUniqueWordsFromEnumerable(IEnumerable<string> lines)
    {
        ArgumentNullException.ThrowIfNull(lines);

        List<string> list = new List<string>();

        foreach (string line in lines)
        {
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (string word in words)
            {
                if (!list.Contains(word))
                {
                    list.Add(word);
                }
            }
        }

        return list;
    }

    public static string[][] GetUniqueWordsArray(IEnumerable<string> lines, char separator)
    {
        ArgumentNullException.ThrowIfNull(lines);

        List<string[]> result = new List<string[]>();
        List<string> allSeenWords = new List<string>();

        foreach (string line in lines)
        {
            List<string> lineUniqueWords = new List<string>();
            int position = 0;

            while (position < line.Length)
            {
                int sepIndex = line.IndexOf(separator, position);

                if (sepIndex == position)
                {
                    position++;
                    continue;
                }

                if (sepIndex < 0)
                {
                    sepIndex = line.Length;
                }

                string word = line.Substring(position, sepIndex - position).Replace(" ", string.Empty, StringComparison.Ordinal);

                if (word.Length > 0 && !allSeenWords.Contains(word))
                {
                    lineUniqueWords.Add(word);
                    allSeenWords.Add(word);
                }

                position = sepIndex + 1;
            }

            result.Add(lineUniqueWords.ToArray());
        }

        return result.ToArray();
    }

    public static ICollection<string> GetUniqueWordsCollection(string text, char separator)
    {
        List<string> list = new List<string>();
        if (string.IsNullOrEmpty(text))
        {
            return list;
        }

        int position = 0;

        while (position < text.Length)
        {
            int nextSep = text.IndexOf(separator, position);
            int nextNewLine = text.IndexOf(Environment.NewLine, position, StringComparison.Ordinal);

            int endPos = text.Length;
            int advance = 1;

            if (nextSep >= 0 && nextNewLine >= 0)
            {
                if (nextSep < nextNewLine)
                {
                    endPos = nextSep;
                    advance = 1;
                }
                else
                {
                    endPos = nextNewLine;
                    advance = Environment.NewLine.Length;
                }
            }
            else if (nextSep >= 0)
            {
                endPos = nextSep;
                advance = 1;
            }
            else if (nextNewLine >= 0)
            {
                endPos = nextNewLine;
                advance = Environment.NewLine.Length;
            }

            if (endPos > position)
            {
                string word = text[position..endPos];
                if (!list.Contains(word))
                {
                    list.Add(word);
                }
            }

            position = endPos + advance;
        }

        return list;
    }

    public static ICollection<string> GetUniqueWordsInCharCollection(ICollection<char> collection, char separator)
    {
        ArgumentNullException.ThrowIfNull(collection);

        List<string> uniqueWords = new List<string>();
        List<char> currentWordChars = new List<char>();

        foreach (char c in collection)
        {
            if (c == separator)
            {
                if (currentWordChars.Count > 0)
                {
                    string word = new string(currentWordChars.ToArray());
                    if (!uniqueWords.Contains(word))
                    {
                        uniqueWords.Add(word);
                    }

                    currentWordChars.Clear();
                }
            }
            else if (c != ' ')
            {
                currentWordChars.Add(c);
            }
        }

        if (currentWordChars.Count > 0)
        {
            string word = new string(currentWordChars.ToArray());
            if (!uniqueWords.Contains(word))
            {
                uniqueWords.Add(word);
            }
        }

        return uniqueWords;
    }
}
