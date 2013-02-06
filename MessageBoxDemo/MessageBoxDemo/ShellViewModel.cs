using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;

namespace MessageBoxDemo {
    [Export(typeof (IShell))]
    public class ShellViewModel : Screen, IShell {
        private readonly IWindowManager _windowManager;

        private int _overlayDependencies;

        [ImportingConstructor]
        public ShellViewModel(IWindowManager windowManager) {
            _windowManager = windowManager;
        }

        public bool IsOverlayVisible {
            get { return _overlayDependencies > 0; }
        }

        public void ShowOverlay() {
            _overlayDependencies++;
            NotifyOfPropertyChange(() => IsOverlayVisible);
        }

        public void HideOverlay() {
            _overlayDependencies--;
            NotifyOfPropertyChange(() => IsOverlayVisible);
        }

        public void DisplayMessageBox() {
            _windowManager.ShowMetroMessageBox("Are you sure you want to delete...", "Confirm Delete",
                                               MessageBoxButton.YesNo);
        }
    }
}