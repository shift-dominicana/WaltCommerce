import { Component, OnInit } from '@angular/core'
import { select, Store } from '@ngrx/store'
import * as Reducers from 'src/app/store/reducers'

@Component({
  selector: 'air-topbar-dark',
  templateUrl: './topbar-dark.component.html',
  styleUrls: ['./topbar-dark.component.scss'],
})
export class TopbarDarkComponent implements OnInit {
  logo: string
  description: string

  constructor(private store: Store<any>) {}

  ngOnInit() {
    this.store.pipe(select(Reducers.getSettings)).subscribe(state => {
      this.logo = state.logo
      this.description = state.description
    })
  }
}
