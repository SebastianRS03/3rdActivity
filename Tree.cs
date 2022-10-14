using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Trees
{
    internal class Tree
    {
        Node root;

        public void insert(Node node)
        {

            root = insertHelper(root, node);
        }

        private Node insertHelper(Node root, Node node)
        {
            int data = node.data;

            if (root == null)
            {
                root = node;
                return root;

            }
            else if (root.data < data)
            {

                root.left = insertHelper(root.left, node);

            }
            else
            {

                root.right = insertHelper(root.right, node);
            }

            return root;
        }

        public void traverse(string type)
        {

            traverseHelper(root, type);
        }

        private void traverseHelper(Node node, string type)
        {

            if (root != null)
            {
                switch (type)
                {
                    case "Pre-Order":
                        Console.WriteLine(root.data);
                        traverseHelper(root.left, type);
                        traverseHelper(root.right, type);
                        break;
                    case "In-Order":
                        traverseHelper(root.left, type);
                        Console.WriteLine(root.data);
                        traverseHelper(root.right, type);
                        break;
                    case "Post-Order":
                        traverseHelper(root.left, type);
                        traverseHelper(root.right, type);
                        Console.WriteLine(root.data);
                        break;
                    default:
                        Console.WriteLine("That's not a traverse order.");
                        break;
                }
                
            }
        }

        public void display()
        {
            displayHelper(root, 1);
        }

        private void displayHelper(Node node, int depth)
        {
            //string str = "";
            //str += node.left == null ? "." : node.left.data + "";
            //str += " <- " + node.data + " -> ";
            //str += node.right == null ? "." : node.right.data + ";

            //Console.WriteLine(str);
            //displayHelper(node.left);
            //displayHelper(node.right);

            //if (root != null)
            //{
            //    Console.WriteLine(node.left.getData() + " <- " + node.data + " -> " + node.right.getData());
            //    displayHelper(node.left);
            //    displayHelper(node.right);
            //}

            int h = height(node);
            int i;
            for (i = 1; i <= h; i++)
            {
                printGivenLevel(node, i);
                Console.WriteLine();
            }

            //if (root == null)
            //{
            //    return;
            //}
            //root.addChildren(root.left);
            //root.addChildren(root.right);
            //foreach (Node child in root.getChildren())
            //{
            //    Console.WriteLine(root.getData() + " || Child: " + child.getData());
            //}
            //displayHelper(root.left);
            //displayHelper(root.right);

            //root.addChildren(root.left);
            //root.addChildren(root.right);
            //if (node == null)
            //    return;

            //for (int i = 1; i <= depth - 1; i++)
            //{
            //    Console.WriteLine("│\t");
            //}

            //if (depth > 0)
            //    Console.WriteLine("├──");

            //Console.WriteLine(node.data);

            //foreach (Node child in root.getChildren())
            //{
            //    displayHelper(child, depth + 1);
            //}
        }

        public int height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                /* compute height of each subtree */
                int lheight = height(root.left);
                int rheight = height(root.right);

                /* use the larger one */
                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }
        }

        public void printGivenLevel(Node root, int level)
        {
            if (root == null)
                return;
            if (level == 1)
            {
                Console.Write(root.data + " ");
            }
            else if (level > 1)
            {
                printGivenLevel(root.right, level - 1);
                printGivenLevel(root.left, level - 1);
            }
        }

        public Boolean search(int data)
        {

            return searchHelper(root, data);
        }

        private Boolean searchHelper(Node root, int data)
        {
            if (root == null)
            {

                return false;
            }
            else if (root.data == data)
            {

                return true;
            }
            else if (root.data < data)
            {

                return searchHelper(root.left, data);
            }
            else
            {

                return searchHelper(root.right, data);
            }
        }

        public void remove(int data)
        {

            if (search(data))
            {

                removeHelper(root, data);
            }
            else
            {

                Console.WriteLine(data + " couldn't be found");
            }
        }
        private Node removeHelper(Node root, int data)
        {
            if (root == null)
            {

                return root;
            }
            else if (root.data < data)
            {

                root.left = removeHelper(root.left, data);
            }
            else if (root.data > data)
            {

                root.right = removeHelper(root.right, data);
            }
            else
            { 
                if (root.left == null && root.right == null)
                {

                    root = null;
                }
                else if (root.right != null)
                {
                    root.data = successor(root);
                    root.right = removeHelper(root.right, root.data);

                }
                else
                {

                    root.data = predecessor(root);
                    root.left = removeHelper(root.left, root.data);
                }
            }

            return root;
        }

        private int successor(Node root)
        {

            root = root.right;
            while (root.left != null)
            {

                root = root.left;
            }
            return root.data;
        }

        private int predecessor(Node root)
        { 

            root = root.left;
            while (root.right != null)
            {

                root = root.right;
            }
            return root.data;
        }

        public void level(int data)
        {
            Console.WriteLine("Node with data " + data + " is in level: " + levelHelper(root, data, 1));
        }

        private int levelHelper(Node root, int data, int level)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.data == data)
            {
                return level;
            }
            int result = levelHelper(root.left, data, level+1);
            if (result != 0)
            {
                return result;
            }
            result = levelHelper(root.right, data, level +1);
            return result;
        }
    }
}
