using System.Windows;
using Caliburn.Micro;

namespace MessageBoxDemo {
    public static class WindowManagerExtensions {
        public static MessageBoxResult ShowMetroMessageBox(this IWindowManager @this, string message, string title,
                                                           MessageBoxButton buttons) {
            MessageBoxResult retval;
            var shellViewModel = IoC.Get<IShell>();

            try {
                shellViewModel.ShowOverlay();
                var model = new MetroMessageBoxViewModel(message, title, buttons);
                @this.ShowDialog(model);

                retval = model.Result;
            }
            finally {
                shellViewModel.HideOverlay();
            }

            return retval;
        }

        public static void ShowMetroMessageBox(this IWindowManager @this, string message) {
            @this.ShowMetroMessageBox(message, "System Message", MessageBoxButton.OK);
        }
    }
}