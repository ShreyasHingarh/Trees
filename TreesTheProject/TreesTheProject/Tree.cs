using System;
using System.Collections.Generic;
using System.Text;

namespace TreesTheProject
{
    class Node<T>
    {
        public Node<T> Parent;
        public Node<T> LeftChild;
        public Node<T> RightChild;
        public bool hasTwoChildren
        {
            get
            {
                return LeftChild != null && RightChild != null;
            }
        }
        public T Value;
        public Node(T value)
        {
            Value = value;
        }
    }

    class Tree<T> where T : IComparable<T>
    {
        public Node<T> Root;
        
        public int size;
        public T Minimum 
        {
            get
            {
                Node<T> temp = Root;
                do
                {
                    temp = temp.LeftChild;
                } while (!temp.LeftChild.Equals(null));
                return temp.Value;
            }
        }
        public void Insert(T value)
        {

            if(Root == null)
            {
                Root = new Node<T>(value);
                size++;
                return;
            }
            Node<T> temp = Root;
            int count = 0;
            do
            {


                if (temp.hasTwoChildren)
                {
                    if (value.CompareTo(temp.Value) > 0)
                    {
                        temp = temp.RightChild;
                    }
                    else if (value.CompareTo(temp.Value) <= 0)
                    {
                        temp = temp.LeftChild;
                    }
                }
                else
                {
                    if (value.CompareTo(temp.Value) > 0)
                    {
                        temp.RightChild = new Node<T>(value);
                        size++;
                        return;
                    }
                    else if (value.CompareTo(temp.Value) <= 0)
                    {
                        temp.LeftChild = new Node<T>(value);
                        size++;
                        return;
                    }
                }
                count++;
            } while (count < size);
        }
    }
}
