using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : Matrix
{
    bool rowSame = false;
    bool columnSame = false;
    bool diagonalSame = false;
    bool inversediagonalSame = false;
    bool checkWin = false;
    bool matrixValue = false;
    bool matchDraw = false;

    List<List<Cell>> CellGrid = new List<List<Cell>>();
    Cell.Status currentturn = Cell.Status.Cross;

    public delegate void OnCellCreated(Cell cell);
    public event OnCellCreated onCellCreated;

    public delegate void OnCellsDone();
    public event OnCellsDone onCellsDone;

    public TicTacToeGrid(int numberofrows, int numberofcolumns) : base(numberofrows, numberofcolumns)
    {

    }
    public void InitializeCells()
    {
        for (int i = 0; i < numberofrows; i++)
        {
            CellGrid.Add(new List<Cell>());
            for (int j = 0; j < numberofcolumns; j++)
            {
                Cell cell = new Cell(i, j);
                CellGrid[i].Add(cell);
                onCellCreated?.Invoke(cell);
                cell.rowcol += SetStatusTurn;
            }
        }
        onCellsDone?.Invoke();
    }
    public void SetStatusTurn(int row, int col)
    {
        if (CellGrid[row][col].GetStatus() == Cell.Status.None)
        {
            TakeTurn(row, col);
            CellGrid[row][col].SetStatus(currentturn);
            //CheckWin();
            //CheckDraw();
        }

    }
    //public override void onMatrixUpdate()
    //{
    //    for (int i = 0; i < numberofrows; i++)
    //    {
    //        for (int j = 0; j < numberofcolumns; j++)
    //        {
    //            CellGrid[i][j].SetStatus((Cell.Status)GetElement(i, j));
    //        }

    //    }
    //}

    public void TakeTurn(int row, int col)
    {
        ChangeTurn();
    }
    public void ChangeTurn()
    {
        if (currentturn == Cell.Status.Cross)
        {
            currentturn = Cell.Status.Circle;
        }
        else
        {
            currentturn = Cell.Status.Cross;
        }
    }
    public void CheckWin()
    {
        for (int i = 0; i < base.numberofrows; i++)
        {
            rowSame = IsRowSame(i);
            if (rowSame == true)
            {
                checkWin = true;
                break;
            }
            else
            {
                checkWin = false;
            }
        
        }   
        if (!checkWin)
        {
           for (int i = 0; i < base.numberofcolumns; i++)
           {
              columnSame = IsColSame(i);
              if (columnSame)
              {
                checkWin = true;
                break;
              }
              else
              {
                checkWin = false;
              }
           }
        }
        else if (!checkWin && !columnSame)
        {
           diagonalSame = IsDiagonalSame();
           if (diagonalSame)
        {
            checkWin = true;
        }
            else 
            checkWin = false;
        }
        else if (!checkWin && !columnSame && !diagonalSame)
        {
        inversediagonalSame = IsInverseDiagonalSame();
        if (inversediagonalSame)
        {
            checkWin = true;
        }
        else
            checkWin = false;
        }
    }
    public void CheckDraw()
    {
         MatrixCheck();
         if (!matrixValue)
         {
        Debug.Log("Game not end");
         }
        else
        {
        Debug.Log("Draw");
        matchDraw = true;
        }
    }
    public void MatrixCheck()
    {
        for (int i = 0; i < base.numberofrows; i++)
        {
           for (int j = 0; j < base.numberofcolumns; j++)
           {
              if (MatrixData[i][j] == 0)
              {
                matrixValue = false;
                break;
              }
              else
                matrixValue = true;
           }
        }
    }
}



