namespace Core.Wrappers
{
    public class OperationResult<T>
    {
        public OperationResult(T entity, bool isSuccess)
        {
            Entity = entity;
            IsSuccess = isSuccess;
        }

        public OperationResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
            Entity = default!;
        }

        public bool IsSuccess { get; set; }
        public T Entity { get; set; }
    }
}
