using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TDDBlackJack;

namespace BlackJackGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public Game _game;
        private Thread _thread;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HeartBeat()
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)DoWork);
            HeartBeat();
        }

        private void DoWork()
        {
            _game = new Game(new List<Player> { new Player("Shannon", 1.00) });
            _game.Start();
            messages.Text = "Beep " + DateTime.UtcNow.Ticks;
        }

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            StartHeartBeat();
            ToggleButtons(StartGame,EndGame);
        }

        private static void ToggleButtons(Button button1, Button button2)
        {
            button1.IsEnabled = !button1.IsEnabled;
            button2.IsEnabled = !button2.IsEnabled;
        }

        private void StartHeartBeat()
        {
            _thread = new Thread(HeartBeat);
            _thread.Start();
        }

        private void StopHeartBeat()
        {
            _thread.Abort();
        }

        private void EndGameClick(object sender, RoutedEventArgs e)
        {
            StopHeartBeat();
            ToggleButtons(StartGame, EndGame);
        }
    }
}
