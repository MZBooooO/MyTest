using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node
{
    public int? data;
    public Node left;
    public Node right;

    public Node(int? value)
    {

        data = value;
        left = null;
        right = null;
    }
}

public class Tree
{
    public Node root;

    public Tree(List<int?> values)
    {
        root = InitTree(values,0);
    }
    
    public Node InitTree(List<int?> values,int index)
    {
        if (index >= values.Count || values[index] == null) 
        {
            return null;
        }
        Node node = new Node(values[index]);
        node.left = InitTree(values, 2 * index + 1);
        node.right = InitTree(values, 2 * index + 2);
        return node;
    }

    public List<int> mostLeftNode()
    {
        List<int> res = new List<int>();
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                Node node = queue.Dequeue();
                if (i == 0) {
                    res.Add((int)node.data);
                }
                if (node.left != null) {
                    queue.Enqueue(node.left);
                }
                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
        }

        return res;
    }
}
