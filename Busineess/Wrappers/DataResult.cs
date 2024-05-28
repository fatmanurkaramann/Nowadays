using Core.Wrappers;
using Entities.Constants;
using Entities.Enums;

namespace Business.Wrappers
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }

        public static IDataResult<T> CreateResult(OperationResult<T> operationResult, string message = "")
        {
            return CreateResult(operationResult.Entity, operationResult.IsSuccess, message);
        }

        public static IDataResult<T> CreateResult(OperationResult<T> operationResult,EntityType entityType, ActionType actionType,Language language = Language.Turkish)
        {
            return CreateResult(operationResult, Messages.CreateMessage(entityType,actionType, operationResult.IsSuccess,language));
        }

        public static IDataResult<T> CreateResult(T data, bool success, string message = "")
        {
            if (string.IsNullOrEmpty(message))
                return new DataResult<T>(data, success);

            return success ? new SuccessDataResult<T>(data, message) : new ErrorDataResult<T>(message);
        }
    }
}
