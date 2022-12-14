import { createRouter, createWebHistory } from "vue-router";
import HomeView from '../views/HomeView.vue'
// import AddIdeaView from "../views/AddIdeaView.vue";
// import SignupVue from "../views/Signup.vue";
// import NewsfeedView from "../views/NewsfeedView.vue";
// import IdeaPage from "../views/IdeaPage.vue";
// import LoginVue from "../views/Login.vue";
// import UserProfileVue from "../views/UserProfile.vue";
// import AdminDashboardViewVue from "../views/AdminDashboardView.vue";
// import UsersManagementVue from "../views/UsersManagement.vue";
// import AdminDashboardPageVue from "../views/AdminDashboardPage.vue";
// import SidebarAdmindashboardVue from "../components/utils/SidebarAdmindashboard.vue";
// import PublicFilteredIdeasViewVue from "../views/PublicFilteredIdeasView.vue";
// import EditIdeaView from "../views/EditIdeaView.vue";
// import MyIdeasViewVue from "../views/MyIdeasView.vue";
// import PageNotFoundViewVue from "../views/PageNotFoundView.vue";
// import CategoriesManagementViewVue from "../views/CategoriesManagementView.vue";
// import AllUsersViewVue from "../views/AllUsersView.vue";
// import store from "../store";
// import WarningsVue from "../views/Warnings.vue";
// import MyFollowedIdeasVue from "../views/MyFollowedIdeas.vue";
// import LoginRegisterHomePage from "../views/LoginRegisterHomePage.vue";
// import { hasUserRole, UserRoles } from '@/components/utils/usermanagement/hasUserRole';
// import { handleLogout } from '@/components/utils/usermanagement/performLogout';
// import performLogout from '@/components/utils/usermanagement/performLogout';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
        path: "/home",
        name: "home",
        // props: true,
        component: HomeView,
      },
    // {
    //   path: "/addIdea",
    //   name: "addIdea",
    //   component: AddIdeaView,
    //   meta: { role: UserRoles.STANDARD },
    // },
    // {
    //   path: "/signup",
    //   name: "signup",
    //   component: SignupVue,
    // },
    // {
    //   path: "/newsfeed/:pageType",
    //   name: "newsfeed",
    //   props: true,
    //   component: NewsfeedView,
    //   meta: { role: UserRoles.STANDARD },
    // },
    // {
    //   path: "/ideaPage/:id",
    //   props: true,
    //   name: "ideaPage",
    //   component: IdeaPage,
    //   meta: { role: UserRoles.STANDARD },
    // },
    // {
    //   path: "/login",
    //   name: "login",
    //   component: LoginVue,
    // },
    // {
    //   path: "/userProfile/:id",
    //   name: "userProfile",
    //   component: UserProfileVue,
    //   meta: { role: UserRoles.STANDARD },
    // },
    // {
    //   path: "/adminDashboardPage",
    //   name: "adminDashboardPage",
    //   component: AdminDashboardViewVue,
    //   meta: { role: UserRoles.ADMIN },
    // },
    // {
    //   path: "/usersManagement",
    //   name: "usersManagement",
    //   component: UsersManagementVue,
    //   meta: { role: UserRoles.ADMIN },
    // },
    // {
    //   path: "/allUsers",
    //   name: "allUsers",
    //   component: AllUsersViewVue,
    //   meta: { role: UserRoles.STANDARD },
    // },
    // {
    //   path: "/categoriesManagement",
    //   name: "categoriesManagement",
    //   component: CategoriesManagementViewVue,
    //   meta: { role: UserRoles.ADMIN },
    // },
    // {
    //   path: "/warningsManagement",
    //   name: "warningsManagement",
    //   component: WarningsVue,
    //   meta: { role: UserRoles.ADMIN },
    // },
    // {
    //   path: "/PublicFilteredIdeas",
    //   name: "PublicFilteredIdeas",
    //   component: PublicFilteredIdeasViewVue,
    //   meta: { role: UserRoles.STANDARD },
    // },
    // {
    //   path: "/EditIdea/:id",
    //   name: "/EditIdea",
    //   component: EditIdeaView,
    //   meta: { role: UserRoles.STANDARD },
    // },
    // {
    //   path: "/MyIdeas/:userId",
    //   name: "MyIdeas",
    //   component: MyIdeasViewVue,
    //   params: { userId: Number },
    //   meta: { role: UserRoles.STANDARD },
    // },
    // {
    //   path: "/PageNotFound",
    //   name: "PageNotFound",
    //   component: PageNotFoundViewVue,
    // },
    // {
    //   path: "/myFolowedIdeas",
    //   name: "myFollowedIdeas",
    //   component: MyFollowedIdeasVue,
    //   meta: { role: UserRoles.STANDARD },

    // },
    // {
    //   path: "/LoginRegisterHomePage",
    //   name: "loginRegisterHomePage",
    //   component: LoginRegisterHomePage,
    // },
    // {
    //   path: "/:pathMatch(.*)",
    //   component: PageNotFoundViewVue,
    // },
  ],
});

// router.beforeEach(async (to, from, next) => {
//   if (to.meta.role && !hasUserRole(to.meta.role)) {
//     handleLogout();
//     performLogout();
//     next("/login");
//   } else {
//     next();
//   }
// });

export default router;
