using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GOL.Interfaces;
using GOL.Models;
using System.ComponentModel;
using System.Timers;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGameEngine gameWorld;
        private List<Node> nodes;
        private BackgroundWorker backgroundWorker;        

        /// <summary>
        /// Run the app
        /// </summary>
        public MainWindow()
        {
            // Load up all of our models
            IoCAssembler iocAssembler = new IoCAssembler();
            gameWorld = iocAssembler.Create<IGameEngine>();
            gameWorld.LoadGameWorld("Toad");

            // Initalize the GUI
            InitializeComponent();

            // Setup our background worker thread
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(this.backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);

            DispatcherTimer dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += this.dispatcher_Tick;

            dispatcherTimer.Start();
            
        }

        public void dispatcher_Tick(Object sender, EventArgs args)
        {
            backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Request Update the game world
        /// </summary>
        public void backgroundWorker_DoWork(Object sender, DoWorkEventArgs args)
        {            
            this.gameWorld.UpdateGameWorld();
        }
        
        /// <summary>
        /// Update the UI with the new world state
        /// </summary>
        public void backgroundWorker_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs args)
        {
            Canvas canvasPanel = new Canvas();
            canvasPanel.Height = 480;
            canvasPanel.Width = 780;
            
            canvasPanel.Background = new SolidColorBrush(Colors.LightCyan);
            
            this.nodes = this.gameWorld.GetGameWorldState();
            
            // Gets our XY coords for scaling
            int maxX = nodes.Select(n => n.X).Max();
            int maxY = nodes.Select(n => n.Y).Max();

            int minX = nodes.Select(n => n.X).Min();
            int minY = nodes.Select(n => n.X).Min();

            int nodeWidth = 20;
            foreach (Node node in this.nodes)
            {
                Rectangle nodeRectangle = new Rectangle();
                nodeRectangle.Width = nodeWidth;
                nodeRectangle.Height = nodeWidth;
                nodeRectangle.Fill = new SolidColorBrush(Colors.Black);

                // Set Canvas position
                Canvas.SetLeft(nodeRectangle, (node.X * nodeWidth) + nodeWidth);
                Canvas.SetTop(nodeRectangle, (node.Y * nodeWidth) + nodeWidth);

                // Add Rectangle to Canvas
                canvasPanel.Children.Add(nodeRectangle);
            }

            // Set Canvas as content of the Window            
            this.Content = canvasPanel;
        }
    }
}
