using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHomework
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextItem { get; set; }
        public Node PrevItem { get; set; }
    }
    public class Homework2: IHomework
    {
        public string Name => "2";
        public void Run()
        {
            Console.Clear();
            Node node1 = new Node { Value = 101, NextItem = null, PrevItem = null };
            AddNode(node1, 123);
            AddNode(node1, 456);
            AddNode(node1, 789);
            AddNode(node1, 0);
            Console.WriteLine("Количество элементов в списке после добавления: " + GetCount(node1));
            Node testNode = FindNode(node1, 123);
            RemoveNode(node1);
            Console.WriteLine("Количество элементов после удаления первого элемента: " + GetCount(testNode));
            RemoveNodeByIndex(testNode, 4);
            Console.WriteLine("Количество элементов после удаления 4го элемента: " + GetCount(testNode));
            AddNodeAfter(testNode, 987);
            Console.WriteLine("Количество элементов после добавления нового элемента: " + GetCount(testNode));
            Program.ReturntoMainProgram(4);
        }
        
        static void AddNode(Node startNode, int value)
        {
            Node node = startNode;
            int count = 0;
            while (node.NextItem != null)
            {
                node = node.NextItem;
                count++;
            }
                
            Node newNode = new Node { Value = value };
            node.NextItem = newNode;
            newNode.PrevItem = node;
        }
        
        static void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node { Value = value };
            Node nextItem = node.NextItem;
            Node prevItem = nextItem.PrevItem;
            node.NextItem = newNode;
            nextItem.PrevItem = newNode;
            newNode.NextItem = nextItem;
            newNode.PrevItem = prevItem;
        }

        static void RemoveNodeByIndex(Node startNode, int index)
        {
            Node node = startNode;
            int i = 1;
            do
            {
                node = node.NextItem;
                i++;
            }
            while (i < index);
            RemoveNode(node);
        }
        
        static void RemoveNode(Node startNode)
        {
            Node node = startNode;
            Node nextItem = node.NextItem;
            Node prevItem = node.PrevItem;
            if (prevItem == null)
            {

            }
            else
                prevItem.NextItem = nextItem;
            if (nextItem == null)
            {

            }
            else
                nextItem.PrevItem = prevItem;
        }

        static int GetCount(Node startNode)
        {
            Node node = startNode;
            while (node.PrevItem != null)
                node.PrevItem = node;
            int count = 1;
            while (node.NextItem != null)
            {
                node = node.NextItem;
                count++;
            }
            return count;
        }

        static Node FindNode(Node startNode, int searchValue)
        {
            Node node = startNode;
            while (node.PrevItem != null)
                node.PrevItem = node;
            while (node.NextItem != null)
            {
                if (node.Value == searchValue)
                    return node;
                else node = node.NextItem;
            }
            return null;
        }
    }
}
