using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    protected int numberofrows;
    protected int numberofcolumns;
    protected List<List<float>> MatrixData;
    void Start()
    {

    }
    void Update()
    {

    }
    void InitalizeList()
    {
        MatrixData = new List<List<float>>();
    }
    public Matrix()
    {
        InitalizeList();
    }
    public Matrix(int rows, int columns)
    {
        numberofrows = rows;
        numberofcolumns = columns;
        InitalizeList();
        for (int i = 0; i < rows; i++)
        {
            MatrixData.Add(new List<float>());
            for (int j = 0; j < columns; j++)
            {
                MatrixData[i].Add(0);
            }
        }
        onMatrixUpdate();
    }
    public void SetMatrix(float[,] arr2D)
    {
        InitalizeList();
        numberofrows = arr2D.GetLength(0);
        numberofcolumns = arr2D.GetLength(1);
        for (int i = 0; i < numberofrows; i++)
        {
            MatrixData.Add(new List<float>());
            for (int j = 0; j < numberofcolumns; j++)
            {
                MatrixData[i].Add(arr2D[numberofrows, numberofcolumns]);
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
        InitalizeList();
        string display = "";
        for (int i = 0; i < numberofrows; i++)
        {
            MatrixData.Add(new List<float>());
            for (int j = 0; j < numberofcolumns; j++)
            {
                display += MatrixData[numberofrows][numberofcolumns] + " ";
            }
            display += '\n';
        }
        Debug.Log(display);
    }
    public void SetElement(int r, int c, float value)
    {
        if (r < numberofrows && c < numberofcolumns)
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
        if (r < numberofrows && c < numberofcolumns)
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
        if (arr.Length == numberofrows && rowNum < numberofrows)
        {
            for (int i = 0; i < numberofrows; i++)
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
        if (arr.Length == numberofcolumns && ColNum < numberofcolumns)
        {
            for (int i = 0; i < numberofcolumns; i++)
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
        if (r1 < numberofrows && r2 < numberofrows)
        {
            for (int i = 0; i < numberofrows; i++)
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
        if (c1 < numberofcolumns && c2 < numberofcolumns)
        {
            for (int i = 0; i < numberofrows; i++)
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
        if (numberofrows == toAdd.numberofrows && numberofcolumns == toAdd.numberofcolumns)
        {
            Matrix AddedMatrix = new Matrix(numberofrows, numberofcolumns);
            for (int i = 0; i < numberofrows; i++)
            {
                for (int j = 0; j < numberofcolumns; j++)
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
        if (numberofrows == toSubtract.numberofrows && numberofcolumns == toSubtract.numberofcolumns)
        {
            Matrix SubtractedMatrix = new Matrix(numberofrows, numberofcolumns);
            for (int i = 0; i < numberofrows; i++)
            {
                for (int j = 0; j < numberofcolumns; j++)
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
        if (rowNum < numberofrows)
        {
            float[] Array = new float[rowNum];
            for (int i = 0; i < numberofrows; i++)
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
        if (colNum < numberofcolumns)
        {
            float[] Array = new float[colNum];
            for (int i = 0; i < numberofcolumns; i++)
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
        Matrix MultipliedMatrix = new Matrix(numberofrows, numberofcolumns);

            for (int i = 0; i < numberofrows; i++)
            {
                for (int j = 0; j < toMultiply.numberofcolumns; j++)
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
        InitalizeList();
        for (int i = 0; i < numberofrows; i++)
        {
            MatrixData.Add(new List<float>());
            for (int j = 0; j < numberofcolumns; j++)
            {
                MatrixData[i].Add(num);
            }
        }
        onMatrixUpdate();
    }
    public void SetRow(int rowNum,int num)
    {
        if (rowNum < numberofrows)
        {
            for (int i = 0; i < numberofrows; i++)
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
        if (ColNum < numberofcolumns)
        {
            for (int i = 0; i < numberofcolumns; i++)
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
        InitalizeList();
        for (int i = 0; i < numberofrows; i++)
        {
            MatrixData.Add(new List<float>());
            for (int j = i; j <=i; j++)
            {
                MatrixData[i][j] = num;
            }
            onMatrixUpdate();
        }
    }
    public void SetInverseDiagonal(int num)
    {
        InitalizeList();
        for (int i = 0; i < numberofrows; i++)
        {
            MatrixData.Add(new List<float>());
            for (int j =numberofcolumns-i-1; j >= numberofcolumns-i-1; j--)
            {
                MatrixData[i][j] = num;
            }
        }
        onMatrixUpdate();
    }
    public bool IsRowSame(int rowNum)
    {
        bool isrowsame = true;
        for (int i= 0; i < numberofrows; i++)
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
        for (int i = 0; i < numberofcolumns; i++)
        {
            if (MatrixData[i][ColNum] != MatrixData[ColNum][i + 1])
            {
                iscolsame = false;
            }
        }
        return iscolsame;
    }
    public bool IsDiagonalSame()
    {
        bool isdiagonalsame =true;
        InitalizeList();
        for (int i = 0; i < numberofrows; i++)
        {
            MatrixData.Add(new List<float>());
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
        InitalizeList();
        for (int i = 0; i < numberofrows; i++)
        {
            MatrixData.Add(new List<float>());
            for (int j = numberofcolumns - i - 1; j >= numberofcolumns - i - 1; j--)
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
