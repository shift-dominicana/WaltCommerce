import { NgModule } from '@angular/core'
import { SharedModule } from 'src/app/shared.module'
import { DashboardRouterModule } from './dashboard-routing.module'
import { WidgetsComponentsModule } from 'src/app/@kit/widgets/widgets-components.module'
import { NestableModule } from 'ngx-nestable'
import { FormsModule } from '@angular/forms'
import { ChartistModule } from 'ng-chartist'
import { NvD3Module } from 'ng2-nvd3'

import 'd3'
import 'nvd3'

// dashboard
import { DashboardAnalyticsComponent } from 'src/app/pages/dashboard/analytics/analytics.component'
import { DashboardEcommerceComponent } from 'src/app/pages/dashboard/ecommerce/ecommerce.component'
import { DashboardHelpdeskComponent } from 'src/app/pages/dashboard/helpdesk/helpdesk.component'
import { DashboardStatisticsComponent } from 'src/app/pages/dashboard/statistics/statistics.component'
import { DashboardJiraComponent } from 'src/app/pages/dashboard/jira/jira.component'
import { DashboardCryptoComponent } from 'src/app/pages/dashboard/crypto/crypto.component'
import { DashboardCryptoTerminalComponent } from 'src/app/pages/dashboard/crypto-terminal/crypto-terminal.component'

const COMPONENTS = [
  DashboardAnalyticsComponent,
  DashboardEcommerceComponent,
  DashboardHelpdeskComponent,
  DashboardStatisticsComponent,
  DashboardJiraComponent,
  DashboardCryptoComponent,
  DashboardCryptoTerminalComponent,
]

@NgModule({
  imports: [
    SharedModule,
    DashboardRouterModule,
    WidgetsComponentsModule,
    NestableModule,
    FormsModule,
    ChartistModule,
    NvD3Module,
  ],
  declarations: [...COMPONENTS],
})
export class DashboardModule {}
