using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Dynamo.Controls;
using Dynamo.Wpf.Extensions;

namespace Tetrisamo
{
    public class TetrisamoViewExtension : IViewExtension
    {
        private MenuItem tetrisamoMenuItem;
        public void Dispose()
        {
        }

        public static DynamoView view;

        public void Startup(ViewStartupParams p)
        {
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            //player.SoundLocation = "C:\\Users\\johnpierson\\Downloads\\ClassicSounds\\dialup.wav";
            //player.Play();

        }

        public void Loaded(ViewLoadedParams p)
        {
            // Save a reference to your loaded parameters.
            // You'll need these later when you want to use
            // the supplied workspaces

            view = p.DynamoWindow as DynamoView;

            tetrisamoMenuItem = new MenuItem { Header = "Tetrisamo" };


            //tetrisamoMenuItem.Icon = new System.Windows.Controls.Image
            //{
            //    Source = new BitmapImage(new Uri("pack://application:,,,/DynaThanosViewExtension;component/Resources/thanosEmoji.png"))
            //};

            tetrisamoMenuItem.Click += (sender, args) =>
            {
                var viewModel = new TetrisamoViewModel(p);
                var window = new TetrisamoWindow
                {
                    // Set the data context for the main grid in the window.
                    MainGrid = { DataContext = viewModel },

                    // Set the owner of the window to the Dynamo window.
                    Owner = p.DynamoWindow
                };

                window.Left = window.Owner.Left + 400;
                window.Top = window.Owner.Top + 200;

                // Show a modeless window.
                window.Show();
            };
            p.AddMenuItem(MenuBarType.View, tetrisamoMenuItem, 0);
        }

        public void Shutdown()
        {
        }

        public string UniqueId => "9092B99E-F41B-41BC-B1B7-B2749679FE3D";

        public string Name
        {
            get
            {
                return "Tetrisamo";
            }
        }
    }
}
