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

    class Tree<T>
    {
        public Node<T> Root;
        public void Insert(T value)
        {

            if(Root == null)
            {
                Root = new Node<T>(value);
                
                return;
            }
        }
    }
}
