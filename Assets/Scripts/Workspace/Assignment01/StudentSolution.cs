using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment01
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {

        #region Lecture

        public void LCT01_SyntaxArray()
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_ArrayInitialize()
        {
            throw new System.NotImplementedException();
        }

        public void LCT03_SyntaxLoop()
        {
            throw new System.NotImplementedException();
        }

        public void LCT04_LoopAndArray(string[] ironManSuitNames)
        {
            throw new System.NotImplementedException();
        }

        public void LCT05_Syntax2DArray()
        {
            throw new System.NotImplementedException();
        }

        public void LCT06_SizeOf2DArray(int[,] my2DArray)
        {
            throw new System.NotImplementedException();
        }

        public void LCT07_SyntaxNestedLoop(int columns, int rows)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Assignment

        public void AS01_RandomItemDrop(GameObject[] items)
        {
            int random = Random.Range(0, items.Length);
            GameObject SItem = items[random];
            Instantiate(SItem, transform.position, Quaternion.identity);
            Debug.Log($"Got item: {SItem.name}");
        }

        public void AS02_NestedLoopForCreate2DMap(GameObject[] floorTiles, int columns, int rows)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    int random = Random.Range(0, floorTiles.Length);
                    GameObject STile = floorTiles[random];
                    Vector2 SPosition = new Vector2(x, y);
                    GameObject SpTile = Instantiate(STile, SPosition, Quaternion.identity);
                    SpTile.name = $"[{x}:{y}]";
                    Debug.Log(SpTile.name);
                }
            }
        }
        public void AS03_NestedLoopForMakingWallAround(GameObject wall, int columns, int rows)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1)
                    {
                        GameObject Swall = Instantiate(wall, new Vector2(x, y), transform.rotation);
                        Swall.name = $"[{x}:{y}]";
                    }
                }
            }
        }

        public void AS04_AttackEnemy(int[] enemyHP, int damage, int target)
        {
            if (enemyHP == null || enemyHP.Length == 0)
                return;

            int count = enemyHP.Length;

            enemyHP[0] -= damage;
            if (enemyHP[0] < 0) enemyHP[0] = 0;
            int firstHp = enemyHP[0];

            enemyHP[count - 1] -= damage;
            if (enemyHP[count - 1] < 0) enemyHP[count - 1] = 0;
            int lastHp = enemyHP[count - 1];

            enemyHP[target] -= damage;
            if (enemyHP[target] < 0) enemyHP[target] = 0;
            int targetHp = enemyHP[target];

            string output =
                "FirstEnemy hp :" + firstHp + "\n" +
                "LastEnemy hp :" + lastHp + "\n" +
                "TargetEnemy " + target + " hp :" + targetHp;

            Debug.Log(output);
        }

        public void AS05_DynamicIterationLoop(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Debug.Log(i);
            }
        }

        public void AS06_WhileLoopAndArray(string[] ironManSuitNames)
        {

            if (ironManSuitNames == null || ironManSuitNames.Length == 0) return;

            int i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i++;
            }

            Debug.Log("===");

            int j = 0;
            while (j < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[j]);
                j += 2;
            }
        }

        public void AS07_HealTargetAtIndex(int[] heroHPs, int heal, int targetIndex)
        {
            if (heroHPs == null || heroHPs.Length == 0)
                return;

            int count = heroHPs.Length;

            heroHPs[0] += heal;
            int firstHp = heroHPs[0];

            heroHPs[count - 1] += heal;
            int lastHp = heroHPs[count - 1];

            heroHPs[targetIndex] += heal;
            int targetHp = heroHPs[targetIndex];

            string output =
                "FirstHero hp :" + firstHp + "\n" +
                "LastHero hp :" + lastHp + "\n" +
                "TargetHero " + targetIndex + " hp :" + targetHp;

            Debug.Log(output);
        }

        public void AS08_RandomPickingDialogue(string[] dialogues)
        {
            if (dialogues.Length == 0)
            {
                return;
            }
            int randomIdx = Random.Range(0, dialogues.Length);
            Debug.Log(dialogues[randomIdx]);
        }

        public void AS09_MultiplicationTable(int n)
        {
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log($"{n}x{i}={n * i}");
            }
        }

        public void AS10_FindSummationFromZeroToNUsingWhileLoop(int n)
        {
            int sum = 0;
            int i = 0;
            while (i <= n)
            {
                sum += i;
                i++;
            }
            Debug.Log($"ผลรวมของ n จาก 0 ถึง {n} คือ {sum}");
        }

        public void AS11_SpawnEnemies(int[] enemyHPs, GameObject enemyPrefab)
        {
            for (int i = 0; i < enemyHPs.Length; i++)
            {
                float X = i + 1;
                Debug.Log($"new enemy at position x = {X}");
            }
        }

        public IEnumerator AS12_CountTime(float CountTime)
        {


            float time = CountTime;

            while (time > 0)
            {
                Debug.Log(time);
                yield return new WaitForSeconds(1f);
                time--;
            }

            Debug.Log("End timer : " + CountTime);
        }

        public void AS13_SumOfNumbersInRow(int[,] matrix, int row)
        {
            int sum = 0;
            int cols = matrix.GetLength(1);
            for (int j = 0; j < cols; j++)
            {
                sum += matrix[row, j];
            }
            Debug.Log(sum);
        }

        public void AS14_SumOfNumbersInColumn(int[,] matrix, int column)
        {
            int sum = 0;
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                sum += matrix[i, column];
            }
            Debug.Log(sum);
        }

        public void AS15_MakeTheTriangle(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                string row = "";
                for (int j = 0; j < i; j++)
                {
                    row += "*";
                }
                Debug.Log(row);
            }
        }

        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            for (int i = 1; i <= 12; i++)
            {
                string row = $"2 x {i} = {2 * i}\t3 x {i} = {3 * i}\t4 x {i} = {4 * i}";
                Debug.Log(row);
            }
        }
        #endregion

        #region Extra assignment

        public void EX_01_TicTacToeGame_TurnPlay(string[,] board, string playerTurn, int row, int column)
        {
            throw new System.NotImplementedException();
        }

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2] + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }
        #endregion
    }

}