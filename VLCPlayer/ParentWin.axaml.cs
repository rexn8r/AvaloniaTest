using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using System;

namespace VLCPlayer
{
    public partial class ParentWin : Window
    {
        MainWindow mw = new MainWindow();
        ImageWindow iw = new ImageWindow();
        Window _this;
        private bool m_Done = false;

        public ParentWin()
        {
            InitializeComponent();

            _this = this;

            
            //this.Show();
            this.Closing += ParentWin_Closing;
            
        }

        private void OnOpened(object? sender, System.EventArgs e)
        {
            _this.Width = 1366;
            _this.Height = 768;

            //_this.Width = Screens.Primary.Bounds.Width;
            //_this.Height = Screens.Primary.Bounds.Height;

            mw.Position = PixelPoint.FromPoint(new Point(0, 0), 0);
            mw.Width = this.Width / 2;
            mw.Height = this.Height / 2;
            mw.Show(_this);
            //mw.Topmost = true;
            //mw.Show();

            iw.Position = PixelPoint.FromPoint(new Point(0, 0), 0);
            iw.Width = this.Width / 2;
            iw.Height = this.Height / 2;
            iw.Show(_this);
        }

        private void ParentWin_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.FormClosing();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            //var iv = this.GetObservable(Window.IsVisibleProperty);
            //iv.Subscribe(new Action<bool>((value) =>
            //{
            //    if (value && !m_Done)
            //    {
            //        m_Done = true;
            //        CenterWindow();
            //    }

            //}));
        }

        private void CenterWindow()
        {
            if (OperatingSystem.IsWindows())
            { // Not needed for Windows
               // return;
            }

            double scale = PlatformImpl?.DesktopScaling ?? 1.0;
            IWindowBaseImpl powner = Owner?.PlatformImpl;
            if (powner != null)
            {
                scale = powner.DesktopScaling;
            }
            PixelRect rect = new PixelRect(PixelPoint.Origin,
               PixelSize.FromSize(ClientSize, scale));
            if (WindowStartupLocation == WindowStartupLocation.CenterScreen)
            {
                Screen screen = Screens.ScreenFromPoint(powner?.Position ?? Position);
                if (screen == null)
                {
                    return;
                }
                Position = screen.WorkingArea.CenterRect(rect).Position;
            }
            else
            {
                if (powner == null ||
                   WindowStartupLocation != WindowStartupLocation.CenterOwner)
                {
                    return;
                }
                Position = new PixelRect(powner.Position,
                   PixelSize.FromSize(powner.ClientSize, scale)).CenterRect(rect).Position;
            }
        }

    }
}
