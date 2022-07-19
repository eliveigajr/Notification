﻿using System.Collections.Generic;
using DomainNotification.Domain.Notifications;

namespace DomainNotification.Domain.Interfaces.Notifications
{
    public interface INotification
    {
        IList<object> List { get; }
        bool HasNotifications { get; }

        bool Includes(Description alert);
        void Add(Description alert);
    }
}