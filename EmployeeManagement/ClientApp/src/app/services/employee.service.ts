import {HttpClient} from "@angular/common/http";
import {EmployeeModel} from "../models/employee.model";
import {Injectable} from "@angular/core";

@Injectable()
export class EmployeeService {
  url = "api/employee/"

  constructor(public http: HttpClient) {
  }

  getAll() {
    return this.http.get(this.url + "getAll");
  }

  add(item: EmployeeModel) {
    return this.http.post(this.url + "add", item);
  }
}
