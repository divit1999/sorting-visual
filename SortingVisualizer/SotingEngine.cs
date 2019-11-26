using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer
{
    class SotingEngine : BubbleSort
    {
        private bool _sorted = false;
        private int[] TheArray;
        private Graphics g;
        private int MaxVal;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);


        public void DoWork(int[] Array_In, Graphics g_In, int MaxValue_In)
        {
            TheArray = Array_In;
            g = g_In;
            MaxVal = MaxValue_In;
          
                for (int i = 0; i < TheArray.Count() - 1; i++)
                {
                    for (int j = 0; j < TheArray.Count() - 1 - i; j++)
                    {
                        if (TheArray[j] > TheArray[j + 1])
                        {
                        int temp = TheArray[i];
                        TheArray[i] = TheArray[i + 1];
                        TheArray[i + 1] = temp;

                        g.FillRectangle(BlackBrush, i, 0, 2, MaxVal);
                        // g.FillRectangle(BlackBrush, v, 0, 1, MaxVal);


                        g.FillRectangle(WhiteBrush, i, MaxVal - TheArray[i], 1, MaxVal);
                        g.FillRectangle(WhiteBrush, i+1, MaxVal - TheArray[i+1], 1, MaxVal);
                    }
                    }
                }
               // _sorted = true;
              //  _sorted = IsSorted();
           
           
        }

       /* private void Swap(int i, int v)
        {
            int temp = TheArray[i];
            TheArray[i] = TheArray[i + 1];
            TheArray[i+1] = temp;

            g.FillRectangle(BlackBrush, i, 0, 2, MaxVal);
           // g.FillRectangle(BlackBrush, v, 0, 1, MaxVal);


            g.FillRectangle(WhiteBrush, i, MaxVal - TheArray[i], 1, MaxVal);
            g.FillRectangle(WhiteBrush, v, MaxVal - TheArray[v], 1, MaxVal);


        }

       /* private bool IsSorted()
        {
            for(int i=0;i< TheArray.Count() - 1; i++)
            {
                if (TheArray[i] > TheArray[i + 1]) return false;
            }
            return true; 
        }*/
    }
}
