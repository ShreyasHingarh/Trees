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
                if (size <= 0) return default(T);
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
                if (size <= 0) return default(T);
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
                if (value.CompareTo(temp.Value) >= 0)
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
                else if (value.CompareTo(temp.Value) < 0)
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

            Node<T> OneToDelete = Search(value);
            if (OneToDelete == null || size == 0)
            {
                return;
            }
                // two
                // find largest value in left subtree
                // make that node the root
                // Remove that node;
           
            else if (OneToDelete.RightChild == null && OneToDelete.LeftChild == null)
            {
                if(OneToDelete.Value.Equals(Root.Value))
                {
                    Root = null;
                    size = 0;
                    return;
                }
                else if (OneToDelete.isLeftChild)
                {
                    OneToDelete.Parent.LeftChild = null;
                }
                else if (OneToDelete.isRightChild)
                {
                    OneToDelete.Parent.RightChild = null;
                }
            }
            else if (OneToDelete.RightChild != null && OneToDelete.LeftChild == null)
            {
                if (OneToDelete.Value.Equals(Root.Value))
                {
                    Node<T> temp = Root;
                    Root = null;
                    Root = temp.RightChild;
                    temp.RightChild.Parent = null;

                }
                
                else if (OneToDelete.isLeftChild)
                {
                    OneToDelete.RightChild.Parent = OneToDelete.Parent;
                    OneToDelete.Parent.LeftChild = OneToDelete.RightChild;
                }
                else if(OneToDelete.isRightChild)
                {
                    OneToDelete.RightChild.Parent = OneToDelete.Parent;
                    OneToDelete.Parent.RightChild = OneToDelete.RightChild;
                }
            }
            else if(OneToDelete.RightChild == null && OneToDelete.LeftChild != null)
            {
                if (OneToDelete.Value.Equals(Root.Value))
                {
                    Node<T> temp = Root;
                    Root = null;
                    Root = temp.LeftChild;
                    temp.LeftChild.Parent = null;
                }
                else if(OneToDelete.isLeftChild)
                {
                    OneToDelete.LeftChild.Parent = OneToDelete.Parent;
                    OneToDelete.Parent.LeftChild = OneToDelete.LeftChild;
                }
                else if(OneToDelete.isRightChild)
                {
                    OneToDelete.LeftChild.Parent = OneToDelete.Parent;
                    OneToDelete.Parent.RightChild = OneToDelete.LeftChild;
                }
            }
            else if(OneToDelete.hasTwoChildren)
            {
                Node<T> temp = OneToDelete.LeftChild;
                while (temp.RightChild != null)
                {
                    temp = temp.RightChild;
                }
                T num = temp.Value;
                Delete(temp.Value);
                if (OneToDelete.Value.Equals(Root.Value))
                {
                    Root.Value = num;
                }
                else
                {
                    OneToDelete.Value = num;
                }
               
                size++;
            }
            size--;
        }

        public List<T> PreOrderTraversal()
        {
            List<T> NodesProcessed = new List<T>();
            
            Stack<Node<T>> NodesToBeProcessed = new Stack<Node<T>>();
            NodesToBeProcessed.Push(Root);
            while(NodesToBeProcessed.Count != 0)
            {
                Node<T> temp = NodesToBeProcessed.Pop();
                NodesProcessed.Add(temp.Value);
                if (temp.RightChild != null)
                {
                    NodesToBeProcessed.Push(temp.RightChild);
                }
                if (temp.LeftChild != null)
                {
                    NodesToBeProcessed.Push(temp.LeftChild);
                }
               
             
            }
            return NodesProcessed;
        }
        public List<T> InOrderTraversal()
        {
            List<T> FinishedNodes = new List<T>();
            Stack<Node<T>> UnfinishedNodes = new Stack<Node<T>>();
            UnfinishedNodes.Push(Root);
            Node<T> temp = Root.LeftChild;

                while (UnfinishedNodes.Count != 0)
                {
                    while (temp.LeftChild != null)
                    {
                        UnfinishedNodes.Push(temp);
                        temp = temp.LeftChild;
                    }
                    FinishedNodes.Add(temp.Value);
                    temp = UnfinishedNodes.Pop();
                    FinishedNodes.Add(temp.Value);
                    temp = temp.RightChild;
                }

               
            
            return FinishedNodes;
        }
    }
}
