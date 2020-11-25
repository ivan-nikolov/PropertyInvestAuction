namespace PropertyInvestAuction.Services.Models
{
    public class Result
    {
        public bool Succeeded { get; private set; }

        public bool Failure => !this.Succeeded;

        public string[] Errors { get; private set; }

        public static implicit operator Result(bool succeeded)
            => new Result { Succeeded = succeeded };

        public static implicit operator Result(string[] errors)
            => new Result
            {
                Succeeded = false,
                Errors = errors
            };

        public static implicit operator string[](Result instance)
            => instance.Errors;
    }
}
