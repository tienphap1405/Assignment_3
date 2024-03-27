//Create Node class that contains the nodes with data and address of the linked list
using Assignment_3.ProblemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3.Utility
{
    //Using the [DataContract] and [DataMember]
    //To provides the implementation of serialization and desirialization process with data that needed to be serialized
    [DataContract]
    public class Node
    {

        [DataMember]
        public User Data { get; set; }
        [DataMember]
        public Node? Next { get; set; }
     
        public Node(User Data)
        {
            this.Data = Data;
        }
    }
}
