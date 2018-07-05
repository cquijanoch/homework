using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct PointD
{
    public double X;
    public double Y;
    public double Z;
    public string Name;


    public PointD(double x, double y, double z, string name)
    {
        X = x;
        Y = y;
        Z = z;
        Name = name;
    }
}

class Distance
{
    Double[,] distances;
    private int width, heigth;


    public Distance(int width, int heigth)
    {
        this.width = width;
        this.heigth = heigth;
        distances = new Double[width, heigth + 2];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < heigth + 2; j++)
            {
                distances[i, j] = -1;
            }
        }
    }

    public void InputMatrix(PointD[] matrix1, PointD[] matrix2)
    {
        
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            Double indexMin = 1000;
            Double indexMax = -1;
            for (int j = 0; j < matrix2.GetLength(0); j++)
            {
                if (i == j)
                {
                    distances[i, j] = -1;
                }
                else
                {
                    if (ExistDistance(i, j))
                    {
                        distances[i, j] = -1;
                    }
                    else
                    {
                        double dist = CalculateDistance(matrix1[i].X, matrix1[i].Y, matrix1[i].Z, matrix2[j].X, matrix2[j].Y, matrix2[j].Z);
                        distances[i, j] = dist;
                        if (distances[i, j] > indexMax)
                        {
                            indexMax = distances[i, j];
                            distances[i,width] = j;
                        }
                        if (distances[i, j] < indexMin)
                        {
                            indexMin = distances[i, j];
                            distances[i , width + 1] = j;
                        }
                    }
                }

            }
        }
    }

    private Double CalculateDistance(Double x1, Double y1, Double z1, Double x2, Double y2, Double z2)
    {
        return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2));
    }

    private bool ExistDistance(int index1, int index2)
    {

        return distances[index2, index1] != -1 ? true : false;
    }

    public Double GetDistance(int index1, int index2)
    {
        if (distances[index1, index2] == -1)
        {
            return distances[index2, index1] != -1 ? distances[index2, index1] : -1;
        }
        return distances[index1, index2];
    }


    public int GetMinByIndex(int index)
    {
        return (int)distances[index, width + 1];
    }

    public int GetMaxByIndex(int index)
    {
        return (int)distances[index, width];
    }


    //public List<PointD> GetListMinorsByIndex(int index, int size)
    //{
    //    if (size < 1 || index < 0)
    //        return null;
    //    Double[] distances _
    //        for (int i = 0; i < distances.GetLength(0); i++)
    //    {

    //    }
    //    Array.Sort(distances[, index]);

    //}

}

