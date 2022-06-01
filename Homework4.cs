using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHomework
{
    public class Tree
    {
        public int Data { get; set; }
        public Tree Left { get; set; }
        public Tree Right { get; set; }
        public Tree Parent { get; set; }
        /// <summary>
        /// Добавление элемента в дерево
        /// </summary>
        /// <param name="data">Значение</param>
        public void Add(int data)
        {
            if (this.Data > data)
            {
                if (Left == null)
                    Left = new Tree() { Data = data, Parent = this };
                else
                    Left.Add(data);
            }
            else if (this.Data < data)
            {
                if (Right == null)
                    Right = new Tree() { Data = data, Parent = this };
                else
                    Right.Add(data);
            }
            else
                Console.WriteLine($"Узел {data} уже существует");
        }
        /// <summary>
        /// Удаление элемента дереваю
        /// </summary>
        public void Delete()
        {
            if (Parent == null)
            {
                Right = null;
                Left = null;
                Data = 0;
            }
            else
            {
                Tree parentTree = this.Parent;
                if (parentTree.Left == this)
                    parentTree.Left = null;
                else
                    parentTree.Right = null;
                this.Parent = null;
            }
        }
        /// <summary>
        /// Функция взаимодействия дерева с методом удаления
        /// </summary>
        /// <param name="data">Значение для удаления</param>
        public void DeleteByData(int data)
        {
            Tree tree = this;
            DeletingByData(tree, data);
        }
        /// <summary>
        /// Метод удаления элемента в дереве по значению.
        /// </summary>
        /// <param name="tree">Заданное дерево</param>
        /// <param name="data">Значение</param>
        private void DeletingByData(Tree tree, int data)
        {
            if (tree != null)
            {
                if (tree.Data == data)
                {
                    tree.Delete();
                }
                else
                {
                    DeletingByData(tree.Left, data);
                    DeletingByData(tree.Right, data);
                }
            }
        }
        /// <summary>
        /// Переход к печати функции, для корректной работы рекурсии и упращени вызова метода отрисовки.
        /// </summary>
        public void Print()
        {
            DrawTree("", true);
        }
        /// <summary>
        /// Метод отрисовки дерева
        /// </summary>
        /// <param name="offset">Вспомогательные символы</param>
        /// <param name="lastElement">Проверка на последнюю ветку в иерархии дерева</param>
        private void DrawTree(string offset, bool lastElement)
        {
            Console.Write(offset);
            if (lastElement)
            {
                Console.Write("└─");
                offset += "  ";
            }
            else
            {
                Console.Write("├─");
                offset += "| ";
            }
            Console.WriteLine(Data);
            List<Tree> list = new List<Tree>();
            if (Left != null)
                list.Add(Left);
            if (Right != null)
                list.Add(Right);

            for (int i = 0; i < list.Count; i++)
                list[i].DrawTree(offset, i == list.Count - 1);
        }
    }
    internal class Homework4: IHomework
    {
        public string Name => "4";

        public void Run()
        {
            Console.Clear();
            Tree tree = new Tree() { Data = 200 };
            tree.Add(222);
            tree.Add(333);
            tree.Add(50);
            tree.Add(50);// Проверка на создания узла с одиннаковым значением
            tree.Add(212);
            tree.Add(15);
            tree.Add(25);
            tree.Add(213);
            tree.Add(205);
            tree.Add(100);
            tree.Print();
            Console.WriteLine("Дерево после удаления элемента Left.Left");
            tree.Left.Left.Delete();
            tree.Print();
            Console.WriteLine("Дерево после удаления элемента с значением '212'");
            tree.DeleteByData(212);
            tree.Print();
            Program.ReturntoMainProgram(0);
        }
        
    }
}
