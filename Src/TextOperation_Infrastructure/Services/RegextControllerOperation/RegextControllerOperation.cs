namespace TextOperation_Infrastructure.Services.RegextControllerOperation;
public class RegextControllerOperation : IRegextControllerOperation
{
    private readonly IRegexService regexService;

    public RegextControllerOperation(IRegexService regexService)
    {
        this.regexService = regexService;
    }

    public Response<ShowResultOfCheckVideoMessageDto> CheckMatchTextWithOnePattern(string textForCompair)
    {
        var checkValidation = regexService.CheckInputTextValidation(textForCompair);
        if (checkValidation.StatusCode.Equals(HttpStatusCode.OK))
        {
            var patter = regexService.CreatePatternObjectOfRegex(@"The alarm id from video server number (\d+) is (\d+)");

            var matchWithPattern = regexService.CheckTextIsMatchWithInputText(textForCompair, patter);

            var resultOfCheckOperation = regexService.CheckTextResult(matchWithPattern, 1, 2);

            return resultOfCheckOperation;
        }
        return checkValidation;

    }
    public Response<ShowResultOfCheckVideoMessageDto> CheckMatchTextWithTwoPattern(string textForCompair)
    {
        var checkValidation = regexService.CheckInputTextValidation(textForCompair);
        if (checkValidation.StatusCode.Equals(HttpStatusCode.OK))
        {
            var pattern = regexService.CreatePatternObjectOfRegex(@"Alarm id (\d+) has been received from video server number (\d+)");

            var matchWithPattern = regexService.CheckTextIsMatchWithInputText(textForCompair, pattern);

            var resultOfCheckOperation = regexService.CheckTextResult(matchWithPattern, 2, 1);

            return resultOfCheckOperation;
        }
        return checkValidation;
    }
}
