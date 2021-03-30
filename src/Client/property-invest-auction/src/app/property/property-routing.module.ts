import { RouterModule, Routes } from "@angular/router";
import { NotFoundComponent } from "../core/not-found/not-found.component";
import { UserAuthGuard } from "../user/services/userAuth.guard";
import { CreateComponent } from "./create/create.component";
import { DetailsComponent } from "./details/details.component";
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
            },
            {
                path: "details/:id",
                component: DetailsComponent,
                data: {
                    isAuthenticated: true,
                }
            }
        ]
    }
]

export const PropertyRoutingModule = RouterModule.forChild(routes);