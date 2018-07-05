using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Assets.Scripts
{
    public struct PointD
    {
        public double X;
        public double Y;
        public string Name;

        public PointD(double x, double y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }
    }

    class Distance
    {
        Double[,] distances;

        Distance(int widht, int height)
        {
            distances = new Double[widht, height];
        }

        public void InputMatrix(PointD[] matrix1, PointD[] matrix2)
        {
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(0); j++)
                {
                    if(i == j)
                    {
                        distances[i, j] = -1;
                    } else
                    {
                        if(ExistDistance(i,j))
                        {
                            distances[i, j] = -1;
                        } else
                        {
                            distances[i, j] = CalculateDistance(matrix1[i].X, matrix1[i].Y, matrix2[i].X, matrix2[i].Y);
                        }
                    }
                    
                }
            }
        }

        private Double CalculateDistance(Double x1, Double y1, Double x2, Double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        private bool ExistDistance(int index1, int index2)
        {

            return distances[index2,index1] != -1? true : false;
        }

        public Double GetDistance(int index1, int index2)
        {
            if(distances[index1, index2] == -1)
            {
                return distances[index2, index1] != -1 ? distances[index2, index1] : -1;
            }
            return distances[index1, index2];
        }

        //public List<PointD> GetListMinorsByIndex(int index, int size)
        //{
        //    if (size < 1 || index < 0)
        //        return null;
        //    Double[] distances _
        //    for(int i = 0; i < distances.GetLength(0) ; i ++)
        //    {

        //    }
        //    Array.Sort(distances[, index]);
           
        //}

    }
}
