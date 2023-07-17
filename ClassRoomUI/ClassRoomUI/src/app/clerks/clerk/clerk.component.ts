import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ClerkService } from './clerk.service';
import { ClerkDTO } from 'src/app/DTOS/clerk-dto';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-clerk',
  templateUrl: './clerk.component.html',
  styleUrls: ['./clerk.component.css']
})
export class ClerkComponent implements OnInit {

  clerkForm: FormGroup = new FormGroup({});
  clerk: ClerkDTO = new ClerkDTO(0, "", "", "", "", "", "");

  constructor(
    private clerkService: ClerkService,
    private route: ActivatedRoute) {
    this.clerkForm = new FormGroup({
      firstname: new FormControl('', [Validators.required]),
      lastname: new FormControl('', [Validators.required]),
      userName: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      mobileNumber: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email])
    });
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.clerkService.getByUserNameAndPassword(params.get('userName') ?? '' , params.get('password') ?? '').subscribe(
        (data: any) => {
          if (data != null && data.body != null) {
            this.clerk = data.body;
            if (this.clerk) {
              this.clerkForm.controls["firstName"].setValue(this.clerk.firstName);
              this.clerkForm.controls["lastName"].setValue(this.clerk.lastName);
              this.clerkForm.controls["email"].setValue(this.clerk.email);
              this.clerkForm.controls["mobileNumber"].setValue(this.clerk.mobileNumber);
              this.clerkForm.controls["userName"].setValue(this.clerk.userName);
              this.clerkForm.controls["password"].setValue(this.clerk.password);
            }
          }
        }
      );
    });
  }

  get email() {
    return this.clerkForm.controls['email'];
  }

  onSubmit() {
    if (this.clerkForm.valid) {
      var clerkID = this.clerkService.add(this.clerkForm.value).subscribe();
      console.log(this.clerkService.getByUserNameAndPassword("1", "2").subscribe());
      this.clerkForm.reset();
      alert('Successful');
    }
    else
      alert('form is not valid');
  }

}
