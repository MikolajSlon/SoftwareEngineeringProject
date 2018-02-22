using Messages.CommunicationServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsd2
{
    public partial class GameStarted : ICommunicationServerHandler
    {
        public GameStarted()
        {

        }
        public GameStarted(ulong id)
        {
            this.gameId = id;
        }
        public void HandleOnCommunicationServer(IConnection server, IReceiver receiver)
        {
        }
    }
}
