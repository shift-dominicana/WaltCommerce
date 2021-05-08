import { Component } from '@angular/core'
import { select, Store } from '@ngrx/store'
import * as SettingsActions from 'src/app/store/settings/actions'
import * as Reducers from 'src/app/store/reducers'

@Component({
  selector: 'air-footer-dark',
  templateUrl: './footer-dark.component.html',
  styleUrls: ['./footer-dark.component.scss'],
})
export class FooterDarkComponent {
  isContentNoMaxWidth: boolean
  logo: string
  description: string
  currentYear: number = new Date().getFullYear()

  constructor(private store: Store<any>) {
    this.store.pipe(select(Reducers.getSettings)).subscribe(state => {
      this.isContentNoMaxWidth = state.isContentNoMaxWidth
      this.logo = state.logo
      this.description = state.description
    })
  }
}
