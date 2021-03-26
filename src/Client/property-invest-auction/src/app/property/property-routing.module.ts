import { RouterModule, Routes } from "@angular/router";
import { UserAuthGuard } from "../user/services/userAuth.guard";
import { CreateComponent } from "./create/create.component";
import { MyPropertiesComponent } from "./my-properties/my-properties.component";


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
            },
            {
                path: "my-properties",
                component: MyPropertiesComponent,
                data: {
                    isAuthenticated: true,
                }
            }
        ]
    }
]

export const PropertyRoutingModule = RouterModule.forChild(routes);