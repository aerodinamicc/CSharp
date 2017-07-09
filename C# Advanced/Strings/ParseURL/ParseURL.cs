using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseURL
{
    class ParseURL
    {
        static void Main()
        {
            string line = Console.ReadLine();
            int protocolInd = line.IndexOf("://");
            string protocol = line.Substring(0, protocolInd);
            int serverInd = line.IndexOf("/", protocolInd + 3);
            string server = line.Substring(protocolInd + 3, serverInd - (protocolInd + 3));
            string resource = line.Substring(serverInd);

            string tidied = String.Format("[protocol] = {0}\n[server] = {1}\n[resource] = {2}", protocol, server, resource);
            Console.WriteLine(tidied);
        }
    }
}
