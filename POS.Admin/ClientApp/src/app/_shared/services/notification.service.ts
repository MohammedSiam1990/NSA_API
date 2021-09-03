import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class NotificationService {
   
    public showNotificationEvent = new EventEmitter<any>();
    public hideNotificationEvent = new EventEmitter<any>();

    constructor() { }

    showNotification(message: string, type: NotificationType) {
        this.showNotificationEvent.emit({ message: message, type: type });
    }

    hideNotification() {
        this.hideNotificationEvent.emit();
    }
}

export enum NotificationType {
    Success,
    Error,
    Alert,
    Processing
}