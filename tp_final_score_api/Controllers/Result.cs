namespace tp_final_score_api.Controllers
{
    public class Result<T>
    {

        public T _result { get; set; }
        public string Error { get; set; }
        public int Code { get; set; }

        protected internal Result(T result)
        {
            _result = result;
            Code = 200;
            Error = null;
        }

        public  Result(string error, int code)
        {
            _result = default(T);
            Code = code;
            Error = error;
        }

    }

    public class Result : Result<string>
    {
        public Result(string result, int v) : base(result)
        {
        }

        public Result(string result) : base(result)
        {
        }

        public static Result<T> Ok<T>(T result)
        {
            return new Result<T>(result);
        }

        internal static Result Ok()
        {
            return new Result(null);
        }

        public static Result<T> BadRequest<T>()
        {
            return new Result<T>("Bad Request", 400);
        }

        public static Result<T> NotFound<T>()
        {
            return new Result<T>("Not Found", 404);

        }
        public static Result<T> Unauthorized<T>()
        {
            return new Result<T>("Unauthorized access", 401);
        }

        public static Result Unauthorized()
        {
            return new Result("Unauthorized access", 401);
        }


        public static Result Error(string errorMessage)
        {
            return new Result(errorMessage);

        }
    }
}