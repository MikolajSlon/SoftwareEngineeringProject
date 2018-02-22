using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages.GameMaster;

namespace Xsd2
{

    public partial class GameMessage : Messages.GameMaster.IGameMasterHandler
    {
        public void HandleOnGameMaster(IConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
