using System;
using System.Windows.Input;
using Plugin.LocalNotification;  // Add this for local notifications
using Plugin.LocalNotification.AndroidOption;

namespace SafetyCheckApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private string checkInStatus = "Awaiting Check-In";  // Default status
        public string CheckInStatus
        {
            get => checkInStatus;
            set
            {
                checkInStatus = value;
                OnPropertyChanged();  // Notify the UI to update the label
            }
        }

        public ICommand CheckInCommand { get; }

        public MainPageViewModel()
        {
            CheckInCommand = new Command(OnCheckIn);
            ScheduleCheckInReminder();  // Schedule the reminder when ViewModel is initialized
        }

        private async void OnCheckIn()
        {
            // Update status to simulate check-in (you can store this in a database)
            CheckInStatus = "Checked In at " + DateTime.Now.ToString("hh:mm tt");
        }

        private void ScheduleCheckInReminder()
        {
            var notification = new NotificationRequest
            {
                NotificationId = 1,
                Title = "Safety Check-In Reminder",
                Description = "Please check in to confirm you're safe!",
                ReturningData = "SafetyCheckApp",  // Data returned when tapped
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddMinutes(1),  // Schedule to notify after 1 minute
                    RepeatType = NotificationRepeat.Daily     // Repeat daily
                }
            };

            LocalNotificationCenter.Current.Show(notification);
        }
    }
}
