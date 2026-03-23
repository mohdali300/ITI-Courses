using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class GradeBook
    {
        double[] Grade { get; set; }
        int Size { get; set; }

        public GradeBook(int size)
        {
            Size = size;
            Grade = new double[size];
        }

        public double this[int index]
        {
            get 
            { 
                if(index>=0 && index<Size)
                    return Grade[index];
                else return -1;
            }
            set { Grade[index] = value; }
        }

        public void DisplayGrade()
        {
            for(int i=0; i<Size; i++)
            {
                Console.WriteLine($"Grade {i+1}: {Grade[i]}");
            }
        }
    }
}
