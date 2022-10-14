using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Trees
{
    internal class Node
    {
        public int data;
        public Node left;
        public Node right;
        public List<Node> children;

        public Node(int data)
        {
            this.data = data;
            this.children = new List<Node>();
        }

        public int getData() 
        { 
            return this.data; 
        }

        public List<Node> getChildren()
        {
            return this.children;
        }

        public void addChildren(Node node)
        {
            this.children.Add(node);
        }


    }
}
