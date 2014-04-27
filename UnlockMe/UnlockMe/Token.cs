using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UnlockMe
{
    public class Token
    {
        public Vector Position
        {
            get;
            set;
        }

        public Alignment Alignment
        {
            get;
            set;
        }

        public int Length
        {
            get;
            set;
        }

        public int Number
        {
            get;
            set;
        }

        public Token(Vector Position, Alignment Alignment, int Length, int Number) 
        {
            this.Position = Position;
            this.Alignment = Alignment;
            this.Length = Length;
            this.Number = Number;
        }

        public Token(Token t) 
        {
            this.Position = new Vector(t.Position.X, t.Position.Y);
            this.Alignment = t.Alignment;
            this.Length = t.Length;
            this.Number = t.Number;
        }

        public bool isOnPosition(int x, int y) 
        {
            switch (Alignment)
            {
                case Alignment.vertical:
                    return (Position.X==x && Position.Y <= y && Position.Y+Length>y);
                case Alignment.horizontal:
                     return (Position.Y==y && Position.X <= x && Position.X+Length>x);
                default:
                     throw new Exception("Wrong Alignment");
            }
        }
    }

    public enum Alignment 
    {
        vertical, horizontal
    }
}
