import React ,{Component} from 'react';
// import axios from 'axios';
import API_BASE_URL from '../../api/API_BASE_URL';


export class User extends Component{
    constructor(props){
        super(props);
        this.state={
            user:[],
            loading:true
        };
    }


    componentDidMount() {
        this.populateUserData();
      }
    renderAllUserTable(user){
        return(
            <table className="table table-striped table-bordered">
                <thead>
                    <tr>
                        <th>Personal Nr</th>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    {user.map(user => (
                        <tr key={user.id}>
                            <td>{user.personalNr}</td>
                            <td>{user.firstName+' '+user.lastName}</td>
                            <td>{user.email == null ?user.userName:user.email }</td>
                            <td>{(user.status== null ?"Working":"Urlaub")}</td>
                        </tr>
                    ))}
                </tbody>
                </table>
        )
    }

    render(){

        let content=this.state.loading ? (
        <p>
            <em>
                <img src="/Images/under_construction_sign.jpg" alt="Loading..." />
            </em>
        </p>
    ):(
            this.renderAllUserTable(this.state.user)
    )

        return(
            <div>
                <h1>Users</h1>
                <p>List of users</p>
                {content}

                {/* <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>User ID</th>
                            <th>Name</th>
                            <th>Email</th>
                            <th>Phone</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.user.map(user => (
                            <tr key={user.id}>
                                <td>{user.id}</td>
                                <td>{user.name}</td>
                                <td>{user.email}</td>
                                <td>{user.phone}</td>
                            </tr>
                        ))}
                    </tbody>
                    </table> */}
            </div>
        );
    }
    async populateUserData() {

        // axios.get("https://localhost:7002/api/User/GetUsers")
        // .then(response =>{
        //     var data=response.data;
        //     console.log(data);
        //     this.setState({user:response.data,loading:false})
        // });

        try {
            // const token = localStorage.getItem("token");
            const token =JSON.parse(localStorage.token).token; // Make sure the token is stored properly
            const response = await fetch(`${API_BASE_URL}/User/GetUsers`, {
              method: "GET",
              headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${token.replace(/"/g, '')}` // Remove quotes if stored with JSON.stringify
              },
            });
            if (!response.ok) throw new Error("Failed to fetch users.");
            const data = await response.json();
            // console.log(data);
            // const data = response.data;
            this.setState({ user: data, loading: false });
          } catch (error) {
            console.error("Error:", error);
            this.setState({ loading: false });
          }
      }
}