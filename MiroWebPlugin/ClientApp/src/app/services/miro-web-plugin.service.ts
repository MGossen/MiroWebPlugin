import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SessionViewModel } from '../models/session-view-model';
import { StickyNoteAddRequest } from '../models/sticky-note-add-request';

@Injectable({
  providedIn: 'root'
})
export class MiroWebPluginService {

  private baseUrl: string = '';
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public createNewSession(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'MiroWebPlugin/CreateNewSession');
  }

  public loadSessionView(): Observable<SessionViewModel> {
    return this.http.get<SessionViewModel>(this.baseUrl + 'MiroWebPlugin/LoadSessionViewModel');
  }

  public addStickyNote(itemId: string, content: string) {
    let stickyNoteAddRequest = new StickyNoteAddRequest();
    
    stickyNoteAddRequest.text = content;
    stickyNoteAddRequest.parentId = itemId;
    
    this.http.put<StickyNoteAddRequest>(this.baseUrl + 'MiroWebPlugin/AddStickyNote', stickyNoteAddRequest).subscribe(success => {

    }, error => {
      console.log(error);
    });
  }
}
