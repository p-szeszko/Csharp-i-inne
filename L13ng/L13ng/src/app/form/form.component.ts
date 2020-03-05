import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {NotificationService} from '../notification/notification.service';
import {Notification} from '../notification/Notification';
@Component({
  selector: 'app-formula',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
  
})
export class FormComponent implements OnInit {

  descriptionForm: FormGroup;
  constructor(private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.initEmptyForm();
  }
  onSubmit() {
    this.notificationService.addNotification( new Notification(this.descriptionForm.value.title,
      this.descriptionForm.value.description, this.descriptionForm.value.mail));
    this.descriptionForm.reset();
  }
  resetForm() {
    this.descriptionForm.reset();
  }
  initEmptyForm() {
    this.descriptionForm = new FormGroup({title: new FormControl(' ', Validators.required),
  description: new FormControl('', Validators.required),
mail: new FormControl('', [Validators.email, Validators.required]), });
  }

}
