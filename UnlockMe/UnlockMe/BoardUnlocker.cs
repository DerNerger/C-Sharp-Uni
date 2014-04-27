using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlockMe
{
    class BoardUnlocker
    {

        public string unlockBoard(Board b) 
        {
            List<string> UsedBoards = new List<string>();
            UsedBoards.Add(b.ToString());
            Queue<Board> BoardQueue = new Queue<Board>();
            BoardQueue.Enqueue(b);

            while (BoardQueue.Count > 0) 
            {
                Board currentBoard = BoardQueue.Dequeue();
                if (currentBoard.Tokens[0].Position.X+currentBoard.Tokens[0].Length==6 && currentBoard.Tokens[0].Position.Y == 2)
                { 
                    return currentBoard.History.ToString();
                }
                List<Board> allValidTurns = currentBoard.doAllValidTurns();
                foreach (var item in allValidTurns)
                {
                    string boardString = item.ToString();
                    if (!UsedBoards.Contains(boardString))
                    {
                        UsedBoards.Add(boardString);
                        BoardQueue.Enqueue(item);
                    }
                }
            }
            throw new Exception("Not solvable");
        }
    }
}
