namespace TextOperation_Infrastructure_Tests.Services_Tests.Regex_Tests;
[TestFixture]
public class RegexService_Tests
{
    private IRegexService regexOperation;
    private IRegextControllerOperation regextController;
    [SetUp]
    public void InitialTestClass()
    {
        regexOperation = new RegexService();
        regextController = new RegextControllerOperation(regexOperation);
    }
    [Test]
    public void CheckInputTextValidation_InsertNullText_ReturnBadRequestStatuCode()
    {
        //Arrage

        var inputText = String.Empty;
        //Act
        var resultOfCheckValidationInputText = regexOperation.CheckInputTextValidation(inputText);

        //Assert

        Assert.AreEqual(HttpStatusCode.BadRequest, resultOfCheckValidationInputText.StatusCode);
    }
    [Test]
    public void CheckMatchTextWithOnePattern_SendTextLikeOnePatternButWrong_ReturnsBadRequestStatusCode()
    {
        //Arrage

        var inputText =
            "The alarm id from video server number 4 as 4";
        //Act
        var resultOfCheckInputText = regextController.CheckMatchTextWithOnePattern(inputText);

        //Assert

        Assert.AreEqual(HttpStatusCode.BadRequest, resultOfCheckInputText.StatusCode);

    }
    [Test]
    public void CheckMatchTextWithOnePattern_SendCorrectTextLikeOnePattern_ReturnsOkStatusCodeAndCorrectServerNumberAndAlarmId()
    {
        //Arrage

        var inputText =
            "The alarm id from video server number 12 is 3";
        //Act
        var resultOfCheckInputText = regextController.CheckMatchTextWithOnePattern(inputText);

        //Assert

        Assert.AreEqual(HttpStatusCode.OK, resultOfCheckInputText.StatusCode);
        Assert.AreEqual("12", resultOfCheckInputText.Result.ServerNumber);
        Assert.AreEqual("3", resultOfCheckInputText.Result.AlarmNumber);

    }
    [Test]
    public void CheckMatchTextWithTwoPattern_SendWrongTextLikeOnePattern_ReturnsBadRequestStatusCode()
    {
        //Arrage

        var inputText =
            "Alarm id 16 has been received from video server numbeer 12";
        //Act
        var resultOfCheckInputText = regextController.CheckMatchTextWithTwoPattern(inputText);

        //Assert

        Assert.AreEqual(HttpStatusCode.BadRequest, resultOfCheckInputText.StatusCode);

    }
    [Test]
    public void CheckMatchTextWithTwoPattern_SendWrongTextLikeOnePattern_ReturnsOkStatusCodeAndCorrectServerNumberAndAlarmId()
    {
        //Arrage

        var inputText =
            "Alarm id 126 has been received from video server number 167";
        //Act
        var resultOfCheckInputText = regextController.CheckMatchTextWithTwoPattern(inputText);

        //Assert

        Assert.AreEqual(HttpStatusCode.BadRequest, resultOfCheckInputText.StatusCode);
        Assert.AreEqual("167", resultOfCheckInputText.Result.ServerNumber);
        Assert.AreEqual("126", resultOfCheckInputText.Result.AlarmNumber);
    }
}
