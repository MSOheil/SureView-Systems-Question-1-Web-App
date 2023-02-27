namespace TextOperation_Application.Common.Interfaces.RegextControllerOperation;

public interface IRegextControllerOperation
{
    /// <summary>
    /// Checks input text with pattern one is match and return response
    /// </summary>
    /// <param name="textForCompair">input text for check in pattern one</param>
    /// <returns></returns>
    Response<ShowResultOfCheckVideoMessageDto> CheckMatchTextWithOnePattern(string textForCompair);
    /// <summary>
    /// Checks input text with pattern two is match and return response
    /// </summary>
    /// <param name="textForCompair">input text for check with pattern two</param>
    /// <returns></returns>
    Response<ShowResultOfCheckVideoMessageDto> CheckMatchTextWithTwoPattern(string textForCompair);
}
