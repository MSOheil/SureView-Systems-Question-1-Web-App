


namespace TextOperation_Application.Common.Interfaces.Regex;

public interface IRegexService
{
    /// <summary>
    /// create object of regex with pattern
    /// </summary>
    /// <param name="pattern">pattern text</param>
    /// <returns></returns>
    System.Text.RegularExpressions.Regex CreatePatternObjectOfRegex(string pattern);
    /// <summary>
    /// Checks input text with regex pattern and return response
    /// </summary>
    /// <param name="inputText">input text for check with pattern</param>
    /// <param name="pattern">our pattern for check with input text</param>
    /// <returns></returns>
    System.Text.RegularExpressions.Match CheckTextIsMatchWithInputText(string inputText, System.Text.RegularExpressions.Regex pattern);
    /// <summary>
    /// check result of check pattern and return right answer
    /// </summary>
    /// <param name="matchOperation">result of check match operation</param>
    /// <param name="serverNumberIndex">server number index in pattern text</param>
    /// <param name="alarmNumberIndex">alarm number index in pattern text</param>
    /// <returns></returns>
    Response<ShowResultOfCheckVideoMessageDto> CheckTextResult(System.Text.RegularExpressions.Match matchOperation
        , int serverNumberIndex, int alarmNumberIndex);
    /// <summary>
    /// Check input text validation and 
    /// </summary>
    /// <param name="inputText">input text for check with pattern</param>
    /// <returns></returns>
    Response<ShowResultOfCheckVideoMessageDto> CheckInputTextValidation(string inputText);
}
