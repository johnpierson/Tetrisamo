using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Dynamo.Graph.Nodes;
using Dynamo.ViewModels;
using Dynamo.Wpf.Extensions;

namespace Tetrisamo
{
    class TetrisamoViewModel
    {
        private static ViewLoadedParams loadedParams;
        private static DynamoViewModel _vm;
        private static int _flag;
        public TetrisamoViewModel(ViewLoadedParams p)
        {
            loadedParams = p;
            _vm = loadedParams.DynamoWindow.DataContext as DynamoViewModel;
        }

        public static void SubscribeNodePlaced()
        {
            loadedParams.CurrentWorkspaceModel.NodeAdded += CurrentWorkspaceModelOnNodeAdded;

        }
        public static void UnsubscribeNodePlaced()
        {
            loadedParams.CurrentWorkspaceModel.NodeAdded -= CurrentWorkspaceModelOnNodeAdded;
        }

        private static void CurrentWorkspaceModelOnNodeAdded(NodeModel obj)
        {
            if (_flag > Frequency().Count())
            {
                _flag = 0;
            }

            BackgroundBeep.Beep();
            _flag++;
        }
        // LOL there is probably a better way to do this.
        private static List<Point> Frequency()
        {
            List<Point> list1 = new List<Point>()
            {
                new Point(658, 125),
                new Point(1320, 500),
                new Point(990, 250),
                new Point(1056, 250),
                new Point(1188, 250),
                new Point(1320, 125),
                new Point(1188, 125),
                new Point(1056, 250),
                new Point(990, 250),
                new Point(880, 500),
                new Point(880, 250),
                new Point(1056, 250),
                new Point(1320, 500),
                new Point(1188, 250),
                new Point(1056, 250),
                new Point(990, 750),
                new Point(1056, 250),
                new Point(1188, 500),
                new Point(1320, 500),
                new Point(1056, 500),
                new Point(880, 500),
                new Point(880, 500),
                new Point(1188, 500),
                new Point(1408, 250),
                new Point(1760, 500),
                new Point(1584, 250),
                new Point(1408, 250),
                new Point(1320, 750),
                new Point(1056, 250),
                new Point(1320, 500),
                new Point(1188, 250),
                new Point(1056, 250),
                new Point(990, 500),
                new Point(990, 250),
                new Point(1056, 250),
                new Point(1188, 500),
                new Point(1320, 500),
                new Point(1056, 500),
                new Point(880, 500),
                new Point(880, 500),
                new Point(1320, 500),
                new Point(990, 250),
                new Point(1056, 250),
                new Point(1188, 250),
                new Point(1320, 125),
                new Point(1188, 125),
                new Point(1056, 250),
                new Point(990, 250),
                new Point(880, 500),
                new Point(880, 250),
                new Point(1056, 250),
                new Point(1320, 500),
                new Point(1188, 250),
                new Point(1056, 250),
                new Point(990, 750),
                new Point(1056, 250),
                new Point(1188, 500),
                new Point(1320, 500),
                new Point(1056, 500),
                new Point(880, 500),
                new Point(880, 500),
                new Point(1188, 500),
                new Point(1408, 250),
                new Point(1760, 500),
                new Point(1584, 250),
                new Point(1408, 250),
                new Point(1320, 750),
                new Point(1056, 250),
                new Point(1320, 500),
                new Point(1188, 250),
                new Point(1056, 250),
                new Point(990, 500),
                new Point(990, 250),
                new Point(1056, 250),
                new Point(1188, 500),
                new Point(1320, 500),
                new Point(1056, 500),
                new Point(880, 500),
                new Point(880, 500),
                new Point(660, 1000),
                new Point(528, 1000),
                new Point(594, 1000),
                new Point(495, 1000),
                new Point(528, 1000),
                new Point(440, 1000),
                new Point(419, 1000),
                new Point(495, 1000),
                new Point(660, 1000),
                new Point(528, 1000),
                new Point(594, 1000),
                new Point(495, 1000),
                new Point(528, 500),
                new Point(660, 500),
                new Point(880, 1000),
                new Point(838, 2000),
                new Point(660, 1000),
                new Point(528, 1000),
                new Point(594, 1000),
                new Point(495, 1000),
                new Point(528, 1000),
                new Point(440, 1000),
                new Point(419, 1000),
                new Point(495, 1000),
                new Point(660, 1000),
                new Point(528, 1000),
                new Point(594, 1000),
                new Point(495, 1000),
                new Point(528, 500),
                new Point(660, 500),
                new Point(880, 1000),
                new Point(838, 2000)
            };
            return list1;
        }
        // Dedicate a thread to the beep 😎 This helps with some of the resources being slowed in Dynamo.
        // info here https://stackoverflow.com/questions/2751686/how-can-i-execute-a-non-blocking-system-beep
        class BackgroundBeep
        {
            static Thread _beepThread;
            static AutoResetEvent _signalBeep;

            static BackgroundBeep()
            {
                _signalBeep = new AutoResetEvent(false);
                _beepThread = new Thread(() =>
                {
                    for (; ; )
                    {
                        _signalBeep.WaitOne();
                        Console.Beep((int)Frequency()[_flag].X, (int)Frequency()[_flag].Y);
                    }
                }, 1);
                _beepThread.IsBackground = true;
                _beepThread.Start();
            }

            public static void Beep()
            {
                _signalBeep.Set();
            }
        }
    }
}
