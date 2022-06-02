using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHomework
{
    internal class Homework5: IHomework
    {
        public string Name => "5";
        public void Run()
        {
            Console.Clear();
            Tree tree = new Tree() { Data = 111 };
            tree.Add(66);
            tree.Add(166);
            tree.Add(55);
            tree.Add(77);
            tree.Add(155);
            tree.Add(177);
            tree.Add(44);
            tree.Print();
            Console.WriteLine("BFS: Найдём элемент со значением '66'");
            Tree findBFSTree = FindBFS(tree, 66);
            if (findBFSTree == null)
                Console.WriteLine("Элемент не найден");
            else
                findBFSTree.Print();
            Console.WriteLine("DFS: Найдём элемент со значением 55");
            Tree findDFSTree = FindDFS(tree, 55);
            if (findDFSTree == null)
                Console.WriteLine("Элемент не найден");
            else
                findDFSTree.Print();
            Program.ReturntoMainProgram(0);
        }

        public Tree FindBFS(Tree tree, int data)
        {
            Queue<Tree> queue = new Queue<Tree>();
            queue.Enqueue(tree);
            queue = BFS(queue, data);
            return queue.Dequeue();
        }
        private Queue<Tree> BFS(Queue<Tree> treeQueue, int data)
        {
            if(treeQueue == null)
            {
                return treeQueue;
            }
            Tree tree = treeQueue.Peek();
            if (tree == null)
                return null;
            else if (tree.Data == data)
            {
                return treeQueue;
            }
            else
            {
                treeQueue.Dequeue();
                treeQueue.Enqueue(tree.Left);
                treeQueue.Enqueue(tree.Right);
                BFS(treeQueue, data);
            }
            return treeQueue;
        }
        public Tree FindDFS(Tree tree, int data)
        {
            Stack<Tree> stack = new Stack<Tree>();
            stack.Push(tree);
            stack = DFS(stack, data);
            return stack.Pop();
        }
        private Stack<Tree> DFS(Stack<Tree> treeStack, int data)
        {
            if (treeStack == null)
                return null;
            Tree tree = treeStack.Peek();
            if (tree == null)
            {
                treeStack.Pop();
                DFS(treeStack, data);
                return treeStack;
            }
            else if (tree.Data == data)
                return treeStack;
            else
            {
                treeStack.Pop();
                treeStack.Push(tree.Right);
                treeStack.Push(tree.Left);
                DFS(treeStack, data);
            }
            return treeStack;
        }
    }
}
