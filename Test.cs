using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    internal class Test
    {
        static void Main(String[] args)
        {
            Tree tree = new Tree();
            tree.insert(new Node(5));
            tree.insert(new Node(1));
            tree.insert(new Node(9));
            tree.insert(new Node(2));
            tree.insert(new Node(7));
            tree.insert(new Node(3));
            tree.insert(new Node(6));
            tree.insert(new Node(4));
            tree.insert(new Node(8));
            tree.insert(new Node(10));

            tree.display();
        }
    }
}
