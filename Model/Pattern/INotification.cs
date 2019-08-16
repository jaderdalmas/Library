using System.Collections.Generic;

namespace Model.Pattern
{
    public interface INotification
    {
        /// <summary>
        /// ENotification for Return Level
        /// </summary>
        IEnumerable<ENotification> ReturnLevel { get; }

        /// <summary>
        /// ENotification for Test Level
        /// </summary>
        IEnumerable<ENotification> TestLevel { get; }

        /// <summary>
        /// ENotification for Alert Level
        /// </summary>
        IEnumerable<ENotification> AlertLevel { get; }

        /// <summary>
        /// ENotification for Error Level
        /// </summary>
        IEnumerable<ENotification> ErrorLevel { get; }


        /// <summary>
        /// Verify if has Notifications
        /// </summary>
        bool HasNotifications { get; }

        /// <summary>
        /// Verify if has Tests
        /// </summary>
        bool HasTests { get; }

        /// <summary>
        /// Verify if has Alerts
        /// </summary>
        bool HasAlerts { get; }
       
        /// <summary>
        /// Verify if has Errors
        /// </summary>
        bool HasErrors { get; }

        /// <summary>
        /// Verify if has Alerts or Errors
        /// </summary>
        bool HasReturn { get; }


        /// <summary>
        /// Get Return Notifications
        /// </summary>
        string GetReturn { get; }

        /// <summary>
        /// Get Notifications
        /// </summary>
        IEnumerable<Notification> GetNotifications { get; }

        /// <summary>
        /// Get Tests Notifications
        /// </summary>
        IEnumerable<Notification> GetTests { get; }

        /// <summary>
        /// Get Alerts Notifications
        /// </summary>
        IEnumerable<Notification> GetAlerts { get; }

        /// <summary>
        /// Get Errors Notifications
        /// </summary>
        IEnumerable<Notification> GetErrors { get; }
        

        /// <summary>
        /// Set a Debug Notification
        /// </summary>
        string SetDebug { set; }

        /// <summary>
        /// Set a Verbose Notification
        /// </summary>
        string SetVerbose { set; }

        /// <summary>
        /// Set an Information Notification
        /// </summary>
        string SetInformation { set; }

        /// <summary>
        /// Set a Warning Notification
        /// </summary>
        string SetWarning { set; }

        /// <summary>
        /// Set an Error Notification
        /// </summary>
        string SetError { set; }

        /// <summary>
        /// Set a Critical Notification
        /// </summary>
        string SetCritical { set; }
    }
}
