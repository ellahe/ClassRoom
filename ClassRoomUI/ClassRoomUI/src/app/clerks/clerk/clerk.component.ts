import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-clerk',
  templateUrl: './clerk.component.html',
  styleUrls: ['./clerk.component.css']
})
export class ClerkComponent implements OnInit {

  addClerkForm: FormGroup = new FormGroup({});

  constructor() { }

  ngOnInit(): void {
    this.addClerkForm = new FormGroup({
      firstname: new FormControl('', [Validators.required]),
      lastname: new FormControl('', [Validators.required]),
      userName : new FormControl('', [Validators.required]),
      password : new FormControl('', [Validators.required]),
      phoneNumber: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email])
    });
  }

get email(){
  return this.addClerkForm.controls['email'];
}

  onSubmit() {
    if (this.addClerkForm.valid) {
      console.log(this.addClerkForm.value);
      this.addClerkForm.reset();
      alert('Successful');
    }
    else
      alert('form is not valid');
  }

}
