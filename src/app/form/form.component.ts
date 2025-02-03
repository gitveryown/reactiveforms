import { NgIf, NgStyle } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import {
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { ApiService } from '../api.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ReactiveFormsModule, RouterModule, NgStyle, NgIf],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css',
})
export class FormComponent implements OnInit {
  form!: FormGroup;
  private apiService = inject(ApiService);

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      firstName: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      lastName: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      email: new FormControl('', [Validators.required, Validators.email]),
    });
  }

  get firstName() {
    return this.form.get('firstName');
  }
  get lastName() {
    return this.form.get('lastName');
  }
  get email() {
    return this.form.get('email');
  }

  onSubmit() {
    if (this.form.valid) {
      const formData = this.form.value;
      console.log('This is the values', formData);
      this.apiService.sendFormData(formData).subscribe({
        next: (response) => console.log('Submission successful', response),
        error: (error) => console.log('Submission unsuccessful', error),
        complete: () => console.log('Request completed successfully!'),
      });
    }
  }
}
