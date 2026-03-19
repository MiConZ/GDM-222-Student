using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment08
{
    public class StudentSolution : IAssignment
    {
        class Action
        {
            public string Name;
            public int Value;
        }

        #region Lecture

        public void LCT01_StackSyntax()
        {
            throw new NotImplementedException();
        }

        public void LCT02_QueueSyntax()
        {
            throw new NotImplementedException();
        }

        public void LCT03_ActionStack()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            throw new NotImplementedException();
        }

        public void LCT04_ActionQueue()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            throw new NotImplementedException();
        }

        #endregion

        #region Assignment

        public void ASN01_ReverseString(string str)
        {
          
            if (string.IsNullOrEmpty(str))
            {
                Debug.Log(""); 
                return;
            }
            Stack<char> charStack = new Stack<char>();
            foreach (char c in str)
            {
                charStack.Push(c);
            }

          
            StringBuilder sb = new StringBuilder();
            while (charStack.Count > 0)
            {
                sb.Append(charStack.Pop());
            }

          
            Debug.Log(sb.ToString());
        }

        public void ASN02_StackPalindrome(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in str)
            {
                stack.Push(c);
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            string reversedStr = sb.ToString();

            
            if (str == reversedStr)
            {
                Debug.Log($" is a palindrome");
            }
            else
            {
                Debug.Log($" is not a palindrome");
            }
        }

        #endregion

        #region Extra

        public void EX01_ParenthesesChecker(string str)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
