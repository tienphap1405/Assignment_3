//Assignment 3: Singly Linked Lists, Serialization and Testing
//Group 12: Evan Nguyen, Aisha Naeem
//Due date: 29/03/2024

//Implementing the SLL class that inherited from the interface that required functionalities that needed
using Assignment_3.ProblemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3.Utility
{
    [DataContract]
    public class SLL : ILinkedListADT
    {
        //Declare properties of Count, Head, Tail
        [DataMember]
        public int count { get; private set; }
        [DataMember]
        public Node? Head { get; private set; }
        [DataMember]
        public Node? Tail { get; private set; }


        //Constructor of Linkedlist
        //Constructor of linked list, set Head, Tail, Count to empty
        public SLL()
        {
            Head = null;
            Tail = null;
            count = 0;
        }
        public bool IsEmpty()
        {
            if (Head == null || count == 0)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Tail.Next = newNode;
            }
            Tail = newNode;
            count++;
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
            count++;
        }

        public void Add(User value, int index)
        {
            Node newNode = new Node(value);
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Invalid index input");
            }
            else if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == count)
            {
                AddLast(value);
            }
            else
            {
                Node current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                count++;
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Invalid index input");
            }

            Node newNode = new Node(value);
            if (index == 0)
            {
                newNode.Next = Head.Next;
                Head = newNode;
            }
            else
            {
                Node current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next.Next;
                current.Next = newNode;
            }
        }

        public int Count()
        {
            Node current = Head;
            count = 0;
            if (current == null)
            {
                return 0;
            }
            while (current != null)
            {
                current = current.Next;
                count++;
            }
            return count;
        }

        public void RemoveFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
                if (Head == null)
                {
                    Tail = null;
                }
                count--;
            }
            else
            {
                throw new CannotRemoveException("The list is empty.");
            }
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new CannotRemoveException("The list is empty.");
                return;
            }
            if (Head.Next == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Node current = Head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
                Tail = current;
                count--;
            }

        }

        public void Remove(int index)
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException("The index input is out of range.");
            }
            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == count - 1)
            {
                RemoveLast();
            }
            else
            {
                Node current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                count--;
            }
        }

        public User? GetValue(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("The input is out of range.");
            }

            Node? current = Head;
            int indexCount = 0;
            while (current != null)
            {
                if (indexCount == index)
                {
                    return current.Data;
                }
                else
                {
                    current = current.Next;
                    indexCount++;
                }
            }
            return null;

        }

        public int IndexOf(User value)
        {
            Node current = Head;
            int indexCount = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return indexCount;
                }
                current = current.Next;
                indexCount++;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        //Implement the additional function
        //of copying the values of linked list nodes into an array
        public User[] CopyToArray()
        {
            Count();
            User[] array = new User[count];
            int index = 0;
            Node? current = Head;

            //Traverse the list to add the object to array
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
            return array;
        }



    }

    //Create an custom exception class that will thrown and handling when errors occured
    public class CannotRemoveException : Exception 
    {
        public CannotRemoveException(string message) : base(message)
        {
        } 
    }
}
