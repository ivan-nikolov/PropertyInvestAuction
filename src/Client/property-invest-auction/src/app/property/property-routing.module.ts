import { RouterModule, Routes } from "@angular/router";
import { UserAuthGuard } from "../user/services/userAuth.guard";
import { CreateComponent } from "./create/create.component";


const routes: Routes = [
    {
        path: "property",
        canActivateChild: [UserAuthGuard],
        children: [
            {
                path: "create",
                component: CreateComponent,
                data: {
                    isAuthenticated: true,
                }
            }
        ]
    }
]

export const PropertyRoutingModule = RouterModule.forChild(routes);