import { Item } from "./item";

export class SessionViewModel {
  public sessionId: string;
  public inputFields: Item[];

  constructor() {
    this.sessionId = '';
    this.inputFields = [];
  }

}
