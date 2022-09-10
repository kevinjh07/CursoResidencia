using System.Runtime.Serialization;

namespace CursoResidencia.Api.Exceptions;

[Serializable]
public class ForbidException : Exception
{
    public ForbidException()
    {
    }

    public ForbidException(string message) : base(message)
    {
    }

    public ForbidException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ForbidException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
