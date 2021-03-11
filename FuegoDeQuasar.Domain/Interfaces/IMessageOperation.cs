using System.Collections.Generic;

namespace FuegoDeQuasar.Domain.Interfaces
{
    public interface IMessageOperation
    {
        string GetMessage(string[] messages);
        string GetMessage(IEnumerable<string[]> messages); 
    }
}
