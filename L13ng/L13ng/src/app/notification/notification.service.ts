import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Notification} from './Notification';

@Injectable()
export class NotificationService {

    constructor(private http: HttpClient) {}

    addNotification(notification: Notification) {
        
        this.http.post('https://rfapplication2.azurewebsites.net/api/datamodels', notification).subscribe();
    }
}
