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
                if ( !string.IsNullOrEmpty(messages[i])) result += messages[i] + " ";
            }
            result = result.Substring(0, result.Length - 1);
            //
            var resultLength = result.Split(" ");
            int percentage = ((resultLength.Length * 100) / messages.Length);
            // Si la cantidad de letras obtenidas, y vinieron muchos espacios en el mensaje original, doy ell mensaje como invalido.
            if (percentage <= 50) result = string.Empty;
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
