using System;
using System.Diagnostics;
using System.IO;

namespace Part1C.Services
{
    class SystemFileService : SingletonBase<SystemFileService>
    {
        #region Methods

        public bool TrySave(string filepath, string buffer)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(File.Open(filepath, FileMode.OpenOrCreate)))
                {
                    Debug.WriteLine("Save request complete.");
                    writer.Write(buffer);
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Save request failed. Reason: " + exception.Message);
                return false;
            }
        }

        public bool TryLoad(string filepath, out string buffer)
        {
            try
            {
                using (StreamReader reader = new StreamReader(File.Open(filepath, FileMode.Open)))
                {
                    Debug.WriteLine("Load request complete.");
                    buffer = reader.ReadToEnd();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Load request failed. Reason: " + exception.Message);
                buffer = null;
                return false;
            }
        }

        #endregion Methods
    }
}