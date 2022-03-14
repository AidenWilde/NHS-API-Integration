using Assignment2022_NCC.Api.Types;

public interface IBasicCache
{
    void Update(CommonHealthQuestionsApiResonse response);
    bool HasValue();
    CommonHealthQuestionsApiResonse? Read();
}

public class BasicCache : IBasicCache
{
    private CommonHealthQuestionsApiResonse? _commonHealthQuestionsApiResonse;

    public void Update(CommonHealthQuestionsApiResonse response)
    {
        _commonHealthQuestionsApiResonse = response;
    }

    public bool HasValue()
    {
        return _commonHealthQuestionsApiResonse != null;
    }

    public CommonHealthQuestionsApiResonse? Read()
    {
        return _commonHealthQuestionsApiResonse;
    }
}