// LoginWrapper.jsx
import React, { use } from 'react';
import {  useNavigate, useLocation, useParams} from 'react-router-dom';

// const PageWrapper = () => {
//   const navigate = useNavigate();
//   return <Login navigate={navigate} />;
// };

export function withNavigation(Component) {
  return function WrappedComponent(props) {
    const navigate = useNavigate();
    const location= useLocation();
    const params=useParams();
    // const { navigate, location, params } = props;
    return <Component {...props} 
    navigate={navigate}
    location={location}
    params={params} />;
  };
}

export default withNavigation;
