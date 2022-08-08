import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddStickyNoteResult } from '../models/add-sticky-note-result';
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

  public addStickyNote(itemId: string, content: string, sessionId: number): Observable<string> {
    let stickyNoteAddRequest = new StickyNoteAddRequest();
    
    stickyNoteAddRequest.text = content;
    stickyNoteAddRequest.parentId = itemId;
    stickyNoteAddRequest.sessionId = sessionId;

    return new Observable<string>((s) => {
      return this.http.put<AddStickyNoteResult>(this.baseUrl + 'MiroWebPlugin/AddStickyNote', stickyNoteAddRequest).subscribe((success) => {
        s.next(success.id);
      });
    });
  }
  public removeStickyNote(id: string) {
    console.log("afasdfas");
    console.log(this.baseUrl + 'MiroWebPlugin/DeleteStickyNote/' + id);
    return this.http.delete<void>(this.baseUrl + 'MiroWebPlugin/DeleteStickyNote/' + id);
  }
}
