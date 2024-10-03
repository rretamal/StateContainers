using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StateContainersDemo.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _currentState = string.Empty;
        public string CurrentState
        {
            get => _currentState;
            set
            {
                if (_currentState != value)
                {
                    _currentState = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _canStateChange = true;
        public bool CanStateChange
        {
            get => _canStateChange;
            set
            {
                if (_canStateChange != value)
                {
                    _canStateChange = value;
                    OnPropertyChanged();
                    // Notify that the command's CanExecute has changed
                    ((Command)LoginCommand).ChangeCanExecute();
                }
            }
        }

        // Implement the LoginCommand using ICommand
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            CurrentState = "Default";

            // Initialize the command with a method that determines CanExecute
            LoginCommand = new Command(async () => await LoginAsync(), () => CanStateChange);
        }

        // Method to perform the login logic
        private async Task LoginAsync()
        {
            if (!CanStateChange)
                return;

            // Simulate loading state
            CurrentState = "Loading";
            CanStateChange = false;

            try
            {
                // Simulate a login process (replace this with real logic)
                await Task.Delay(2000);

                // Update to Success state
                CurrentState = "Success";
                CanStateChange = true;

                // Show success message
                await Application.Current.MainPage.DisplayAlert("Login", "Login successful", "OK");

                // Reset the state
                CurrentState = string.Empty;
            }
            catch (Exception ex)
            {
                // Handle errors and display error message
                await Application.Current.MainPage.DisplayAlert("Error", $"Login failed: {ex.Message}", "OK");
                CurrentState = string.Empty;
                CanStateChange = true;
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
