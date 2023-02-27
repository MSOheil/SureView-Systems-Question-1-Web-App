namespace TextOperation_Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RegexOperationController : ControllerBase
{
    private readonly IRegextControllerOperation regextControllerOperation;
    public RegexOperationController(IRegextControllerOperation regextControllerOperation)
    {
        this.regextControllerOperation = regextControllerOperation;
    }


    [HttpGet("CheckTextWithPatternOne")]
    public ActionResult<ShowResultOfCheckVideoMessageDto> CheckPatternOne([FromQuery] string message)
    {
        return Ok(regextControllerOperation.CheckMatchTextWithOnePattern(message));
    }
    [HttpGet("CheckTextWithPatternTwo")]
    public ActionResult<ShowResultOfCheckVideoMessageDto> CheckPatternTwo([FromQuery] string message)
    {
        return Ok(regextControllerOperation.CheckMatchTextWithTwoPattern(message));
    }
}
