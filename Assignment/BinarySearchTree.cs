using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// Class to create nodes for a binary tree
    /// </summary>
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

    }
    /// <summary>
    /// Checks if a given binary tree is a valid binary search tree.
    /// </summary>
    public class BinarySearchTree
    {
        Node n1;
        Node n3;
        Node n2;

        /// <summary>
        /// Constructor to initialize the node values
        /// </summary>
        public BinarySearchTree()
        {
            n1 = new Node(1, null, null);
            n3 = new Node(3, null, null);
            n2 = new Node(2, n1, n3);
        }
        /// <summary>
        /// Calls the method to validate the tree
        /// </summary>
        public void Check()
        {
            bool isValidBST = IsValidBST(n2);
            Console.WriteLine(isValidBST);
            Console.WriteLine("The given binary tree is " + (isValidBST ? "valid" : "invalid") + " binary search tree");
        }
        /// <summary>
        /// Recursive method to check whether the given binary tree is a valid binary search tree or not.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="MIN"></param>
        /// <param name="MAX"></param>
        /// <returns>true/false</returns>
        private bool IsValidBST(Node node, int MIN = int.MinValue, int MAX = int.MaxValue)
        {
            try
            {
                if (node == null)
                    return true;
                if (node.Value > MIN
                    && node.Value < MAX
                    && IsValidBST(node.Left, MIN, node.Value)
                    && IsValidBST(node.Right, node.Value, MAX))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.Log(string.Format("Exception at BinarySearchTree.IsValidBST {0} ST {1}", ex.Message, ex.StackTrace));
                return false;
            }
        }
    }
}