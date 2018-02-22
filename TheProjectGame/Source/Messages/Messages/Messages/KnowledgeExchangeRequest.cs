using Messages.CommunicationServer;
using Messages.PlayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsd2
{
    public partial class KnowledgeExchangeRequest : ICommunicationServerHandler, IPlayerHandler
    {
        public KnowledgeExchangeRequest(ulong target, ulong sender)
        {
            this.playerId = target;
            this.senderPlayerId = sender;
        }

        public void HandleOnCommunicationServer(Messages.CommunicationServer.IConnection server, IReceiver receiver)
        {
            IReceiver rec = server.Receivers.Find(p => p.Id == this.playerId);
            var serializer = new Messages.XmlHandling.Serializer(this);
            rec.SendMessage(serializer.Serialize());
        }

        public void HandleOnPlayer(Messages.PlayerInterfaces.IConnection connection)
        {

            if(connection.Logic.TeamMembers.FirstOrDefault(x => x.id == this.senderPlayerId) != null)
            {
                Data msg = new Data();
                msg.gameFinished = connection.GameFinished;
                msg.GoalFields = connection.Logic.GetGoalFields.ToArray();
                msg.TaskFields = connection.Logic.GetTaskFields.ToArray();
                msg.Pieces = new Piece[1] { connection.Logic.GetPiece };
                var serializer = new Messages.XmlHandling.Serializer(msg);
                connection.SendMessage(serializer.Serialize());
                AuthorizeKnowledgeExchange message = new AuthorizeKnowledgeExchange(connection.Guid.ToString(), connection.GameId, this.senderPlayerId);
                var serializer2 = new Messages.XmlHandling.Serializer(message);
                connection.SendMessage(serializer2.Serialize());


            }

        }
    }
}
