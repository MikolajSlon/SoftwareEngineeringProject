using Messages.CommunicationServer;
using Messages.GameMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsd2
{
    public partial class AuthorizeKnowledgeExchange : ICommunicationServerHandler, IGameMasterHandler
    {

        public AuthorizeKnowledgeExchange(string guid, ulong gameId, ulong target)
        {
            this.playerGuid = guid;
            this.gameId = gameId;
            this.withPlayerId = target;
        }

        public void HandleOnCommunicationServer(Messages.CommunicationServer.IConnection server, IReceiver receiver)
        {
            var serializer = new Messages.XmlHandling.Serializer(this);
            var gameId = receiver.GameId;
            var game = server.Games[gameId];
            this.gameId = gameId;
            game.GameMaster.SendMessage(serializer.Serialize());
        }
        public void HandleOnGameMaster(Messages.GameMaster.IConnection connection)
        {
            var sender = connection.GameState.GetPlayerByGuid(this.playerGuid);

            if (connection.GameState.GetPlayerById(this.withPlayerId) == null)
            {
                RejectKnowledgeExchange msg = new RejectKnowledgeExchange(this.withPlayerId, sender.Id, true);
                var serializer = new Messages.XmlHandling.Serializer(msg);
                connection.SendMessage(serializer.Serialize());
            }
            else
            {
                
                Tuple<ulong, ulong> pair = new Tuple<ulong, ulong>(sender.Id, this.withPlayerIdField);

                if (connection.GameState.PlayerPairs.FirstOrDefault(x => x.Item1 == sender.Id && x.Item2 == this.withPlayerId) == null)
                {
                    //no pair yet
                    KnowledgeExchangeRequest msg = new KnowledgeExchangeRequest(this.withPlayerId, sender.Id);
                    var serializer = new Messages.XmlHandling.Serializer(msg);
                    connection.GameState.PlayerPairs.Add(pair);
                    connection.DelayMessage(serializer, connection.GameState.ActionCosts.KnowledgeExchangeDelay);
                }
                else
                {
                    // pair exists
                    connection.GameState.PlayerPairs.RemoveAll(x => x.Item1 == sender.Id && x.Item2 == this.withPlayerId);
                    AcceptExchangeRequest msg = new AcceptExchangeRequest(this.withPlayerId, sender.Id);
                    var serializer = new Messages.XmlHandling.Serializer(msg);
                    connection.SendMessage(serializer.Serialize());
                }
            }
        }
    }
}
