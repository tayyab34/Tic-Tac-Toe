using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    protected int numofrows;
    protected int numofcolumns;
    protected int rowsize;
    protected int colsize;
    protected List<List<float>> MatrixData;

    void InitalizeMatrix()
    {
        MatrixData = new List<List<float>>();
    }
    public Matrix()
    {
        InitalizeMatrix();
    }
    public Matrix(int rows, int columns)
    {
        numofrows = rows;
        numofcolumns = columns;
        rowsize = numofcolumns;
        colsize = numofrows;
        InitalizeMatrix();
        for (int i = 0; i < rows; i++)
        {
            MatrixData.Add(new List<float>());
            for (int j = 0; j < columns; j++)
            {
                MatrixData[i].Add(0);
            }
        }
       // onMatrixUpdate();
    }
    public void SetMatrix(float[,] arr2D)
    {
        InitalizeMatrix();
        numofrows = arr2D.GetLength(0);
        numofcolumns = arr2D.GetLength(1);
        rowsize = numofcolumns;
        colsize = numofrows;
        for (int i = 0; i < numofrows; i++)
        {
            MatrixData.Add(new List<float>());
            for (int j = 0; j < numofcolumns; j++)
            {
                MatrixData[i].Add(arr2D[i,j]);
            }
        }
        onMatrixUpdate();
    }
    public Matrix(float[,] arr2D)
    {
        SetMatrix(arr2D);
    }
    public void PrintMatrix()
    {
        string display = "";
        for (int i = 0; i < numofrows; i++)
        {
            for (int j = 0; j < numofcolumns; j++)
            {
                display += MatrixData[i][j] + " ";
            }
            display += '\n';
        }
        Debug.Log(display);
    }
    public void SetElement(int r, int c, float value)
    {

        if (r < numofrows && c < numofcolumns)
        {
            MatrixData[r][c] = value;
        }
        else
        {
            Debug.Log("Row or Col out of bound");
        }
        onMatrixUpdate();
    }
    public float GetElement(int r, int c)
    {
        if (r < numofrows && c < numofcolumns)
        {
            return MatrixData[r][c];
        }
        else
        {
            Debug.Log("Row or Col out of bound");
            return 0;
        }
    }
    public void SetRow(int rowNum, float[] arr)
    {
        if (arr.Length == rowsize && rowNum < numofrows)
        {
            for (int i = 0; i < rowsize; i++)
            {
                MatrixData[rowNum][i] = arr[i];
            }
        }
        else
        {
            Debug.Log("Row cannot be set");
        }
        onMatrixUpdate();
    }
    public void SetCol(int ColNum, float[] arr)
    {
        if (arr.Length == colsize && ColNum < numofcolumns)
        {
            for (int i = 0; i < colsize; i++)
            {
                MatrixData[i][ColNum] = arr[i];
            }
        }
        else
        {
            Debug.Log("Col cannot be set");
        }
    }
    public void SwapRows(int r1, int r2)
    {
        if (r1 < numofrows && r2 < numofrows)
        {
            for (int i = 0; i < rowsize; i++)
            {
                float temp = MatrixData[r1][i];
                MatrixData[r1][i] = MatrixData[r2][i];
                MatrixData[r2][i] = temp;
            }
        }
        else
        {
            Debug.Log("Swap not possible");
        }
        onMatrixUpdate();
    }
    public void SwapCol(int c1, int c2)
    {
        if (c1 < numofcolumns && c2 < numofcolumns)
        {
            for (int i = 0; i < colsize; i++)
            {
                float temp = MatrixData[i][c1];
                MatrixData[i][c1] = MatrixData[i][c2];
                MatrixData[i][c2] = temp;
            }
        }
        else
        {
            Debug.Log("Swap not possible");
        }
        onMatrixUpdate();
    }
    public Matrix Add(Matrix toAdd)
    {
        if (rowsize== toAdd.rowsize && colsize == toAdd.colsize)
        {
            Matrix AddedMatrix = new Matrix(rowsize,colsize);
            for (int i = 0; i < numofrows; i++)
            {
                for (int j = 0; j < numofcolumns; j++)
                {
                    AddedMatrix.SetElement(i, j, GetElement(i, j) + toAdd.GetElement(i, j));
                }
            }
            return AddedMatrix;
        }
        else
        {
            Debug.Log("Not Possible to Add");
            return null;
        }
    }
    public Matrix Subtract(Matrix toSubtract)
    {
        if (rowsize == toSubtract.rowsize && colsize == toSubtract.colsize)
        {
            Matrix SubtractedMatrix = new Matrix(rowsize,colsize);
            for (int i = 0; i < numofrows; i++)
            {
                for (int j = 0; j < numofcolumns; j++)
                {
                    SubtractedMatrix.SetElement(i, j, GetElement(i, j) - toSubtract.GetElement(i, j));
                }
            }
            return SubtractedMatrix;
        }
        else
        {
            Debug.Log("Not Possible to Subtract");
            return null;
        }
    }
    public float[] GetRow(int rowNum)
    {
        if (rowNum < rowsize)
        {
            float[] Array = new float[rowsize];
            for (int i = 0; i < numofrows; i++)
            {
                Array[i] = MatrixData[rowNum][i];
            }
            return Array;
        }
        else
        {
            Debug.Log("Row cannot be get");
            return null;
        }
        
    }
    public float[] GetCol(int colNum)
    {
        if (colNum < colsize)
        {
            float[] Array = new float[colsize];
            for (int i = 0; i < numofcolumns; i++)
            {
                Array[i] = MatrixData[i][colNum];
            }
            return Array;
        }
        else
        {
            Debug.Log("Col cannot be get");
            return null;
        }

    }
    public float AddArrayMultiples(float[] arr1,float[] arr2)
    {
        if (arr1.Length == arr2.Length)
        {
            float resultant = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                resultant += arr1[i] * arr2[i];
            }
            return resultant;
        }
        else
        {
            return 0;
        }
       
    }
    public Matrix Multiply(Matrix toMultiply)
    {
        Matrix MultipliedMatrix = new Matrix(rowsize,colsize);

            for (int i = 1; i < numofrows; i++)
            {
                for (int j = 1; j < toMultiply.numofcolumns; j++)
                {
                    MultipliedMatrix.SetElement(i, j, AddArrayMultiples(GetRow(i),toMultiply.GetCol(j)));
                }
            }
        return MultipliedMatrix;
    }
    public float Determinant()
    {
        float determinant;
        int i = 0;
        determinant = (MatrixData[i][i] * MatrixData[i+1][i+1]) - (MatrixData[i][i+1] * MatrixData[i+1][i]);  
        return determinant;
    }
    public void SetMatrix(int num)
    {
        InitalizeMatrix();
        for (int i = 0; i < numofrows; i++)
        {
            MatrixData.Add(new List<float>());
            for (int j = 0; j < numofcolumns; j++)
            {
                MatrixData[i].Add(num);
            }
        }
        onMatrixUpdate();
    }
    public void SetRow(int rowNum,int num)
    {
        if (rowNum < rowsize)
        {
            for (int i = 0; i < numofrows; i++)
            {
                MatrixData[rowNum][i] = num;
            }
        }
        else
        {
            Debug.Log("Row cannot be set");
        }
        onMatrixUpdate();
    }
    public void SetCol(int ColNum, int num)
    {
        if (ColNum < colsize)
        {
            for (int i = 0; i < numofcolumns; i++)
            {
                MatrixData[i][ColNum] = num;
            }
        }
        else
        {
            Debug.Log("Col cannot be set");
        }
        onMatrixUpdate();
    }
    public void SetDiagonal(int num)
    {
        for (int i = 0; i < numofrows; i++)
        {
            for (int j = i; j <=i; j++)
            {
                MatrixData[i][j] = num;
            }
            onMatrixUpdate();
        }
    }
    public void SetInverseDiagonal(int num)
    {
        for (int i = 0; i < numofrows; i++)
        {
            for (int j =numofcolumns-i-1; j >= numofcolumns-i-1; j--)
            {
                MatrixData[i][j] = num;
            }
        }
        onMatrixUpdate();
    }
    public bool IsRowSame(int rowNum)
    {
        bool isrowsame = true;
        for (int i= 0; i < numofrows-1; i++)
        {
            if (MatrixData[rowNum][i] != MatrixData[rowNum][i+1])
            {
                isrowsame = false;
            }          
        }
        return isrowsame;
    }
    public bool IsColSame(int ColNum)
    {
        bool iscolsame = true;
        for (int i = 0; i <numofcolumns-1; i++)
        {
            if (MatrixData[i][ColNum] != MatrixData[i+1][ColNum])
            {
                iscolsame = false;
            }
        }
        return iscolsame;
    }
    public bool IsDiagonalSame()
    {
        bool isdiagonalsame =true;
        for (int i = 0; i < numofrows-1; i++)
        {
            for (int j = i; j <= i; j++)
            {
                if(MatrixData[i][j] != MatrixData[i + 1][j + 1])
                {
                    isdiagonalsame = false;
                }
            }
        }
        return isdiagonalsame;
    }
    public bool IsInverseDiagonalSame()
    {
        bool isinversediagonalsame = true;
        for (int i = 0; i < numofrows-1; i++)
        {
            for (int j = numofcolumns - i - 1; j >= numofcolumns - i - 1; j--)
            {
                if(MatrixData[i][j] != MatrixData[i + 1][j-1])
                {
                    isinversediagonalsame = false;
                }
                
            }
        }
        return isinversediagonalsame;
    }
    public virtual void onMatrixUpdate()
    {

    }

}
