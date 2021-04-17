//Bonga Maswanganye
using System;
using System.Collections.Generic;
using System.Text;

namespace NqueenHillClimbing
{
    class NQueen
    {
        #region Constructor and variables
        int Row;
        int Column;
        public NQueen(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        #endregion

        #region Board Stuff

        public bool BoardCheck(NQueen Board)
        {
            if (Row == Board.GetRow() || Column == Board.GetColumn())
                return true;
            //  Check diagonals
            else if (Math.Abs(Column - Board.GetColumn()) == Math.Abs(Row - Board.GetRow()))
                return true;
            return false;

        }

        public void MoveRow()
        {
            Row++;
        }

        public void MoveColumn()
        {
            Column++;
        }

        public int GetRow()
        {
            return Row;
        }

        public int GetColumn()
        {
            return Column;
        }
        #endregion
    }
}
