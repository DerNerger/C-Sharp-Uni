using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeapSort
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IComparable[] arr = new CompareableInteger[7];
            arr[0] = new CompareableInteger(22);
            arr[1] = new CompareableInteger(18);
            arr[2] = new CompareableInteger(19);
            arr[3] = new CompareableInteger(5);
            arr[4] = new CompareableInteger(8);
            arr[5] = new CompareableInteger(13);
            arr[6] = new CompareableInteger(33);

            Heap h = new Heap(arr);
            h.heapSort();
            h.showHeap();
        }
    }
}
