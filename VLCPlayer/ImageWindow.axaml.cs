using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.IO;
using AvaloniaGif;

namespace VLCPlayer
{
    public partial class ImageWindow : Window
    {
        public ImageWindow()
        {
            InitializeComponent();

            var imgStream = File.OpenRead(Environment.CurrentDirectory + "//1.gif");

            GifImage imgGIF = this.Get<GifImage>("imgGIF");
            imgGIF.SourceStream = imgStream;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
