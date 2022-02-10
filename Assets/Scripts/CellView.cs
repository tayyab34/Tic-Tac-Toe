using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    public GameObject[] cube_status;
    Cell cell = new Cell();

    //public delegate void OnCellInteraction(int row, int col);
    //public event OnCellInteraction onCellInteraction;
    public void Start()
    {
 
    }

    public void SetStatus(Cell.Status status)
    {
        for (int i = 0; i < cube_status.Length; i++)
        {
            if (i == (int)status)
            {
                cube_status[i].SetActive(true);
            }
            else
            {
                cube_status[i].SetActive(false);
            }
        }
    }
    private void OnMouseDown()
    {
        cell.onStatusUpdate += SetStatus;
        //onCellInteraction?.Invoke(cell.GetRow(), cell.GetCol());
        cell.CellInteraction();
        
    }
    private void OnDestroy()
    {
        cell.onStatusUpdate -= SetStatus;
    }
    public void SetCell(Cell cell)
    {
        this.cell = cell;
    }

}
