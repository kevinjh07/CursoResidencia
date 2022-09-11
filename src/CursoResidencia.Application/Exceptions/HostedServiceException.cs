using System.Runtime.Serialization;

namespace CursoResidencia.Application.Exceptions;

[Serializable]
public class HostedServiceException : Exception
{
    public HostedServiceException()
    {
    }

    protected HostedServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public HostedServiceException(string message) : base(message)
    {
    }

    public HostedServiceException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
