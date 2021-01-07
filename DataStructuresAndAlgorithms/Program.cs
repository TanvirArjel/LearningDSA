// <copyright file="Program.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using DataStructuresAndAlgorithms.DataStructures.LinkedLists;

namespace DataStructuresAndAlgorithms
{
    internal static class Program
    {
        private static void Main()
        {
            SinlgyLinkedList list = new SinlgyLinkedList();

            SinglyLinkedListNode<int> node1 = new SinglyLinkedListNode<int>(3);
            SinglyLinkedListNode<int> node2 = new SinglyLinkedListNode<int>(4);

            SinglyLinkedListNode<int> head1 = null;
            head1 = list.AddToEnd(head1, 1);
            head1 = list.AddToEnd(head1, 2);
            head1 = list.AddToEnd(head1, node1);
            head1 = list.AddToEnd(head1, node2);

            list.Print(head1);
            Console.WriteLine();

            SinglyLinkedListNode<int> head2 = new SinglyLinkedListNode<int>(1);
            head2 = list.AddToEnd(head2, node1);

            list.Print(head2);
            Console.WriteLine();

            SinglyLinkedListNode<int> mergeNode = SinlgyLinkedList.FindMergeNode(head1, head2);

            Console.WriteLine();
            list.Print(mergeNode);

            Console.WriteLine();
            Console.WriteLine("Learning Data Structure And Algorithms");
        }

        private static int Method2()
        {
            int[] intArray = new int[] { 3, 8, 2, 3, 3, 2 };

            Dictionary<int, int> numberCounts = new Dictionary<int, int>();

            for (int i = 0; i < intArray.Length; i++)
            {
                int currentNumber = intArray[i];
                int currentNumberCount;

                if (numberCounts.TryGetValue(currentNumber, out currentNumberCount))
                {
                    numberCounts[currentNumber] = currentNumberCount + 1;
                }
                else
                {
                    numberCounts[currentNumber] = 1;
                }
            }

            int[] validNumbers = numberCounts.Where(num => num.Key == num.Value).Select(num => num.Key).ToArray();

            int maxNumber = 0;

            for (int i = 0; i < validNumbers.Length; i++)
            {
                if (validNumbers[i] > maxNumber)
                {
                    maxNumber = validNumbers[i];
                }
            }

            Console.WriteLine(maxNumber);

            return maxNumber;
        }

        private static int Method1()
        {
            string inputString = "We test coders. Give us a try?";

            char[] delimiters = new char[] { '.', '?', '!' };

            string[] sentences = inputString.Split(delimiters);

            int longestSentenceLength = 0;

            for (int i = 0; i < sentences.Length; i++)
            {
                string currentSentence = sentences[i];
                string[] currentSentenceWords = currentSentence.Split(' ');

                currentSentenceWords = currentSentenceWords.Where(csw => !string.IsNullOrEmpty(csw)).ToArray();
                if (currentSentenceWords.Length > longestSentenceLength)
                {
                    longestSentenceLength = currentSentenceWords.Length;
                }
            }

            return longestSentenceLength;
        }
    }
}
