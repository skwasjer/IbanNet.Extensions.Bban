namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

internal class CheckDigitsAlgorithmStub(int checkDigitsToReturn) : CheckDigitsAlgorithm
{
    private readonly List<string> _received = [];
    private Exception? _exception;

    public IReadOnlyList<string> Received => _received;

    public void Throws(Exception exception)
    {
        _exception = exception;
    }

    protected override int Compute(Buffer buffer)
    {
        _received.Add(buffer.ToString());

        if (_exception is not null)
        {
            throw _exception;
        }

        return checkDigitsToReturn;
    }
}
