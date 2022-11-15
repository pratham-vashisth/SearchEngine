using System.Runtime.Serialization;

namespace SearchEngine.Core.Drives
{
    [Serializable]
    public class InvalidDriveChoiceException : Exception
    {
        public InvalidDriveChoiceException()
        {
        }

        public InvalidDriveChoiceException(string? message) : base(message)
        {
        }

        public InvalidDriveChoiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidDriveChoiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}