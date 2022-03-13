using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    private int row;
    private int col;
    public Status status;

    public delegate void OnStatusUpdate(Status status);
    public event OnStatusUpdate onStatusUpdate;

    public delegate void RowandCol(int row, int col);
    public event RowandCol rowcol;

    public enum Status { None, Cross, Circle, Win, Lose }

    public Cell()
    {
        row = 0;
        col = 0;
        this.status = Status.None;
    }
    public Cell(int row, int col)
    {
        this.row = row;
        this.col = col;
        this.status = Status.None;
    }
    public Cell(int row, int col, Status status)
    {
        this.row = row;
        this.col = col;
        this.status = status;
    }
    public void CellInteraction()
    {
        rowcol?.Invoke(row, col);
    }
    public void SetStatus(Status status)
    {
        this.status = status;
        onStatusUpdate?.Invoke(status);
    }
    public Status GetStatus()
    {
        return status;
    }
    public void SetRow(int row)
    {
        this.row = row;
    }
    public void SetCol(int col)
    {
        this.col = col;
    }
    public int GetRow()
    {
        return row;
    }
    public int GetCol()
    {
        return col;
    }
}
