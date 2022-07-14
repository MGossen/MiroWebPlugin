export class StickyNoteAddRequest {
  public text: string;
  public parentId: string;

  constructor() {
    this.text = '';
    this.parentId = '';
  }
}
