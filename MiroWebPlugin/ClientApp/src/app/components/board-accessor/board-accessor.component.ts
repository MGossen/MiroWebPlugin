import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from '../../models/item';
import { SimpleStickyNote } from '../../models/simple-sticky-note';
import { MiroWebPluginService } from '../../services/miro-web-plugin.service';

@Component({
  selector: 'app-board-accessor',
  templateUrl: './board-accessor.component.html',
  styleUrls: ['./board-accessor.component.css']
})
export class BoardAccessorComponent implements OnInit {

  public id: number;
  public inputFields: Item[];
  public addedStickyNotes: SimpleStickyNote[];
  private sub: any;
  constructor(private route: ActivatedRoute, private miroSvc: MiroWebPluginService) {
    this.id = -1
    this.inputFields = [];
    this.addedStickyNotes = [];
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params["id"];
    });

    this.miroSvc.loadSessionView(this.id).subscribe(data => {
      this.inputFields = data.inputFields;
    });
  }

  public addStickyNote(itemId: string, event: any) {
    let content = event.target.value;
    if (content !== '') {
      this.miroSvc.addStickyNote(itemId, content, this.id).subscribe(id => {
        var ssn = new SimpleStickyNote();
        ssn.id = id as unknown as string;
        ssn.content = content;
        ssn.parentId = itemId;
        this.addedStickyNotes.push(ssn);
      }, error => {
        console.log(error);
      });;
    }
  }

  public getTitle(item: Item): string {
    if (item.data.title != null && item.data.title !== '') {
      return item.data.title;
    }
    if (item.data.content != null && item.data.content !== '') {
      return item.data.content;
    }
    return item.id;
  }
  public removeStickyNote(id: string) {

    this.miroSvc.removeStickyNote(id).subscribe(success => {
        this.addedStickyNotes = this.addedStickyNotes.filter(x => x.id !== id);
    }, error => {
      console.log(error);
    });
  }
}
