import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-clerk',
  templateUrl: './clerk.component.html',
  styleUrls: ['./clerk.component.css']
})
export class ClerkComponent implements OnInit {

  addCustomerForm: FormGroup = new FormGroup({});

  constructor() { }

  ngOnInit(): void {
    this.addCustomerForm = new FormGroup({
      firstname: new FormControl(''),
      lastname: new FormControl(''),
      dateOfBirth: new FormControl(''),
      phoneNumber: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      bankAccountNumber: new FormControl(''),
    });
  }

get email(){
  return this.addCustomerForm.controls['email'];
}

  onSubmit() {
    if (this.addCustomerForm.valid) {
      console.log(this.addCustomerForm.value);
      this.addCustomerForm.reset();
      alert('Successful');
    }
    else
      alert('form is not valid');
  }

}
