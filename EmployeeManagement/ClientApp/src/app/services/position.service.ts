import {HttpClient} from "@angular/common/http";
import {PositionModel} from "../models/position.model";
import {Injectable} from "@angular/core";

@Injectable()
export class PositionService {
  url = "api/position/"

  constructor(public http: HttpClient) {
  }

  getAll() {
    return this.http.get(this.url + "getAll");
  }

  add(item: PositionModel) {
    return this.http.post(this.url + "add", item);
  }
}
