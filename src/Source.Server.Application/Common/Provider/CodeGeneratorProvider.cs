using System.Text.RegularExpressions;
using Source.EF.Bases.Entities;

namespace Source.Server.Application.Common.Provider;

public interface ICodeGeneratorProvider
{
    Task<string> GenerateAsync<T>(
        IEnumerable<T> lstValues,
        IEnumerable<string>? lstIgnoreWordCases)
        where T : class, IBaseEntityDetails;
}

public class CodeGeneratorProvider : ICodeGeneratorProvider
{
    private const string CODE_FORMAT = "XX99XXX99XX";
    private const string TEXT_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string NUMBER_CHARS = "0123456789";
    private static Random _random = default!;

    public CodeGeneratorProvider()
    {
        _random = new Random();
    }

    public async Task<string> GenerateAsync<T>(
        IEnumerable<T> lstValues,
        IEnumerable<string>? lstIgnoreWordCases)
        where T : class, IBaseEntityDetails
    {
        List<string> patternStrs = new();

        char[] patternChars = CODE_FORMAT.ToCharArray();

        int index = 0;

        char currentPatternChar = patternChars[index];

        string itemResult = string.Empty;

        while (index < patternChars.Length)
        {
            if (currentPatternChar == patternChars[index])
            {
                itemResult += patternChars[index];

                index++;

                if (index >= patternChars.Length)
                {
                    patternStrs.Add(itemResult);
                }
            }
            else
            {
                currentPatternChar = patternChars[index];

                patternStrs.Add(itemResult);

                itemResult = string.Empty;
            }
        }

        string generatedCode = string.Empty;
        foreach (string item in patternStrs)
        {
            if (Regex.IsMatch(item, @"^\d+$", RegexOptions.Compiled))
            {
                generatedCode += string.Concat(Enumerable.Repeat(NUMBER_CHARS, item.Length).Select(s => s[_random.Next(s.Length)]).ToArray());
            }
            else
            {
                generatedCode += string.Concat(Enumerable.Repeat(TEXT_CHARS, item.Length).Select(s => s[_random.Next(s.Length)]).ToArray());
            }
        }

        if (lstIgnoreWordCases != null && lstIgnoreWordCases.Any())
        {
            if (lstIgnoreWordCases.Any(ignoreStr => generatedCode.Contains(ignoreStr)))
            {
                generatedCode = await GenerateAsync(lstValues, lstIgnoreWordCases);
            }
        }

        if (lstValues.Any(e => e.Code.Trim().ToUpper().Equals(generatedCode.Trim().ToUpper())))
        {
            generatedCode = await GenerateAsync(lstValues, lstIgnoreWordCases);
        }

        return generatedCode;
    }
}
