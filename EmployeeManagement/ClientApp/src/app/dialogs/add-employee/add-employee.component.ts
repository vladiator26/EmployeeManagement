import {Component, Inject} from "@angular/core";
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from "@angular/material/dialog";
import {PositionModel} from "../../models/position.model";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {EmployeeService} from "../../services/employee.service";
import {MomentDateAdapter, MAT_MOMENT_DATE_ADAPTER_OPTIONS} from '@angular/material-moment-adapter';
import {DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE} from '@angular/material/core';
import * as _moment from 'moment';

const moment = _moment;

export const MY_FORMATS = {
  parse: {
    dateInput: 'LL',
  },
  display: {
    dateInput: 'LL',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};


@Component({
  selector: 'add-employee-dialog',
  templateUrl: 'add-employee.component.html',
  styleUrls: ['add-employee.component.css'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS]
    },

    {provide: MAT_DATE_FORMATS, useValue: MY_FORMATS},
  ],
})
export class AddEmployeeDialogComponent {
  lastNameControl = new FormControl('', { validators: [Validators.required]});
  firstNameControl = new FormControl('', { validators: [Validators.required]});
  positionControl = new FormControl(1, {validators: [Validators.required, Validators.min(1)]});
  salaryControl = new FormControl(1, {validators: [Validators.required, Validators.min(1)]});
  hiringDateControl = new FormControl(moment(), {validators: [Validators.required]});
  dismissalDateControl = new FormControl();

  form = new FormGroup({
    lastName: this.lastNameControl,
    firstName: this.firstNameControl,
    position: this.positionControl,
    salary: this.salaryControl,
    hiringDate: this.hiringDateControl,
    dismissalDate: this.dismissalDateControl
  });

  constructor(public dialogRef: MatDialogRef<AddEmployeeDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: PositionModel[],
              public employeeService: EmployeeService) {
  }

  add() {
    if (this.form.valid) {
      this.employeeService.add({
        id: 0,
        firstName: this.firstNameControl.value,
        lastName: this.lastNameControl.value,
        positionId: this.positionControl.value,
        salary: this.salaryControl.value,
        hiringDate: this.hiringDateControl.value,
        dismissalDate: this.dismissalDateControl.value
      }).subscribe(() => {
        this.dialogRef.close(true);
      })
    }
  }
}
