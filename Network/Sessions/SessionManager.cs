using log4net;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace IDK.Game.Sessions
{
    /// <summary>
    /// SessionManager Klasse
    /// Die Aufgabe der Klasse besteht darin, die jeweiligen Socket Sitzungen
    /// des Clients zuzordnen
    /// </summary>
    public class SessionManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SessionManager));

        private List<Session> _clients;

        public SessionManager() {
            _clients = new List<Session>();

            log.Info("SessionManager wurde geladen!");
        }

        /// <summary>
        /// Die jeweilige Session wird in einer Liste abgespeichert
        /// </summary>
        /// <param name="client">Socket Sitzung</param>
        public bool Add(Session client)
        {
            try
            {
                _clients.Add(client);
                return true;
            }
            catch(Exception e)
            {
                log.Error(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Die Session wird aus der Liste entfernt
        /// </summary>
        /// <param name="client">Session Objekt</param>
        public bool Remove(Session client)
        {
            try
            {
                _clients.Remove(client);
                return true;
            }
            catch(Exception e)
            {
                log.Error(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Die Session wird gesucht und die jeweilige
        /// Session Instanz wird zurückgegeben
        /// </summary>
        /// <param name="client">Session Objekt</param>
        /// <returns>Session</returns>
        public Session Get(Session client)
        {
            return _clients.Find(x => x == client);
        }
    }
}
