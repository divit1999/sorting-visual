using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer
{
    public partial class Form1 : Form
    {
        int[] Array;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            int NumEntries = panel1.Width;
            int MaxVal = panel1.Height;
            Array = new int[NumEntries];
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Lavender), 0, 0, NumEntries, MaxVal);
            Random rand = new Random();
            for (int i = 0; i < NumEntries; i++)
            {
                Array[i] = rand.Next(5, MaxVal - 5);
            }
            for (int i = 0; i < NumEntries; i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Pink), i, MaxVal - Array[i], 1, Array[i]);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < Array.Count() - 1; i++)
            {
                for (int j = 0; j < Array.Count() - 1 - i; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        Swap(j, j + 1);

                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Array.Count(); i++)
            {
                int mini = panel1.Height, index = 0;
                for (int j = i; j < Array.Count(); j++)
                {

                    if (Array[j] < mini)
                    {
                        mini = Array[j];
                        index = j;
                    }
                }
                System.Threading.Thread.Sleep(5);
                Swap(i, index);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Pink);
            Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Lavender);
            for (int i = 1; i < Array.Count(); i++)
            {
                int val = Array[i];
                int j;
                for (j = i - 1; j >= 0 /*&& Array[j]>val*/; j--)
                {
                    if (Array[j] < val) break;
                    g.FillRectangle(BlackBrush, j, 0, 2, panel1.Height);
                    g.FillRectangle(WhiteBrush, j + 1, panel1.Height - Array[j], 1, panel1.Height);
                    Array[j + 1] = Array[j];
                }
                System.Threading.Thread.Sleep(1);
                g.FillRectangle(BlackBrush, j + 1, 0, 1, panel1.Height);
                g.FillRectangle(WhiteBrush, j + 1, panel1.Height - val, 1, panel1.Height);
                Array[j + 1] = val;

            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            MergeSort(0, panel1.Width-1);


        }
        private void MergeSort(int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(l, m);
                MergeSort(m + 1, r);
                System.Threading.Thread.Sleep(1);
                Merge(l, m, r);
            }
        }
        private void Merge(int left, int mid, int right)
        {
            int[] tempArray;
            tempArray=new int[right - left + 1];
            int pos = 0, lpos = left, rpos = mid + 1;
            while (lpos <= mid && rpos <= right)
            {
                if (Array[lpos] > Array[rpos])
                {
                    tempArray[pos++] = Array[rpos++];
                   
                }
                else
                {
                    tempArray[pos++] = Array[lpos++];

                }
            }
            while (lpos <= mid) tempArray[pos++] = Array[lpos++];
            while (rpos <= right) tempArray[pos++] = Array[rpos++];
            int iter;
           
            for (iter = 0; iter < pos; iter++)
            {
                Override(iter + left, tempArray[iter]);
               // System.Threading.Thread.Sleep(1);
                Array[iter + left] = tempArray[iter];
            }
          
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int n = panel1.Width;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = Array[i];
                    int j;
                    for (j = i; j >= gap && Array[j - gap] > temp; j -= gap)
                    {
                        Override(j, Array[j - gap]);
                        Array[j] = Array[j - gap];
                    }

                    Override(j, temp);
                    Array[j] = temp;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            QuickSort(0, panel1.Width-1);
        }

        private void QuickSort(int low, int high)
        {
            if (low < high)
            {

                int pi = Partition(low, high);

                QuickSort( low, pi - 1);
                QuickSort( pi + 1, high);
            }
        }
        private int Partition(int low, int high)
        {
            int pivot = Array[high];
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (Array[j] < pivot)
                {
                    i++;
                    Swap(i,j);
                }
            }
            Swap(i + 1, high);
            return (i + 1);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            CombSort(panel1.Width-1);
        }
        private void CombSort( int n)
        {
            int gap = n;
            bool swapped = true;
            while (gap != 1 || swapped == true)
            {
                gap = GetNextGap(gap);
                swapped = false;
                for (int i = 0; i < n - gap; i++)
                {
                    if (Array[i] > Array[i + gap])
                    {
                        Swap(i, i + gap);
                        swapped = true;
                    }
                }
            }
        }
        private int GetNextGap(int gap)
        {

            gap = (gap * 10) / 13;

            if (gap < 1)
                return 1;
            return gap;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            PancakeSort(panel1.Width);

        }
        private void PancakeSort(int n)
        {
            for (int curr_size = n; curr_size > 1; --curr_size)
            {
                int mi = FindMax(curr_size);
                if (mi != curr_size - 1)
                {
                    Flip(mi);
                    Flip(curr_size - 1);
                }
            }
        }
        private int FindMax(int n)
        {
            int mi, i;
            for (mi = 0, i = 0; i < n; ++i)
                if (Array[i] > Array[mi])
                    mi = i;
            return mi;
        }
        private void Flip(int i)
        {
            int temp, start = 0;
            while (start < i)
            {
                Swap(start, i);

                start++;
                i--;
            }
        }
        public void Override (int i, int val)
         {
            Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Pink);
            Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Lavender);
            g.FillRectangle(BlackBrush, i, 0, 1, panel1.Height);
            g.FillRectangle(WhiteBrush, i, panel1.Height - val, 1, panel1.Height);
        }
        private void Swap(int j, int v)
        {
            Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Pink);
            Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Lavender);
                 int temp = Array[j];
                Array[j] = Array[v];
                Array[v] = temp;

                g.FillRectangle(BlackBrush, j, 0, 1, panel1.Height);
                g.FillRectangle(BlackBrush, v, 0, 1, panel1.Height);
           
                g.FillRectangle(WhiteBrush, j, panel1.Height - Array[j], 1, panel1.Height);
                g.FillRectangle(WhiteBrush, v, panel1.Height - Array[v], 1, panel1.Height);
        }

      
    }
}

