export class StickyNoteAddRequest {
  public text: string;
  public parentId: string;
  public sessionId: number;

  constructor() {
    this.text = '';
    this.parentId = '';
    this.sessionId = -1;
  }
}
