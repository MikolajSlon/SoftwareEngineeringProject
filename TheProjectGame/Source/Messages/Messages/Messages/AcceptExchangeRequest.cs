using Messages.CommunicationServer;
using Messages.PlayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Xsd2
{
    public partial class AcceptExchangeRequest : ICommunicationServerHandler, IPlayerHandler
    {
        public AcceptExchangeRequest(ulong target, ulong sender)
        {
            this.senderPlayerId = sender;
            this.playerId = target;
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
            Data msg = new Data();
            msg.gameFinished = connection.GameFinished;
            msg.GoalFields = connection.Logic.GetGoalFields.ToArray();
            msg.TaskFields = connection.Logic.GetTaskFields.ToArray();
            msg.Pieces = new Piece[1] { connection.Logic.GetPiece };
            var serializer = new Messages.XmlHandling.Serializer(msg);
            connection.SendMessage(serializer.Serialize());
        }
    }
}
