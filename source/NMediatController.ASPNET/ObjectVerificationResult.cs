namespace NMediatController
{
    using System.Collections.Generic;

    public class ObjectVerificationResult
    {
        private ObjectVerificationResult(bool failed, IEnumerable<string> errors)
        {
            Failed = failed;
            Errors = errors;
        }

        public bool Failed { get; }

        public IEnumerable<string> Errors { get; }

        public static ObjectVerificationResult Successful()
        {
            return new ObjectVerificationResult(false, null);
        }

        public static ObjectVerificationResult Failure(IEnumerable<string> errors)
        {
            return new ObjectVerificationResult(true, errors);
        }
    }
}
