import { Home } from "./components/Home";
 import Login  from "./components/Login/Login";
import  SignUp  from "./components/SignUp/SignUp";
import Profile from "./components/Profile/Profile";
import { User } from "./components/User/User";

const AppRoutes = [
  {
    index: true,
    element: <Login />
  }
  ,
  {
    path: '/Home',
    element: <Home />
  },
  {
    path: '/User',
    element: <User />
  },
  {
    path: '/SignUp',
    element: <SignUp />
  },
  {
    path:'/Profile',
    element:<Profile/>
  }
];

export default AppRoutes;
