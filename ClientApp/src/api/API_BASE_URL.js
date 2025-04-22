// const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;
const REACT_APP_STATUS ="development"; //process.env.REACT_APP_STATUS;
const API_BASE_URL  =REACT_APP_STATUS==="development" ?process.env.REACT_APP_SANDBOX_REACT_APP_API_BASE_URL:process.env.REACT_APP_PRODUCTION_REACT_APP_API_BASE_URL;

console.log("API_BASE_URL",  process.env.REACT_APP_SANDBOX_REACT_APP_API_BASE_URL);
export default API_BASE_URL;

// const token = localStorage.getItem('token');

// const response = await fetch(`${API_BASE_URL}/User/GetUsers`, {
//   headers: {
//     'Authorization': `Bearer ${token}`
//   }
// });

// const logout = () => {
//     localStorage.removeItem('token');
//     window.location.href = '/login'; // Redirect to login page
// };

// const addUser = async (newUser) => {
//     try {
//         const token = localStorage.getItem('token');
//         const response = await axios.post(
//             `${API_BASE_URL}/User/AddUser`,
//             newUser,
//             {
//                 headers: { Authorization: `Bearer ${token}` },
//             }
//         );
//         console.log('User added:', response.data);
//     } catch (error) {
//         console.error('Error adding user:', error);
//     }
// };
