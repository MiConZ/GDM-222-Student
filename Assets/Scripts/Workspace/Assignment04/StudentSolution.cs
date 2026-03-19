using AssignmentSystem.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment04
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture
        public void LCT01_SelectionSortAscending(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_BubbleSortAscending(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        public void LCT03_InsertionSortAscending(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Assignment

        public void AS01_SelectionSortDescending(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 0; i < n - 1; i++)
            {

                int maxIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] > numbers[maxIdx])
                    {
                        maxIdx = j;
                    }
                }


                int temp = numbers[maxIdx];
                numbers[maxIdx] = numbers[i];
                numbers[i] = temp;
            }

            foreach (int num in numbers)
            {
                Debug.Log(num);
            }

        }

        public void AS02_BubbleSortDescending(int[] numbers)
        {
            int n = numbers.Length;


            for (int i = 0; i < n - 1; i++)
            {

                for (int j = 0; j < n - i - 1; j++)
                {

                    if (numbers[j] < numbers[j + 1])
                    {

                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            foreach (int num in numbers)
            {
                Debug.Log(num);
            }

        }

        public void AS03_InsertionSortDescending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = numbers[i];
                int j = i - 1;


                while (j >= 0 && numbers[j] < key)
                {
                    numbers[j + 1] = numbers[j];
                    j = j - 1;
                }
                numbers[j + 1] = key;
            }


            foreach (int num in numbers)
            {
                Debug.Log(num);
            }
        }

        public void AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
            {
                Debug.Log("Array must have at least two numbers.");
                return;
            }

            Array.Sort(numbers);


            Array.Reverse(numbers);


            int largest = numbers[0];
            int? secondLargest = null;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < largest)
                {
                    secondLargest = numbers[i];
                    break;
                }
            }


            if (secondLargest.HasValue)
            {
                Debug.Log(secondLargest.Value);
            }
            else
            {
                Debug.Log("No second largest number found (all numbers might be the same).");
            }

        }

        #endregion

        #region Extra

        public void EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
