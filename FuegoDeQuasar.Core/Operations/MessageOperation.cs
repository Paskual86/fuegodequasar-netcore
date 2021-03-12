using FuegoDeQuasar.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FuegoDeQuasar.Core.Operations
{
    public class MessageOperation : IMessageOperation
    {
        public string GetMessage(string[] messages)
        {
            string result = string.Empty;
            for (int i = 0; i < messages.Length; i++)
            {
                result += messages[i] + " ";
            }
            return result;

        }

        public string GetMessage(IEnumerable<string[]> messages)
        {
            if ((messages == null)) return string.Empty;

            // Primero obtengo el promedio de mensajes que hay en la lista
            var maxLength = (int)messages.Max(a => a.Length);
            var msgResult = new string[maxLength];

            foreach (var item in messages)
            {
                for(int i=0;i<item.Length;i++)
                {
                    if (item.Length == maxLength)
                    {
                        if (string.IsNullOrEmpty(msgResult[i]))
                        {
                            msgResult[i] = item[i];
                        }                        
                    }
                }
            }

            return GetMessage(msgResult);
        }
    }
}
