namespace TextOperation_Infrastructure.Services.Regex;
public class RegexService : IRegexService
{


    public Match CheckTextIsMatchWithInputText(string inputText, System.Text.RegularExpressions.Regex pattern)
    => pattern.Match(inputText);

    public System.Text.RegularExpressions.Regex CreatePatternObjectOfRegex(string pattern)
    => new System.Text.RegularExpressions.Regex(pattern);

    public Response<ShowResultOfCheckVideoMessageDto> CheckTextResult(System.Text.RegularExpressions.Match matchOperation
        , int serverNumberIndex, int alarmNumberIndex)
    {
        if (matchOperation.Success)
        {
            return new Response<ShowResultOfCheckVideoMessageDto>("Every thing extraced")
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Result = new ShowResultOfCheckVideoMessageDto
                {
                    ServerNumber = matchOperation.Groups[serverNumberIndex].Value,
                    AlarmNumber = matchOperation.Groups[alarmNumberIndex].Value,
                }
            };
        }

        return new Response<ShowResultOfCheckVideoMessageDto>("Message pattern wasn't correct")
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Result = new ShowResultOfCheckVideoMessageDto
            {
                ServerNumber = matchOperation.Groups[1].Value,
                AlarmNumber = matchOperation.Groups[2].Value,
            }
        };
    }

    public Response<ShowResultOfCheckVideoMessageDto> CheckInputTextValidation(string inputText)
    {
        if (String.IsNullOrWhiteSpace(inputText))
        {
            return new Response<ShowResultOfCheckVideoMessageDto>("Message must not be null")
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Result = new ShowResultOfCheckVideoMessageDto
                {
                    ServerNumber = String.Empty,
                    AlarmNumber = String.Empty,
                }
            };
        }
        return new Response<ShowResultOfCheckVideoMessageDto>("Every thing is good")
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Result = new ShowResultOfCheckVideoMessageDto
            {
                ServerNumber = String.Empty,
                AlarmNumber = String.Empty,
            }
        };
    }
}
