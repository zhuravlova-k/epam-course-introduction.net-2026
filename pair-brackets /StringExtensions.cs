using System;
using System.Collections.Generic;

namespace PairBrackets
{
    public static class StringExtensions
    {
        public static int CountBracketPairs(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            int count = 0;
            List<char> list = [];

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == '(' || c == '[')
                {
                    list.Add(c);
                }
                else if (c == ')')
                {
                    if (list.Count > 0 && list[list.Count - 1] == '(')
                    {
                        list.RemoveAt(list.Count - 1);
                        count++;
                    }
                }
                else if (c == ']')
                {
                    if (list.Count <= 0 || list[list.Count - 1] != '[')
                    {
                        continue;
                    }

                    list.RemoveAt(list.Count - 1);
                    count++;
                }
            }

            return count;
        }

        public static IList<(int Start, int End)> GetBracketPairPositions(this string? text)
        {
            ArgumentNullException.ThrowIfNull(text);

            List<(int Start, int End)> result = [];
            Stack<(char Bracket, int Index)> stack = new Stack<(char Bracket, int Index)>();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push((c, i));
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count <= 0)
                    {
                        continue;
                    }

                    var top = stack.Peek();

                    if ((c == ')' && top.Bracket == '(') ||
                        (c == ']' && top.Bracket == '[') ||
                        (c == '}' && top.Bracket == '{'))
                    {
                        _ = stack.Pop();
                        result.Add((top.Index, i));
                    }
                }
            }

            result.Sort((a, b) => a.Start.CompareTo(b.Start));

            return result;
        }

        public static bool ValidateBrackets(this string? text, BracketTypes bracketTypes)
        {
            ArgumentNullException.ThrowIfNull(text);

            LinkedList<char> list = new LinkedList<char>();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                bool isOpening = (c == '(' && (bracketTypes == BracketTypes.All || bracketTypes == BracketTypes.RoundBrackets)) ||
                                 (c == '[' && (bracketTypes == BracketTypes.All || bracketTypes == BracketTypes.SquareBrackets)) ||
                                 (c == '{' && (bracketTypes == BracketTypes.All || bracketTypes == BracketTypes.CurlyBrackets)) ||
                                 (c == '<' && (bracketTypes == BracketTypes.All || bracketTypes == BracketTypes.AngleBrackets));

                bool isClosing = (c == ')' && (bracketTypes == BracketTypes.All || bracketTypes == BracketTypes.RoundBrackets)) ||
                                 (c == ']' && (bracketTypes == BracketTypes.All || bracketTypes == BracketTypes.SquareBrackets)) ||
                                 (c == '}' && (bracketTypes == BracketTypes.All || bracketTypes == BracketTypes.CurlyBrackets)) ||
                                 (c == '>' && (bracketTypes == BracketTypes.All || bracketTypes == BracketTypes.AngleBrackets));

                if (isOpening)
                {
                    _ = list.AddLast(c);
                }
                else if (isClosing)
                {
                    if (list.Count == 0)
                    {
                        return false;
                    }

                    char last = list.Last!.Value;

                    bool isMatch = (c == ')' && last == '(') ||
                                   (c == ']' && last == '[') ||
                                   (c == '}' && last == '{') ||
                                   (c == '>' && last == '<');

                    if (isMatch)
                    {
                        list.RemoveLast();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return list.Count == 0;
        }
    }
}
