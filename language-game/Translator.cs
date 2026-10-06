using System;

namespace LanguageGame;

public static class Translator
{
    /// <summary>
    /// Translates from English to Pig Latin. Pig Latin obeys a few simple following rules:
    /// - if word starts with vowel sounds, the vowel is left alone, and most commonly 'yay' is added to the end;
    /// - if word starts with consonant sounds or consonant clusters, all letters before the initial vowel are
    ///   placed at the end of the word sequence. Then, "ay" is added.
    /// Note: If a word begins with a capital letter, then its translation also begins with a capital letter,
    /// if it starts with a lowercase letter, then its translation will also begin with a lowercase letter.
    /// </summary>
    /// <param name="phrase">Source phrase.</param>
    /// <returns>Phrase in Pig Latin.</returns>
    /// <exception cref="ArgumentException">Thrown if phrase is null or empty.</exception>
    public static string TranslateToPigLatin(string phrase)
    {
        if (string.IsNullOrWhiteSpace(phrase))
        {
            throw new ArgumentException("Source string cannot be null or empty or whitespace.", nameof(phrase));
        }

        string[] words = phrase.Split(' ');
        string[] translatedWords = new string[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            string token = words[i];

            if (string.IsNullOrEmpty(token))
            {
                translatedWords[i] = string.Empty;
                continue;
            }

            string punctuation = string.Empty;
            int len = token.Length;
            while (len > 0 && !char.IsLetterOrDigit(token[len - 1]))
            {
                len--;
            }

            if (len < token.Length)
            {
                punctuation = token.Substring(len);
                token = token.Substring(0, len);
            }

            if (string.IsNullOrEmpty(token))
            {
                translatedWords[i] = punctuation;
                continue;
            }

            string[] subWords = token.Split('-');
            string[] translatedSubWords = new string[subWords.Length];

            for (int k = 0; k < subWords.Length; k++)
            {
                translatedSubWords[k] = TranslateWord(subWords[k]);
            }

            translatedWords[i] = string.Join("-", translatedSubWords) + punctuation;
        }

        return string.Join(" ", translatedWords);
    }

    private static string TranslateWord(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return word;
        }

        bool isCapitalized = char.IsUpper(word[0]);

#pragma warning disable CA1308 // Normalize strings to uppercase
        string lowerWord = word.ToLowerInvariant();
#pragma warning restore CA1308 // Normalize strings to uppercase

        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        int firstVowelIndex = lowerWord.IndexOfAny(vowels);

        string result;

        if (firstVowelIndex == 0)
        {
            result = lowerWord + "yay";
        }
        else if (firstVowelIndex > 0)
        {
            string consonants = lowerWord.Substring(0, firstVowelIndex);
            string rest = lowerWord.Substring(firstVowelIndex);
            result = rest + consonants + "ay";
        }
        else
        {
            result = lowerWord + "ay";
        }

        if (isCapitalized && result.Length > 0)
        {
            result = char.ToUpperInvariant(result[0]) + result.Substring(1);
        }

        return result;
    }
}