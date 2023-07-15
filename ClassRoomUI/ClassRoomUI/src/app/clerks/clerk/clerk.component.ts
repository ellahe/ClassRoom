import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ClerkService } from './clerk.service';

@Component({
  selector: 'app-clerk',
  templateUrl: './clerk.component.html',
  styleUrls: ['./clerk.component.css']
})
export class ClerkComponent implements OnInit {

  clerkForm: FormGroup = new FormGroup({});

  constructor(private clerkService: ClerkService) { }

  ngOnInit(): void {
    this.clerkForm = new FormGroup({
      firstname: new FormControl('', [Validators.required]),
      lastname: new FormControl('', [Validators.required]),
      userName : new FormControl('', [Validators.required]),
      password : new FormControl('', [Validators.required]),
      mobileNumber: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email])
    });
  }

get email(){
  return this.clerkForm.controls['email'];
}

  onSubmit() {
    if (this.clerkForm.valid) {
      var clerkID= this.clerkService.add(this.clerkForm.value).subscribe();
      console.log(this.clerkService.get(1).subscribe());
      this.clerkForm.reset();
      alert('Successful');
    }
    else
      alert('form is not valid');
  }

}
