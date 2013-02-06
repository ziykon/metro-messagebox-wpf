using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;

namespace MessageBoxDemo
{
    [Export(typeof(IMetroMessageBox))]
    public class MetroMessageBoxViewModel : Screen, IMetroMessageBox
    {
        private MessageBoxButton _buttons = MessageBoxButton.OK;
        private string _message;
        private string _title;
        private MessageBoxResult _result = MessageBoxResult.None;

        public MetroMessageBoxViewModel(string message, string title, MessageBoxButton buttons)
        {
            Title = title;
            Message = message;
            Buttons = buttons;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public bool IsNoButtonVisible
        {
            get { return _buttons == MessageBoxButton.YesNo || _buttons == MessageBoxButton.YesNoCancel; }
        }

        public bool IsYesButtonVisible
        {
            get { return _buttons == MessageBoxButton.YesNo || _buttons == MessageBoxButton.YesNoCancel; }
        }

        public bool IsCancelButtonVisible
        {
            get { return _buttons == MessageBoxButton.OKCancel || _buttons == MessageBoxButton.YesNoCancel; }
        }

        public bool IsOkButtonVisible
        {
            get { return _buttons == MessageBoxButton.OK || _buttons == MessageBoxButton.OKCancel; }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        public MessageBoxButton Buttons
        {
            get { return _buttons; }
            set
            {
                _buttons = value;
                NotifyOfPropertyChange(() => IsNoButtonVisible);
                NotifyOfPropertyChange(() => IsYesButtonVisible);
                NotifyOfPropertyChange(() => IsCancelButtonVisible);
                NotifyOfPropertyChange(() => IsOkButtonVisible);
            }
        }

        public MessageBoxResult Result { get { return _result; } }

        public void No()
        {
            _result = MessageBoxResult.No;
            TryClose(false);
        }

        public void Yes()
        {
            _result = MessageBoxResult.Yes;
            TryClose(true);
        }

        public void Cancel()
        {
            _result = MessageBoxResult.Cancel;
            TryClose(false);
        }

        public void Ok()
        {
            _result = MessageBoxResult.OK;
            TryClose(true);
        }
    }
}