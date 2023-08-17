import {Component, Inject} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import {NgIf} from '@angular/common';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'dialog-viwer.component.html',
  standalone: true,
  imports: [MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
})
export class DialogOverviewExampleDialog {

 public dialogData : DialogData = { message :'', detailMessage :''};

counter : number = 0;
  constructor(
    public dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
    @Inject(MAT_DIALOG_DATA) data: DialogData,
  ) { 

    this.dialogData = data;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}

export interface DialogData {
  message: string;
  detailMessage: string;
}

