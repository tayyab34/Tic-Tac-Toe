using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGrid : Matrix
{
    List<List<Cell>> CellGrid = new List<List<Cell>>();
    Cell.Status currentturn = Cell.Status.Cross;

    public delegate void OnCellCreated(Cell cell);
    public event OnCellCreated onCellCreated;

    public delegate void OnCellsDone();
    public event OnCellsDone onCellsDone;

    public TicTacToeGrid(int row, int col) : base(row, col)
    {

    }
    public void InitializeCells(int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            CellGrid.Add(new List<Cell>());
            for (int j = 0; j < col; j++)
            {
                Cell cell = new Cell(i, j);
                CellGrid[i].Add(cell);
                onCellCreated?.Invoke(CellGrid[i][j]);
                CellGrid[i][j].rowcol += SetStatusTurn;
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
            SetElement(row, col, (int)currentturn);
            CheckWin(row, col);
        }
        
    }
    public override void onMatrixUpdate()
    {
        for (int i = 0; i < numofrows; i++)
        {
            for (int j = 0; j < numofcolumns; j++)
            {
                CellGrid[i][j].SetStatus((Cell.Status)GetElement(i , j));
            }
        }
    }

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
  
    private void CheckWin(int row, int col)
    {
        CheckRow(row);
        CheckCol(col);
        if (row == col)
            CheckDiagonal();
        if (row == CellGrid.Count - 1 - col)
            CheckInverseDiagonal();
    }

    private void CheckInverseDiagonal()
    {
        if (IsInverseDiagonalSame())
        { 
            SetInverseDiagonal((int)Cell.Status.Win);
        }
    }

    private void CheckDiagonal()
    {
        if (IsDiagonalSame())
        {
            SetDiagonal((int)Cell.Status.Win);
        }
    }

    private void CheckCol(int col)
    {
        if (IsColSame(col))
        {
            SetCol(col, (int)Cell.Status.Win);
        }
    }

    private void CheckRow(int row)
    {
        if (IsRowSame(row))
        {
            SetRow(row, (int)Cell.Status.Win);
        }
    }
}






