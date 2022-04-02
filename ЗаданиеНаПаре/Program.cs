using System.ComponentModel;
using System.Text;

namespace MyNamespace;

class Program
{
    public static void Main()
    {
        string[] staples = new[]
        {
            "{[()]}",
            "{[(])}",
            "{{[[(())]]}}",
        };
        Staples staple = new Staples();
        foreach (string e in staples)
        {
            Console.WriteLine(staple.IsCorrect(e));
        }
        /*char[] letters = new char[] { 'г', 'б', 'а', 'в', 'о', 'к' };
        int wordLength = 2;
        WordCombination wordCombination = new WordCombination();
        wordCombination.MakeWord(letters, wordLength);*/
    }
}

class Staples
{
    public string IsCorrect(string staples)
    {
        if (staples.Length % 2 != 0) return "NO";
        char[] symbols = staples.ToCharArray();
        for (int i = 0; i < staples.Length / 2; i++)
        {
            if (symbols[i] == '(' && symbols[symbols.Length - 1 - i] != ')' ||
                symbols[i] == '[' && symbols[symbols.Length - 1 - i] != ']' ||
                symbols[i] == '{' && symbols[symbols.Length - 1 - i] != '}') return "NO";
        }
        return "YES";
    }
}

class WordCombination
{
    private string path = "russian.txt";

    public void MakeWord(char[] letters, int wordLength)
    {
        string[] file = File.ReadAllLines(path);
        for (int i = 0; i < file.Length; i++)
        {
            if (file[i].Length == wordLength)
            {
                if (IsSymbolCorrect(file[i], letters)) Console.WriteLine(file[i]);
            }
        }
    }

    private bool IsSymbolCorrect(string word, char[] letters)
    {
        int count = 0;
        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (word[i].ToString() == letters[j].ToString()) count++;
            }
        }
        if (word.Length != count) return false;
        return true;
    }
}

