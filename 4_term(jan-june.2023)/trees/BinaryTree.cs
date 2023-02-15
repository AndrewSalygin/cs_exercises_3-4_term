using System;
using System.Collections.Generic;
using System.IO;

namespace sem4_1.Properties
{
    internal class BinaryTree
    {
        private class Node
        {
            public object inf;
            public Node left;
            public Node right;

            public Node(object nodeInf)
            {
                inf = nodeInf;
            }

            public static void Add(ref Node r, object nodeInf)
            {
                if (r == null)
                    r = new Node(nodeInf);
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                    {
                        Add(ref r.left, nodeInf);
                    }
                    else
                    {
                        Add(ref r.right, nodeInf);
                    }
                }
            }

            public static void Preorder(Node r) // прямой обход
            {
                if (r != null)
                {
                    Console.Write("{0} ", r.inf);
                    Preorder(r.left);
                    Preorder(r.right);
                }
            }

            public static void Inorder(Node r) //симметричный обход дерева
            {
                if (r != null)
                {
                    Inorder(r.left);
                    Console.Write("{0} ", r.inf);
                    Inorder(r.right);
                }
            }

            public static void Postorder(Node r) //обратный обход дерева
            {
                if (r != null)
                {
                    Postorder(r.left);
                    Postorder(r.right);
                    Console.Write("{0} ", r.inf);
                }
            }

            public static void Search(Node r, object key, out Node item)
            {
                if (r == null)
                    item = null;
                else
                {
                    // Equals()?
                    if (((IComparable)(r.inf)).CompareTo(key) == 0)
                        item = r;
                    else
                    {
                        if (((IComparable)(r.inf)).CompareTo(key) > 0)
                            Search(r.left, key, out item);
                        else
                            Search(r.left, key, out item);
                    }
                }
            }

            private static void Del(Node t, ref Node tr)
            {
                if (tr.right != null)
                    Del(t, ref tr.right);
                else
                {
                    t.inf = tr.inf;
                    tr = tr.left;
                }
            }

            public static void Delete(ref Node t, object key)
            {
                if (t == null)
                    throw new Exception("Value is not in tree");
                else
                {
                    if (((IComparable)(t.inf)).CompareTo(key) > 0)
                        Delete(ref t.left, key);
                    else
                    {
                        if (((IComparable)(t.inf)).CompareTo(key) < 0)
                            Delete(ref t.right, key);
                        else
                        {
                            if (t.left == null)
                                t = t.right;
                            else
                            {
                                if (t.right == null)
                                    t = t.left;
                                else
                                    Del(t, ref t.left);
                            }
                        }
                    }
                }
            }
            
            // #1
            public static void InorderWithoutWrite(Node r, ref int k) //симметричный обход дерева
            {
                if (r != null)
                {
                    InorderWithoutWrite(r.left, ref k);
                    if (r.left != null && r.right == null)
                        k++;
                    InorderWithoutWrite(r.right, ref k);
                }
            }
            
            public static int CountNodeOneLeftSon(Node r)
            {
                int k = 0;
                InorderWithoutWrite(r, ref k);
                return k;
            }
            
            // #2
            public static void PrintLevels(Node r)
            {
                Queue<Node> nodes = new Queue<Node>();
                nodes.Enqueue(r);
                using (StreamWriter fileOut = new StreamWriter("output.txt", true))
                {
                    while (nodes.Count != 0)
                    {
                        r = nodes.Dequeue();
                        fileOut.Write("{0} ", r.inf);
                        if (r.left != null)
                            nodes.Enqueue(r.left);
                        if (r.right != null)
                            nodes.Enqueue(r.right);
                    }
                }
            }
            
            // #3
            public static void PreorderCount(Node r, ref int k) // прямой обход
            {
                if (r != null)
                {
                    k++;
                    Preorder(r.left);
                    Preorder(r.right);
                }
            }

            public static void DelNodesAndCheckPerfectlyBalancedTree(Node r, int n)
            {
                Node main = r;
                Node left = main.left;
                Node right = main.right;
                int k_left = 0;
                int k_right = 0;
                while (main != r)
                {
                    PreorderCount(left, ref k_left);
                    PreorderCount(right, ref k_right);

                    if (Math.Abs(k_left - k_right) <= 1)
                    {
                        using (StreamWriter fileOut = new StreamWriter("output.txt", true))
                        {
                            fileOut.WriteLine("True");
                        }
                    }
                    if (Math.Abs(k_left - k_right) < n)
                    {
                        if (k_left > k_right)
                        {
                           // Delete(r);
                        }
                    }
                }
            }
            
        } // end of Node
        Node tree; //ссылка на корень дерева
        //свойство позволяет получить доступ к значению информационного поля корня дерева
        public object Inf
        {
            set {tree.inf=value;}
            get {return tree.inf;}
        }
        public BinaryTree() //открытый конструктор
        {
            tree=null;
        }
        private BinaryTree(Node r) //закрытый конструктор
        {
            tree=r;
        }
        public void Add(object nodeInf) //добавление узла в дерево
        {
            Node.Add(ref tree, nodeInf);
        }
        //организация различных способов обхода дерева
        public void Preorder ()
        {
            Node.Preorder(tree);
        }
        public void Inorder ()
        {
            Node.Inorder (tree);
        }
        public void Postorder ()
        {
            Node.Postorder(tree);
        }
        //поиск ключевого узла в дереве
        public BinaryTree Search(object key)
        {
            Node r;
            Node.Search(tree, key, out r);
            BinaryTree t=new BinaryTree(r);
            return t;
        }
        //удаление ключевого узла в дереве
        public void Delete(object key)
        {
            Node.Delete(ref tree, key);
        }
        
        // #1
        public int CountNodeOneLeftSon ()
        {
            return Node.CountNodeOneLeftSon(tree);
        }
        
        // #2
        public void PrintLevels()
        {
            Node.PrintLevels(tree);
        }
        
        // #3
      //  public bool DelNodesAndCheckPerfectlyBalancedTree()
       // {
       //     Node.DelNodesAndCheckPerfectlyBalancedTree();
        //}
    }
}