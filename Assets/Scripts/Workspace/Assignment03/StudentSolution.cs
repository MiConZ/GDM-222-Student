using AssignmentSystem.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment03
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture

        public void LCT01_SyntaxLinkedList()
        {
            // 1. สร้าง LinkedList ของประเภท string
            LinkedList<string> linkedList = new LinkedList<string>();

            // 2. เพิ่มข้อมูลที่ท้ายของ LinkedList
            linkedList.AddLast("Node 1");
            linkedList.AddLast("Node 2");

            // 3. เพิ่มข้อมูลที่ต้นของ LinkedList
            linkedList.AddFirst("Node 0");

            // 4. แสดงเนื้อหาใน LinkedList
            LCT01_PrintLinkedList(linkedList);

            // 5. เช้าถึงข้อมูลใน LinkedList
            LinkedListNode<string> firstNode = linkedList.First;
            Debug.Log("first", firstNode.Value);
            LinkedListNode<string> lastNode = linkedList.Last;
            Debug.Log("last", lastNode.Value);
            LinkedListNode<string> node1 = linkedList.Find("Node 1");
            Debug.Log(node1.Previous.Value);
            Debug.Log(node1.Next.Value);
            if (firstNode.Previous == null)
            {
                Debug.Log("firstNode.Previous is null");
            }
            if (lastNode.Next == null)
            {
                Debug.Log("lastNode.Next is null");
            }

            // 6. add node ก่อน หรือ หลัง node ที่กำหนด
            linkedList.AddAfter(node1, "Node 1.5");
            linkedList.AddBefore(node1, "Node 0.5");
            LCT01_PrintLinkedList(linkedList);

            // 6. ลบ Node แรก
            linkedList.RemoveFirst();
            LCT01_PrintLinkedList(linkedList);

            // 7. ลบ Node ตามค่าที่กำหนด
            linkedList.Remove("Node 2");
            LCT01_PrintLinkedList(linkedList);
        }

        private void LCT01_PrintLinkedList(LinkedList<string> linkedList)
        {
            Debug.Log("LinkedList ...");
            foreach (var node in linkedList)
            {
                Debug.Log(node);
            }
        }

        public void LCT02_SyntaxHashTable()
        {

            Hashtable hashtable = new Hashtable();
            //Key Value
            hashtable.Add(1, "Apple");
            hashtable.Add(2, "Banana");
            hashtable.Add("bad-fruit", "Rotten Tomato");

            string fruit1 = (string)hashtable[1];
            string fruit2 = (string)hashtable[2];
            string badFruit = (string)hashtable["bad-fruit"];

            Debug.Log($"fruit1: {fruit1}");
            Debug.Log($"fruit2: {fruit2}");
            Debug.Log($"badFruit: {badFruit}");

            LCT02_PrintHashTable(hashtable);

            int key = 2;
            if (hashtable.ContainsKey(key))
            {
                Debug.Log($"found {key}");
            }
            else
            {
                Debug.Log($"not found {key}");
            }

            int keyToRemove = 1;
            hashtable.Remove(keyToRemove);
            LCT02_PrintHashTable(hashtable);
        }
        public void LCT02_PrintHashTable(Hashtable hashtable)
        {
            Debug.Log("table ...");
            foreach (DictionaryEntry entry in hashtable)
            {
                Debug.Log($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        public void LCT03_SyntaxDictionary()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            dict.Add(1, "Apple");
            dict.Add(2, "Durian");
            dict[3] = "Coconut";

            LCT03_PrintDictionary(dict);

            int keyToCheck = 1;
            bool hasKey = dict.ContainsKey(keyToCheck);

            Debug.Log($"has key {keyToCheck} : {hasKey}");

            if (hasKey)
            {
                string value = dict[keyToCheck];
                Debug.Log($"value of key {keyToCheck} : {value}");
            }

            Debug.Log("All keys in dictionary:");
            foreach (int key in dict.Keys)
            {
                Debug.Log(key);
            }

            int keyToRemove = 1;
            dict.Remove(keyToRemove);

            LCT03_PrintDictionary(dict);

            dict.Clear();
        }

        private void LCT03_PrintDictionary(Dictionary<int, string> dict)
        {
            Debug.Log($"Dictionary has {dict.Count} keys");

            foreach (KeyValuePair<int, string> kvp in dict)
            {
                Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }

        #endregion

        #region Assignment

        public void AS01_CountWords(string[] words)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (string w in words)
            {
                if (wordCount.ContainsKey(w)) wordCount[w]++;
                else wordCount[w] = 1;
            }
            foreach (var item in wordCount)
                Debug.Log($"word: '{item.Key}' count: {item.Value}");
        
        }

        public void AS02_CountNumber(int[] numbers)
        {
            Dictionary<int, int> numCount = new Dictionary<int, int>();

            
            foreach (int n in numbers)
            {
                if (numCount.ContainsKey(n))
                {
                    numCount[n]++;
                }
                else
                {
                    numCount[n] = 1;
                }
                 }
            foreach (KeyValuePair<int, int> item in numCount)
            {
               
                Debug.Log("number: " + item.Key + " count: " + item.Value );
            }
        }

        public void AS03_CheckValidBrackets(string input)
        {
            Dictionary<char, char> bracketMap = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

            LinkedList<char> stack = new LinkedList<char>();

            foreach (char c in input)
            {
                
                if (bracketMap.ContainsKey(c))
                {
                    stack.AddLast(c);
                }
          
                else if (bracketMap.ContainsValue(c))
                {
                    
                    if (stack.Count == 0 || bracketMap[stack.Last.Value] != c)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                   
                    stack.RemoveLast();
                }
            }
            if (stack.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }
        }

        public void AS04_PrintReverseLinkedList(LinkedList<int> list)
        {

            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<int> current = list.Last;

        
            while (current != null)
            {
                
                Debug.Log(current.Value);
                current = current.Previous;
            }
        }

        public void AS05_FindMiddleElement(LinkedList<string> list)
        {
            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty"); 
                return;
            }

    
            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;          
                fast = fast.Next.Next;     
            }

            Debug.Log(slow.Value);
        }

        public void AS06_MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            Dictionary<string, int> mergedDict = new Dictionary<string, int>(dict1);

       
            foreach (var kvp in dict2)
            {
                
                if (mergedDict.ContainsKey(kvp.Key))
                {
                    mergedDict[kvp.Key] += kvp.Value;
                }
                else
                {
                    mergedDict.Add(kvp.Key, kvp.Value);
                }
            }

          
            foreach (var kvp in mergedDict)
            {
                Debug.Log($"key: {kvp.Key}, value: {kvp.Value}");
            }
        }

        public void AS07_RemoveDuplicatesFromLinkedList(LinkedList<int> list)
        {
            if (list == null || list.Count <= 1)
            {
                if (list != null) foreach (var item in list) Debug.Log(item);
                return;
            }

          
            Dictionary<int, bool> seenValues = new Dictionary<int, bool>();
            LinkedListNode<int> current = list.First;

           
            while (current != null)
            {
                LinkedListNode<int> next = current.Next;

                if (seenValues.ContainsKey(current.Value))
                {
                    list.Remove(current); 
                }
                else
                {
                    seenValues.Add(current.Value, true); 
                }
                current = next;
            }

           
            foreach (var item in list)
            {
                Debug.Log(item);
            }
        }
        

        public void AS08_TopFrequentNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (int num in numbers)
            {
                if (counts.ContainsKey(num))
                    counts[num]++;
                else
                    counts[num] = 1;
            }

          
            int topNum = numbers[0];
            int maxCount = 0;

            foreach (var pair in counts)
            {
                if (pair.Value > maxCount)
                {
                    maxCount = pair.Value;
                    topNum = pair.Key;
                }
            }

            
            Debug.Log($"{topNum} count: {maxCount}");
        }

        public void AS09_PlayerInventory(Dictionary<string, int> inventory, string itemName, int quantity)
        {
            if (inventory == null)
            {
                Debug.Log("Inventory is null");
                return;
            }

           
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory.Add(itemName, quantity);
            }

          
            foreach (var item in inventory)
            {
                Debug.Log($"{item.Key}: {item.Value}");
            }
        }

        #endregion

        #region Extra

        public void EX01_GameEventQueue(LinkedList<GameEvent> eventQueue)

        {
            if (eventQueue == null)
            {
                Debug.Log("Event queue is empty");
            }
            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;
                eventQueue.RemoveFirst();

                string msg = currentEvent.Name;
                string type = currentEvent.EventType;

                Debug.Log("Processing event: " + msg);
                Debug.Log("Remaining events in queue: " + eventQueue.Count);

                if (type == "enemy")
                {
                    Debug.Log("Enemy event processed - " + msg);
                }
                else if (type == "powerup")
                {
                    Debug.Log("Power-up event processed - " + msg);
                }
                else if (type == "level")
                {
                    Debug.Log("Level event processed - " + msg);
                }
                else if (type == "achievement")
                {
                    Debug.Log("Achievement unlocked - " + msg);
                }
                else
                {
                    Debug.Log("Generic event processed - " + msg);
                }
            }

        }

        public void EX02_PlayerStatsTracker(Dictionary<string, int> playerStats, string statName, int value)
        {
            if (playerStats == null) return;

            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else
            {
                playerStats.Add(statName, value);
            }

            Debug.Log("Updated " + statName + ": " + playerStats[statName]);
            Debug.Log("Current player statistics:");

            foreach (KeyValuePair<string, int> stat in playerStats)
            {
                Debug.Log(stat.Key + ": " + stat.Value);
            }
        }

        #endregion
    }
}
