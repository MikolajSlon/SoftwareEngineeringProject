using Messages.CommunicationServer;
using Messages.PlayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsd2
{
    public partial class RejectKnowledgeExchange : ICommunicationServerHandler, IPlayerHandler
    {
        public RejectKnowledgeExchange(ulong target, ulong sender, bool permanent)
        {
            this.playerId = target;
            this.senderPlayerId = sender;
            this.permanent = permanent;
        }
        public void HandleOnCommunicationServer(Messages.CommunicationServer.IConnection server, IReceiver receiver)
        {
            var serializer = new Messages.XmlHandling.Serializer(this);
            var gameId = receiver.GameId;
            var game = server.Games[gameId];
            game.GameMaster.SendMessage(serializer.Serialize());
        }

        public void HandleOnPlayer(Messages.PlayerInterfaces.IConnection connection)
        {
        }
    }
}
