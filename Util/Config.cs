using log4net;
using System;
using System.Collections.Generic;
using System.IO;

namespace IDK.Util
{
    /// <summary>
    /// Configuration Klasse
    /// Ermöglicht es die Daten der "config.ini" zu lesen
    /// </summary>
    public class Config
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Config));

        private Dictionary<string, string> _data = new Dictionary<string, string>();

        /// <summary>
        /// Überprüft ob die "config.inI" existiert und
        /// speichert alle vorhanden Daten in einer Dictionary
        /// </summary>
        /// <param name="file">Pfad zur aktuellen Datei</param>
        /// <exception cref="ArgumentException">
        /// Die Datei wurde nicht gefunden oder
        /// die Werte konnten nicht gelesen werden
        /// </exception>
        public Config(string file)
        {
            if (!File.Exists(file))
            {
                throw new ArgumentException($"Configuration file not found in '{file}'.");
            }

            try
            {
                using (var reader = new StreamReader(file))
                {
                    string line = "";

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Length < 1 || line.StartsWith("#")) continue;

                        int delimiterIndex = line.IndexOf('=');
                        if (delimiterIndex == -1) continue;

                        string key = line.Substring(0, delimiterIndex);
                        string value = line.Substring(delimiterIndex + 1);

                        _data.Add(key, value);
                    }

                    reader.Close();
                }

                log.Info("Config wurde geladen!");
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Could not process configuration file: {e.ToString()}.");
            }
        }

        /// <summary>
        /// Daten werden aus der "config.ini" gelesen
        /// und der jeweilige Wert wird zurückgegeben.
        /// Falls sie nicht existiert, dann wird ein leerer String
        /// zurückgegeben
        /// </summary>
        /// <param name="key">Konfig Parameter</param>
        /// <returns>string</returns>
        public string GetValue(string key)
        {
            return _data.ContainsKey(key) ? _data[key] : string.Empty;
        }
    }
}
