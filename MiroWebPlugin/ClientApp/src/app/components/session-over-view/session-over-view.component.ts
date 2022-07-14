import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-session-over-view',
  templateUrl: './session-over-view.component.html',
  styleUrls: ['./session-over-view.component.css']
})
export class SessionOverViewComponent implements OnInit {
  public sessionId: number = -1;
  private baseURL: string = '';
  public sessionLink: string = 'NotDefined';

  constructor(private route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;

  }

  ngOnInit(): void {
     this.route.params.subscribe(params => {
       this.sessionId = +params["id"];
       this.sessionLink = this.baseURL + 'board/' + this.sessionId;
    });
  }
}
