using System;
using System.Windows;

namespace MessageBoxDemo
{
    /// <summary>
    /// Interaction logic for MetroMessageBoxView.xaml
    /// </summary>
    public partial class MetroMessageBoxView : Window
    {
        public MetroMessageBoxView()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            if (Owner != null)
            {
                if (Owner.WindowState == WindowState.Maximized)
                {
                    Left = 0;
                    Top = (Owner.Height - 200) / 2;
                    Width = Owner.Width;
                }
                else
                {
                    Left = Owner.Left + 1;
                    Top = Owner.Top + ((Owner.Height - 200) / 2);
                    Width = Owner.Width - 2;
                }
            }

            base.OnActivated(e);
        }

    }
}
