import {Component, Inject} from "@angular/core";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {PositionModel} from "../../models/position.model";
import {FormControl, Validators} from "@angular/forms";
import {PositionService} from "../../services/position.service";

@Component({
  selector: 'add-position-dialog',
  templateUrl: 'add-position.component.html',
  styleUrls: ['add-position.component.css']
})
export class AddPositionDialogComponent {
  positionControl = new FormControl('', {validators: Validators.required});
  constructor(public dialogRef: MatDialogRef<AddPositionDialogComponent>,
              public positionService: PositionService) {
  }

  add() {
    if (this.positionControl.valid) {
      this.positionService.add({
        id: 0,
        name: this.positionControl.value
      }).subscribe(() => {
        this.dialogRef.close(true);
      });
    }
  }
}
