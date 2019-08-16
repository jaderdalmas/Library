using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Pattern
{
    public class NotificationProvider : INotification
    {
        public IEnumerable<ENotification> ReturnLevel { get { return AlertLevel.Concat(ErrorLevel); } }
        public IEnumerable<ENotification> TestLevel { get { return new List<ENotification>() { ENotification.Debug, ENotification.Verbose, ENotification.Information }; } }
        public IEnumerable<ENotification> AlertLevel { get { return new List<ENotification>() { ENotification.Warning }; } }
        public IEnumerable<ENotification> ErrorLevel { get { return new List<ENotification>() { ENotification.Error, ENotification.Critical }; } }

        private List<Notification> Notifications { get; set; }

        public NotificationProvider()
        {
            Notifications = new List<Notification>();
        }

        public bool HasNotifications { get { return Notifications.Any(); } }
        public bool HasTests { get { return Notifications.Any(x => TestLevel.Contains(x.Level)); } }
        public bool HasAlerts { get { return Notifications.Any(x => AlertLevel.Contains(x.Level)); } }
        public bool HasErrors { get { return Notifications.Any(x => ErrorLevel.Contains(x.Level)); } }
        public bool HasReturn { get { return HasAlerts || HasErrors; } }


        public string GetReturn { get { return string.Join(" | ", Notifications.Where(x => ReturnLevel.Contains(x.Level)).Select(x => x.Text)); } }
        public IEnumerable<Notification> GetNotifications { get { return Notifications; } }
        public IEnumerable<Notification> GetTests { get { return Notifications.Where(x => TestLevel.Contains(x.Level)); } }
        public IEnumerable<Notification> GetAlerts { get { return Notifications.Where(x => AlertLevel.Contains(x.Level)); } }
        public IEnumerable<Notification> GetErrors { get { return Notifications.Where(x => ErrorLevel.Contains(x.Level)); } }

        private void SetNotification(string text, ENotification level) { Notifications.Add(new Notification(text, level)); }
        public string SetDebug { set { SetNotification(value, ENotification.Debug); } }
        public string SetVerbose { set { SetNotification(value, ENotification.Verbose); } }
        public string SetInformation { set { SetNotification(value, ENotification.Information); } }
        public string SetWarning { set { SetNotification(value, ENotification.Warning); } }
        public string SetError { set { SetNotification(value, ENotification.Error); } }
        public string SetCritical { set { SetNotification(value, ENotification.Critical); } }
    }
}
