namespace Lab10_Marquez.Application.Ports;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    Task<int> CompleteAsync();
}