namespace Business.Wrappers
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
