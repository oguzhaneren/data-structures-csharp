﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;


namespace DataStructures.TrieSpace
{
    [Serializable]
    public class Trie
    {
        public Node Root { get; private set; }


        public Trie()
        {
            Root = new NullNode();
        }


        /// <summary>
        /// Check if an word exists
        /// </summary>
        /// <param name="word">word to search for</param>
        /// <returns>True if that word exists</returns>
        [Pure]
        public bool Exists(string word)
        {
            Contract.Requires(!string.IsNullOrEmpty(word), "Trie doesn't include empty string or null values");

            Node current = Root;
            foreach (char ch in word)
            {
                Node childNode = current.HasChild(ch);
                if (childNode == null)
                {
                    //Element doesn't exist
                    return false;
                }
                current = childNode;
            }
            return current.HasNullChild();
        }


        /// <summary>
        /// Adds word to the end of speicified node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="word"></param>
        public void Add(Node node, string word)
        {
            Contract.Requires(!string.IsNullOrEmpty(word), "Trie doesn't include empty string or null values");

            foreach (char ch in word)
            {
                Node childNode = node.AddChild(ch);
                node = childNode;
            }
            node.AddNullChild();
        }

        /// <summary>
        /// Adds a word if it doesn't exist
        /// </summary>
        /// <param name="word"></param>
        public void Add(string word)
        {
            Contract.Requires(!string.IsNullOrEmpty(word), "Trie doesn't include empty string or null values");

            Node current = Root;
            for (int i = 0; i < word.Length; i++)
            {
                Node childNode = current.HasChild(word[i]);
                if (childNode == null)
                {
                    Add(current, word.Substring(i));
                    break;
                }
                current = childNode;
            }
        }

        public void Remove(string word)
        {
            Contract.Requires(!string.IsNullOrEmpty(word), "Trie doesn't include empty string or null values");

            if (!Exists(word))
            {
                return;
            }
            var current = Root;
            foreach (var ch in word)
            {

            }
        }

        //private Stack<Node> PushLeft(Stack<Node> stack, Node x)
        //{
        //    Contract.Requires<ArgumentNullException>(stack != null);
        //    while (x != null)
        //    {
        //        stack.Push(x);
        //        x = x.GetChildrenList;
        //    }
        //    return stack;
        //}

        private List<string> Enumerate(Node node)
        {
            //var stack = new Stack<Node>();
            //stack = PushLeft(stack, Root);

        }

        public List<string> GetStringsContainingPrefix(string prefix)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(prefix));
            Contract.Ensures(Contract.Result<List<string>>() != null);

            var words = new List<string>();
            var current = Root;
            foreach (char ch in prefix)
            {
                Node childNode = current.HasChild(ch);
                if (childNode == null)
                {
                    //No words with current prefix
                    return words;
                }
                current = childNode;
            }

            return words;
        }
    }
}
