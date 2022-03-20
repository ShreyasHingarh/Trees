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
        public bool isRightChild
        {
            get
            {
                return Parent.RightChild == this;
            }
        }
        public bool isLeftChild
        {
            get
            {
                return Parent.LeftChild == this;
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
                
                    
                while (temp.LeftChild != null)
                {
                    temp = temp.LeftChild;
                }
                return temp.Value;
            }
        }
        public T Maximum
        {
            get
            {
                Node<T> temp = Root;
                while(temp.RightChild != null)
                {
                    temp = temp.RightChild;
                }
                return temp.Value;
            }
        }
        public void Insert(T value)
        {

            if (Root == null)
            {
                Root = new Node<T>(value);
                size++;
                return;
            }
            Node<T> temp = Root;
            
            while(true)
            { 
                if (value.CompareTo(temp.Value) > 0)
                {
                    if(temp.RightChild != null)
                    {
                        temp = temp.RightChild;
                    }
                    else
                    {
                        temp.RightChild = new Node<T>(value);
                        temp.RightChild.Parent = temp;
                        size++;
                        return;
                    }
                }
                else if (value.CompareTo(temp.Value) <= 0)
                {
                    if(temp.LeftChild != null)
                    {
                        temp = temp.LeftChild;
                    }
                    else
                    {
                        temp.LeftChild = new Node<T>(value);
                        temp.LeftChild.Parent = temp;
                        size++;
                        return;
                    }
                }
            }
        }
     
        public bool Contains(T value)
        {
            return Search (value) != null;
        }
        public Node<T> Search(T value)
        {
            if (size == 0)
            {
                return null;
            }
            Node<T> temp = Root;
            int count = 0; 
            while (temp != null && !temp.Value.Equals(value))
            {
                if(value.CompareTo(temp.Value) <= 0)
                {
                    temp = temp.LeftChild;
                }
                else if(value.CompareTo(temp.Value) > 0)
                {
                    temp = temp.RightChild;
                }
                count++;
                if (count == size)
                {
                    return null;
                }
            }
            return temp;
        }
        public void Delete(T value)
        {

        }
    }
}
