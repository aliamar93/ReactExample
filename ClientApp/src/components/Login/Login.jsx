// import React ,{Component} from 'react';
// // import { Form, Button } from 'react-bootstrap';

// export class Login extends Component{
//     constructor(props){
//         super(props);
//         this.state={
//             UserNameOrEmail:"",
//             Password:"",
//             RememberMe:false,
//         }
//     }

//     render(){
//         return(
//             <div
//             className="container"
//             style={{
//                 position: 'relative',
//                 marginTop: "20px",
//                 padding: "30px",
//                 color: "white",
//                 minHeight: "100vh", // Full height
//             }}
//         >
//             {/* Background Video */}
//             <div style={{
//                 position: 'absolute',
//                 top: 0,
//                 left: 0,
//                 width: '100%',
//                 height: '100%',
//                 zIndex: -1, // Ensures the video stays behind the form
//                 overflow: 'hidden',
//             }}>
//                 <video
//                     autoPlay
//                     loop
//                     muted
//                     style={{
//                         position: 'absolute',
//                         top: '0',
//                         left: '0',
//                         width: '100%',
//                         height: '100%',
//                         objectFit: 'cover',
//                     }}
//                 >
//                     <source src="https://www.sca-muc.de/video_startseite/" type="video/mp4" />
//                     Your browser does not support the video tag.
//                 </video>
//             </div>
//                 <h1>Login</h1>
//                 <form onSubmit={this.onSubmit}>
//                     <div className="login-form">
//                         <label htmlFor="UserNameOrEmail">User Name or Email</label>
//                         <input type="text" className="form-control" id="UserNameOrEmail" value={this.state.UserNameOrEmail} onChange={(e) => this.setState({UserNameOrEmail:e.target.value})} />
//                     </div>
//                     <div className="form-group">
//                         <label htmlFor="Password">Password</label>
//                         <input type="password" className="form-control" id="Password" value={this.state.Password} onChange={(e) => this.setState({Password:e.target.value})} />
//                     </div>
//                     <div className="form-check">
//                         <input type="checkbox" className="form-check-input" id="RememberMe" checked={this.state.RememberMe} onChange={(e) => this.setState({RememberMe:e.target.checked})} />
//                         <label className="form-check-label" htmlFor="RememberMe">Remember Me</label>
//                     </div>
//                     <button type="submit" className="btn btn-primary">Login</button>
//                 </form>
//             </div>
//         )
//     }
// }



import React, { Component } from 'react';
import axios from 'axios';
import API_BASE_URL from '../../api/API_BASE_URL';
// Higher-order component to inject navigation prop
import { withNavigation } from '../../hoc/withNavigation';
import '../../custom.css';


export class Login extends Component {
    constructor(props) {
        
        super(props);
       

        this.state = {
            UserNameOrEmail: "",
            Password: "",
            RememberMe: false,
        };
        this.onChangeName = this.onChangeName.bind(this);
        this.onSubmit=this.onSubmit.bind(this);
    }
    

    onChangeName(e){
        this.setState({UserNameOrEmail:e.target.value});
    }


    onSubmit(e){
        e.preventDefault();
        //  const {history}=this.props;
        // const { navigate } = this.props;
        // Handle form submission logic here
        let LoginObject={
            UserNameOrEmail:this.state.UserNameOrEmail,
            Password:this.state.Password
        }

        axios.post(`${API_BASE_URL}/Login/LoginByEmailAndPassword`,LoginObject).then((response) => {
            // Handle successful login here
            //   history.push('./User');
            // navigate('/User'); // Redirect after successful login
            // console.log("Current URL:", this.props.location.pathname);
            // console.log("Route params:", this.props.params); 
            if (response.data) {
                localStorage.setItem('token', JSON.stringify(response.data));
                // localStorage.setItem('user', JSON.stringify(response.data));
                // history.push('/Home');
                 this.props.navigate('/User'); // Redirect after successful login
                // Redirect to the desired page after successful login
            } else {
                alert("Invalid credentials");
            }
        }).catch((error) => {
            console.error("Error during login:", error);
            alert("An error occurred. Please try again.");
        });
    }

    render() {
        return (
            <div 
                className="centered-container container-fluid"
                style={{
                    position: 'relative',
                    marginTop: "20px",
                    padding: "0", // Remove padding for better control
                    color: "white",
                    minHeight: "100vh", // Full height
                }}
            >
                {/* Background Video */}
                <div style={{
                    position: 'absolute',
                    top: 0,
                    left: 0,
                    width: '100%',
                    height: '100%',
                    zIndex: -1, // Ensures the video stays behind the form
                    overflow: 'hidden',
                }}>
                    <iframe
                        title="Background Video"
                        src="https://www.sca-muc.de/video_startseite/"
                        frameBorder="0"
                        allow="autoplay; fullscreen"
                        style={{
                            position: 'absolute',
                            top: '0',
                            left: '0',
                            width: '100%',
                            height: '100%',
                            objectFit: 'cover',
                            zIndex: -1,
                        }}
                    ></iframe>
                </div>

                {/* Login Form */}
                <div className="login-form" style={{
                    zIndex: 1, 
                    maxWidth: '400px', // Max width of the form
                    margin: 'auto', // Centers the form horizontally
                    padding: '20px',
                    backgroundColor: 'rgba(0, 0, 0, 0.7)', // Slightly darker semi-transparent background
                    borderRadius: '10px',
                    position: 'relative', // Ensure it's above the video
                }}>
                    <h1>Login</h1>
                    <form onSubmit={this.onSubmit}>
                        <div className="input-group flex-nowrap">
                            <span className="input-group-text" id="addon-wrapping">@</span>
                            <input type="text" value={this.state.UserNameOrEmail}
                                onChange={this.onChangeName}
                                className="form-control" placeholder="Email" aria-label="Username" 
                                aria-describedby="addon-wrapping"/>
                        </div>
                        <div className="form-group">
                            <label htmlFor="Password">Password</label>
                            <div className="col-auto">
                            <input type="password" id="Password" className="form-control" 
                                value={this.state.Password}
                                placeholder='Password'
                                aria-label="Password"
                                onChange={(e) => this.setState({ Password: e.target.value })}
                                aria-describedby="passwordHelpInline"/>
                          </div>
                        </div>
                        <div className="form-check">
                            <input
                                type="checkbox"
                                className="form-check-input"
                                id="RememberMe"
                                checked={this.state.RememberMe}
                                onChange={(e) => this.setState({ RememberMe: e.target.checked })}
                            />
                            <label className="form-check-label" htmlFor="RememberMe">Remember Me</label>
                        </div>
                        <button type="submit" className="btn btn-primary btn-block">Login</button>
                        <div className="d-flex justify-content-between mt-3">
                            <a href="/forgot-password" className="text-light">Forgot Password?</a>
                            <a href="/SignUp" className="text-light">Sign Up</a>
                            </div>
                    </form>
                </div>
            </div>
        );
    }
}

// Wrap the Login component with the navigation functionality
export default withNavigation(Login);
