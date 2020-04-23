namespace SI.Common.Models {

    public class Result {

        public Result (bool isSuccess, string message) {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static Result CreateSuccessReqest (string message = "success") {
            return new Result (true, message);
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class Result<T> : Result {
        public T Data { get; set; }

        public Result (bool isSuccess, string message, T data) : base(isSuccess, message) {
          Data = data;
        }

        public static Result CreateSuccessReqest (T data, string message = "success") {
            return new Result<T> (true, message, data);
        }
    }
}