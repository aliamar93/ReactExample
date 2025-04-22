import React, { Component } from 'react';
import axios from 'axios';
import API_BASE_URL from '../../api/API_BASE_URL';
import withNavigation from '../../hoc/withNavigation';// Higher-order component to inject navigation prop
import '../../custom.css';
import { toast } from 'react-toastify';


export class SignUp extends Component {
    
    constructor(props) {
        super(props);
        this.state = {
            UserNameOrEmail: "",
            Password: "",
            ConfirmPassword: "",
            RememberMe: false,
        };
        this.onChangeName = this.onChangeName.bind(this);
        this.onChangeConfirmPassword = this.onChangeConfirmPassword.bind(this);
        this.onSubmit=this.onSubmit.bind(this);
    }    

    onChangeName(e){
        this.setState({UserNameOrEmail:e.target.value});
    }
    onChangeConfirmPassword(e){
        if(e.target.value === this.state.Password)
        {
            this.setState({ConfirmPassword:e.target.value});
        }
        else
        {
            toast("Password and Confirm Password do not match");
        }
    }

    onSubmit(e){
        e.preventDefault();
        // const {history}=this.props;
        // Handle form submission logic here
        let LoginObject={
            UserNameOrEmail:this.state.UserNameOrEmail,
            Password:this.state.Password
        }

        axios.post(`${API_BASE_URL}/Login/SignUpByEmailAndPassword`,LoginObject).then((response) => {
            // Handle successful login here
            //  history.push('./Login');
            console.log(response.data);
            if (response.data) {
                localStorage.setItem('token', JSON.stringify(response.data));
                // localStorage.setItem('user', JSON.stringify(response.data));
                // this.props.history.push('./Login');
                this.props.navigate('/Profile'); // Redirect after successful login
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
                    <h1>Sign Up</h1>
                    <form onSubmit={this.onSubmit}>
                        <div className="form-group">
                            <label htmlFor="UserNameOrEmail">User Name or Email</label>
                            <input
                                type="text"
                                className="form-control"
                                id="UserNameOrEmail"
                                value={this.state.UserNameOrEmail}
                                onChange={this.onChangeName}
                                // onChange={(e) => this.setState({ UserNameOrEmail: e.target.value })}
                                placeholder="username or email"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="Password">Password</label>
                            <input
                                type="password"
                                className="form-control"
                                id="Password"
                                value={this.state.Password}
                                onChange={(e) => this.setState({ Password: e.target.value })}
                                placeholder="Password"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="ConfirmPassword">Confirm Password</label>
                            <input
                                type="password"
                                className="form-control"
                                id="ConfirmPassword"
                                value={this.state.ConfirmPassword}
                                onChange={this.onChangeConfirmPassword}
                                placeholder="Confirm Password"
                            />
                        </div>
                        <button type="submit" className="btn btn-primary btn-block">Sign Up</button>
                    </form>
                </div>
            </div>
        );
    }
}

// Wrap the Login component with the navigation functionality
export default withNavigation(SignUp);