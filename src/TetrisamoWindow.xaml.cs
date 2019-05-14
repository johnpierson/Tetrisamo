using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Dynamo.Graph.Nodes;
using Dynamo.ViewModels;
using Dynamo.Wpf.Extensions;

namespace Tetrisamo
{
    /// <summary>
    /// Interaction logic for TetrisamoWindow.xaml
    /// </summary>
    public partial class TetrisamoWindow : Window
    {


        public TetrisamoWindow()
        {
            InitializeComponent();
            TetrisamoViewModel.SubscribeNodePlaced();
            this.Closing += OnClosing;
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            TetrisamoViewModel.UnsubscribeNodePlaced();
        }
  
    }
}
