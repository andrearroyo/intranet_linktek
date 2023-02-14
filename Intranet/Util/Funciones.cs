using System.Net;
using System.Net.NetworkInformation;

namespace Intranet.Util
{
    public class Funciones
    {
        public bool PingTestInternet()
        {
            try
            {
                Ping ping = new Ping();

                PingReply pingStatus = ping.Send(IPAddress.Parse("8.8.8.8"));

                if (pingStatus.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
