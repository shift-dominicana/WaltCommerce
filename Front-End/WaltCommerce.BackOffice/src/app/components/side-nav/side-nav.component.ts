import { Component, OnInit, Input } from '@angular/core'
import * as _ from 'lodash'
import { MenuService } from 'src/app/services/menu/menu.service'
import { Router, NavigationStart } from '@angular/router'
import { filter } from 'rxjs/operators'

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {
  menuData: any = []
  activeSubmenu: string = ''
  activeItem: string = ''
  renderedFlyoutItems: object = {}
  flyoutTimers: object = {}
  flyoutActive: boolean = false
  objectKeys = Object.keys
  constructor(
    private menuService: MenuService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.menuService.getMenuData().subscribe(menuData => (this.menuData = menuData))

    this.setActiveItems(this.router.url)
    this.router.events
      .pipe(filter(event => event instanceof NavigationStart))
      .subscribe((event: NavigationStart) => {
        this.setActiveItems(event.url ? event.url : null)
      })
  }

  
  handleSubmenuClick(key: string) {
    const currentKey = this.activeSubmenu
    if (this.flyoutActive) {
      return
    }
    this.activeSubmenu = currentKey === key ? '' : key
  }

  setActiveItems(pathname) {
    const menuData = this.menuData
    const flattenItems = (items, key) =>
      items.reduce((flattenedItems, item) => {
        flattenedItems.push(item)
        if (Array.isArray(item[key])) {
          return flattenedItems.concat(flattenItems(item[key], key))
        }
        return flattenedItems
      }, [])
    const activeItem = _.find(flattenItems(menuData, 'children'), ['url', pathname]) || {}
    const activeSubmenu = menuData.reduce((key, parent) => {
      if (Array.isArray(parent.children)) {
        parent.children.map(child => {
          if (child.key === activeItem.key) {
            key = parent
          }
          return ''
        })
      }
      return key
    })

    this.activeItem = activeItem.key
    this.activeSubmenu = activeSubmenu.key
  }

  handleFlyoutOver(event, key, items) {
    if (this.flyoutActive) {
      clearInterval(this.flyoutTimers[key])
      const item = event.currentTarget
      const itemDimensions = item.getBoundingClientRect()
      this.renderedFlyoutItems = {
        ...this.renderedFlyoutItems,
        [key]: {
          key,
          itemDimensions,
          items,
        },
      }
    }
  }

  handleFlyoutOut(key) {
    if (this.flyoutActive) {
      this.flyoutTimers[key] = setTimeout(() => {
        const updatedFlyoutItems = Object.assign({}, this.renderedFlyoutItems)
        delete updatedFlyoutItems[key]
        this.renderedFlyoutItems = {
          ...updatedFlyoutItems,
        }
      }, 100)
    }
  }

  handleFlyoutContainerOver(key) {
    clearInterval(this.flyoutTimers[key])
  }
}
