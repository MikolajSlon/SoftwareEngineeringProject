﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMaster
{
    interface ICommunication
    {
        void clientOnDisconnect();
        void clientOnDataReceived();
        void clientOnConncet();
    }
}
