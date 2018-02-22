using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMaster
{
    class Logger :IDisposable
    {
        private readonly string _fileName;

        System.IO.StreamWriter file;
        public Logger()
        {
            _fileName = "GMLogger.csv";
            file = new System.IO.StreamWriter(_fileName, false);
            string line = "Request type,Timestamp,Game id,Player id,Player GUID,Colour,Role";
            file.WriteLine(line);
        }
        public void WriteLog(string requestType, string gameId, string playerId, string playerGuid, string colour, string role)
        {
            Console.WriteLine("debugging2");

            DateTime date = DateTime.Now;
            string line = string.Format("{0},{1},{2},{3},{4},{5},{6}", requestType, date.ToUniversalTime().ToString("s"), gameId, playerId, playerGuid, colour, role);
            file.WriteLine(line);
        }

        public void Dispose()
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }
}
