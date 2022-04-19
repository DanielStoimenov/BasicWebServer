using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Common
{
    public static class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value == null)
            {
                name ??= "Value";
                // name = name ?? "Value"; - name == name or name == "Value" if name is null

                throw new ArgumentNullException($"{name} can not be null");
            }
        }
    }
}