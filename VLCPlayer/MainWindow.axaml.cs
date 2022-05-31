using Avalonia.Controls;
using LibVLCSharp.Avalonia;
using LibVLCSharp.Shared;
using System;

namespace VLCPlayer
{
    public partial class MainWindow : Window
    {
        private VideoView? _videoViewer;
        MediaPlayer MediaPlayer;
        LibVLC _libVlc = new LibVLC();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnOpened(object sender, EventArgs e)
        {
            
            MediaPlayer = new MediaPlayer(_libVlc);
            VideoViewer.MediaPlayer = MediaPlayer;
            MediaPlayer.Scale = 0;
            MediaPlayer.AspectRatio = $"{VideoViewer.Bounds.Width}:{VideoViewer.Bounds.Height}";
            using var media = new Media(_libVlc, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            MediaPlayer.Play(media);

        }

        public void FormClosing() {
            MediaPlayer?.Dispose();
            _libVlc?.Dispose();
        }
        
    }
}
