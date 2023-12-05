
import { Home } from "./components/Home";
import Register from "./components/Register/Register";
import LoginPage from "./components/LoginPage/LoginPage";
import HomePage from "./components/HomePage/HomePage";
import ChangePassword from "./components/ChangePassword/ChangePassword";
import Shop from "./components/Shop/Shop";
import MyProfile from "./components/MyProfile/MyProfile";
import Basket from "./components/Basket/Basket";

const AppRoutes = [
  {
    index: true,
    element: <HomePage />
  },
 
    {
        path: '/register',
        element: <Register />
    },
    {
        path: '/login',
        element: <LoginPage />
    },
    {
        path: '/changepassword',
        element: <ChangePassword />
    },
    {
        path: '/shop',
        element: <Shop />
    },
    {
        path: '/myprofile',
        element: <MyProfile />
    },
    {
        path: '/basket',
        element: <Basket />
    }
];

export default AppRoutes;
