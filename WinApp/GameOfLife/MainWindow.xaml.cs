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
using GameOfLife.Infrastructure;
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
        private IGameEngine gameEngine;
        private List<Node> nodes;
        private BackgroundWorker backgroundWorker;        

        /// <summary>
        /// Run the app
        /// </summary>
        public MainWindow()
        {
            // Load up all of our models
            IoCAssembler iocAssembler = new IoCAssembler();
            gameEngine = iocAssembler.Create<IGameEngine>();
            gameEngine.LoadGameWorld("Toad");

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
            this.gameEngine.UpdateGameWorld();
        }
        
        /// <summary>
        /// Update the UI with the new world state
        /// </summary>
        public void backgroundWorker_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs args)
        {
            StackPanel stackPanel = new StackPanel();
            this.Content = stackPanel;
            stackPanel.Margin = new Thickness(0, 0, 0, 0);
            stackPanel.Background = new SolidColorBrush(Colors.White);
            stackPanel.Orientation = Orientation.Vertical;

            // Animated canvas
            Canvas canvasPanel = new Canvas();
            canvasPanel.Margin = new Thickness(0, 0, 0, 0);
            canvasPanel.Height = 200;
                        
            this.nodes = this.gameEngine.GetGameWorldState();                      

            // Default node with
            int nodeWidth = 20;

            // Two hacky variables because we're not doing auto scaling
            int prettifyX = 160;
            int prettifyY = 40;
            
            SolidColorBrush blackBrush = new SolidColorBrush(Colors.Black);
            SolidColorBrush whiteBrush = new SolidColorBrush(Colors.White);
            
            foreach (Node node in this.nodes)
            {
                // Create the node obect
                Rectangle nodeRectangle = new Rectangle();
                nodeRectangle.Width = nodeWidth;
                nodeRectangle.Height = nodeWidth;
                nodeRectangle.Fill = blackBrush;
                nodeRectangle.Margin = new Thickness(1, 1, 1, 1);
                nodeRectangle.Stroke = whiteBrush;

                // Set Canvas position
                Canvas.SetLeft(nodeRectangle, (node.X * nodeWidth) + prettifyX);
                Canvas.SetTop(nodeRectangle, (node.Y * nodeWidth) + prettifyY);

                // Add Rectangle to Canvas
                canvasPanel.Children.Add(nodeRectangle);
            }

            stackPanel.Children.Add(canvasPanel);

            //add the buttons for the different forms.
            StackPanel buttonPanel = new StackPanel();
            buttonPanel.Margin = new Thickness(0, 0, 0, 0);
            buttonPanel.Background = new SolidColorBrush(Colors.White);
            buttonPanel.Orientation = Orientation.Vertical;

            // Leaving per loop load as we could dynamically alter the list
            foreach (string savedModel in this.gameEngine.GetWorldDescriptions())
            {
                Button button = new Button();
                button.Content = "Load " + savedModel;
                button.Margin = new Thickness(0, 0, 0, 0);
                button.Click += button_click;
                if (savedModel.Equals(this.gameEngine.GetCurrentWorldDescription()))
                {
                    button.IsEnabled = false;
                }

                buttonPanel.Children.Add(button);
            }

            stackPanel.Children.Add(buttonPanel);
        }

        /// <summary>
        /// Change the gameworld to the supplied button
        /// </summary>
        private void button_click(Object sender, EventArgs args)
        {
            Button clickedButton = (Button)sender;
            string loadStr = "Load ";
            string content = clickedButton.Content.ToString();            
            string nextPattern = content.Substring(loadStr.Length, content.Length - loadStr.Length);
                
            this.gameEngine.LoadGameWorld(nextPattern);
        }
    }
}
