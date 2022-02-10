using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeView : MonoBehaviour
{
    public int row;
    public int col;
    public float horizontalspacing;
    public float verticalspacing;
    TicTacToeGrid Grid;
    public GameObject CellPrefab;
    List<GameObject> Cells = new List<GameObject>();
    private int CellCounter = 0;
    void Start()
    {
        //CellView cell =GetComponent<CellView>();
        InitializeGrid();
    }
    public void InitializeGrid()
    {
        Grid = new TicTacToeGrid(row, col);
        Grid.onCellCreated += OnCellCreated;
        Grid.onCellsDone += AlignGrid;
        Grid.InitializeCells();

    }
    public void OnCellCreated(Cell cell)
    {
        AlignGrid();
        Vector3 Position = new Vector3(horizontalspacing, 0, verticalspacing);
        GameObject cellview = Instantiate(CellPrefab,Position,CellPrefab.transform.rotation);
        //Cells.Add(cellview);
        cellview.GetComponent<CellView>().SetCell(cell);
        CellCounter++;


    }
    public void AlignGrid()
    {
        if (CellCounter == row)
        {
            horizontalspacing = 4;
            CellCounter = 0;
            verticalspacing += 4;
        }
        else
        {
            horizontalspacing += 4;
        }

    }

}
