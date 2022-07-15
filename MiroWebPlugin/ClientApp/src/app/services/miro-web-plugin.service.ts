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

  public loadSessionView(sessionId: number): Observable<SessionViewModel> {
    return this.http.get<SessionViewModel>(this.baseUrl + 'MiroWebPlugin/LoadSessionViewModel/' + sessionId);
  }

  public addStickyNote(itemId: string, content: string, sessionId : number) {
    let stickyNoteAddRequest = new StickyNoteAddRequest();
    
    stickyNoteAddRequest.text = content;
    stickyNoteAddRequest.parentId = itemId;
    stickyNoteAddRequest.sessionId = sessionId;
    
    return this.http.put<StickyNoteAddRequest>(this.baseUrl + 'MiroWebPlugin/AddStickyNote', stickyNoteAddRequest);
  }
}
