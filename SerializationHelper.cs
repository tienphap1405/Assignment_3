using Assignment_3.ProblemDomain;
using Assignment_3.Utility;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(SLL users, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static SLL DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL));
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (SLL)serializer.ReadObject(stream);
            }
        }
    }
}
