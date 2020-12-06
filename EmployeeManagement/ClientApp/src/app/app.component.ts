import {Component, OnInit} from '@angular/core';
import {EmployeeModel} from "./models/employee.model";
import {PositionService} from "./services/position.service";
import {EmployeeService} from "./services/employee.service";
import {PositionModel} from "./models/position.model";
import {MatDialog} from "@angular/material/dialog";
import {AddEmployeeDialogComponent} from "./dialogs/add-employee/add-employee.component";
import {AddPositionDialogComponent} from "./dialogs/add-position/add-position.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  dataSource: EmployeeModel[];
  positions: PositionModel[];
  displayedColumns = ['id', 'position', 'name', 'salary', 'hiringDate', 'dismissalDate'];

  constructor(public positionService: PositionService, public employeeService: EmployeeService, public dialog: MatDialog) {
    this.employeeService.getAll().subscribe((item: EmployeeModel[]) => {
      this.dataSource = item;
    });
    this.positionService.getAll().subscribe((item: PositionModel[]) => {
      this.positions = item;
    });
  }

  positionIdToName(id: number) {
    if (this.positions) {
      return this.positions.find(item => item.id == id).name;
    }
  }

  addEmployee() {
    let dialogRef = this.dialog.open(AddEmployeeDialogComponent, {data: this.positions});
    dialogRef.afterClosed().subscribe((item: boolean) => {
      if (item) {
        this.employeeService.getAll().subscribe((item: EmployeeModel[]) => {
          this.dataSource = item;
        });
      }
    })
  }

  addPosition() {
    let dialogRef = this.dialog.open(AddPositionDialogComponent);
    dialogRef.afterClosed().subscribe((item: boolean) => {
      if (item) {
        this.positionService.getAll().subscribe((item: PositionModel[]) => {
          this.positions = item;
        });
      }
    });
  }
}
