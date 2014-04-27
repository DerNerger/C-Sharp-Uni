using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlockMe
{
    public class Board
    {

        //First Token is always the red Token
        public Token[] Tokens
        {
            get;
            set;
        }

        public StringBuilder History
        {
            get;
            set;
        }

        public Board(Token[] Tokens) 
        {
            this.Tokens = Tokens;
            History = new StringBuilder();
        }

        public Board(Board b) 
        {
            Tokens = new Token[b.Tokens.Length];
            for (int i = 0; i < Tokens.Length; i++)
            {
                Tokens[i] = new Token(b.Tokens[i]);
            }
            History = new StringBuilder(b.History.ToString());
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    str.Append(getTokenNumberOnPosition(j, i));
                    str.Append("   ");
                }
                str.Append("\n");
            }
            return str.ToString();
        }

        public int getTokenNumberOnPosition(int x, int y) 
        {
            for (int i = 0; i < Tokens.Length; i++)
            {
                if (Tokens[i].isOnPosition(x, y))
                    return Tokens[i].Number;
            }
            return 0;
        }

        public List<Board> doAllValidTurns() 
        {
            List<Board> allValidBoards = new List<Board>();
            for (int i = 0; i < Tokens.Length; i++)
            {
                Token t = Tokens[i];
                switch (t.Alignment)
                {
                    case Alignment.vertical:
                        if (t.Position.Y != 0 && getTokenNumberOnPosition(t.Position.X , t.Position.Y-1) == 0)
                        {
                            Board copy = new Board(this);
                            copy.Tokens[i].Position.Y--;
                            copy.History.Append((i + 1) + "o, ");
                            allValidBoards.Add(copy);
                        }
                        if (t.Position.Y+t.Length != 6 && getTokenNumberOnPosition(t.Position.X, t.Position.Y+t.Length) == 0)
                        {
                            Board copy = new Board(this);
                            copy.Tokens[i].Position.Y++;
                            copy.History.Append((i + 1) + "u, ");
                            allValidBoards.Add(copy);
                        }
                        break;
                    case Alignment.horizontal:
                        if (t.Position.X != 0 && getTokenNumberOnPosition(t.Position.X - 1, t.Position.Y) == 0)
                        {
                            Board copy = new Board(this);
                            copy.Tokens[i].Position.X--;
                            copy.History.Append((i + 1) + "l, ");
                            allValidBoards.Add(copy);
                        }
                        if (t.Position.X+t.Length != 6 && getTokenNumberOnPosition(t.Position.X +t.Length , t.Position.Y) == 0)
                        {
                            Board copy = new Board(this);
                            copy.Tokens[i].Position.X++;
                            copy.History.Append((i + 1) + "r, ");
                            allValidBoards.Add(copy);
                        }
                        break;
                    default:
                        throw new Exception("Wrong Alignment");
                }
            }
            return allValidBoards;
        }
    }
}
