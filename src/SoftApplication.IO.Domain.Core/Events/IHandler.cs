namespace SoftApplication.IO.Domain.Core.Events
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T pMessage);
    }
}
