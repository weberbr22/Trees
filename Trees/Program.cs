using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    
    class Node
    {
        public int value;
        public Node left, right;

        public Node(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }

    class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            this.root = null;
        }

        public void AddNode(int value)
        {
            Node newNode = new Node(value);

            if (this.root == null)
            {
                this.root = newNode;
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                if (node.left == null)
                {
                    node.left = newNode;
                    return;
                }
                else
                {
                    queue.Enqueue(node.left);
                }

                if (node.right == null)
                {
                    node.right = newNode;
                    return;
                }
                else
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        public void BreadthFirstSearch()
        {
            if (this.root == null)
            {
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                Console.Write(node.value + " ");

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            Console.WriteLine();
        }
    }

    internal class Program
    {

        static void createTree()
        {
            int[,] ArrayNodes = new int[20, 3];

            // Storing the given data in ArrayNodes
            ArrayNodes[0, 0] = 1;    // left pointer
            ArrayNodes[0, 1] = 20;   // data
            ArrayNodes[0, 2] = 5;    // right pointer

            ArrayNodes[1, 0] = 2;    // left pointer
            ArrayNodes[1, 1] = 15;   // data
            ArrayNodes[1, 2] = -1;   // right pointer

            ArrayNodes[2, 0] = -1;   // left pointer
            ArrayNodes[2, 1] = 3;    // data
            ArrayNodes[2, 2] = 3;    // right pointer

            ArrayNodes[3, 0] = -1;   // left pointer
            ArrayNodes[3, 1] = 9;    // data
            ArrayNodes[3, 2] = 4;    // right pointer

            ArrayNodes[4, 0] = -1;   // left pointer
            ArrayNodes[4, 1] = 10;   // data
            ArrayNodes[4, 2] = -1;   // right pointer

            ArrayNodes[5, 0] = -1;   // left pointer
            ArrayNodes[5, 1] = 58;   // data
            ArrayNodes[5, 2] = -1;   // right pointer

            for (int i = 6; i < 20; i++)
            {
                ArrayNodes[i, 0] = -1;  // left pointer
                ArrayNodes[i, 1] = -1;  // data
                ArrayNodes[i, 2] = -1;  // right pointer
            }

            int FreeNode = 6;
            int RootPointer = 0;
        }

        static int SearchValue(int Root, int ValueToFind, int[,] ArrayNodes)
        {
            if (Root == -1)
            {
                return -1;
            }
            else if (ArrayNodes[Root, 1] == ValueToFind)
            {
                return Root;
            }
            else if (ArrayNodes[Root, 1] == -1)
            {
                return -1;
            }
            else if (ArrayNodes[Root, 1] > ValueToFind)
            {
                return SearchValue(ArrayNodes[Root, 0], ValueToFind, ArrayNodes);
            }
            else
            {
                return SearchValue(ArrayNodes[Root, 2], ValueToFind, ArrayNodes);
            }
        }

        static void PostOrder(int Root, int[,] ArrayNodes)
        {
            if (Root != -1)
            {
                PostOrder(ArrayNodes[Root, 0], ArrayNodes); // recursive call on left subtree
                PostOrder(ArrayNodes[Root, 2], ArrayNodes); // recursive call on right subtree
                Console.Write(ArrayNodes[Root, 1] + " "); // output the current node
            }
        }
        
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.AddNode(1);
            tree.AddNode(2);
            tree.AddNode(3);
            tree.AddNode(4);
            tree.AddNode(5);

            Console.WriteLine("Breadth-first search:");
            tree.BreadthFirstSearch();
        }
    }
}
