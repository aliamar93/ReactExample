import React,{useState} from 'react';
import '../../bootstrap.min.css';
import axios from 'axios';
import API_BASE_URL from '../../api/API_BASE_URL';
// import AlertModal from '../../components/Modal/AlertModal';
import '../../custom.css';
import { toast } from 'react-toastify';

const Profile=()=>{
    // const [showAlert, setShowAlert] = useState(false);

//   const triggerAlert = () => setShowAlert(true);
//   const handleClose = () => setShowAlert(false);
//   const handleRetry = () => {
//     console.log('Retrying...');
//     setShowAlert(false);
//   };

    const[formData,setFormData]=useState({
        fullName:'',
        lastName:'',
        gender:'',
        dateOfBirth:'',
        email:'',
        personalNr:'',
        image:null,
        imagePreview:'',
        phone:'',
        userName:'',
        password:''
    });

    const roles=["Admin","User","Manager","Packer","Picker"];

    const handleChange=(e)=>{
        const {name,value}=e.target;
        setFormData({
            ...formData,
            [name]:value
        });
    }

    // const handleRetry = () => {
    //     // Retry logic here
    //     console.log('Retry clicked');
    //     setShowAlert(false);
    //   };

    const handleImageChange=(e)=>{
        console.log("Image Changed",e.target.files[0]);
        // toast("This is a basic toast!");
        // toast.success("Profile saved successfully!");
        // toast.error("Something went wrong!");
        // toast.info("Info message here");
        
        // setShowAlert(true);

        // Check if a file is selected
        const file=e.target.files[0];
        if(file){
        //    formData.image=URL.createObjectURL(file);
            // if(file && file.type.startsWith('image/')){
            const reader=new FileReader();

            reader.onloadend=()=>{
                setFormData({
                    ...formData,
                    image:file,
                    imagePreview:reader.result
                });
            };
            reader.readAsDataURL(file);
        }
    }

    const handleSubmit=(e)=>{
        try{
            e.preventDefault();
        const token =JSON.parse(localStorage.token).token; // Make sure the token is stored properly
        formData.image=formData.imagePreview;
        // Handle form submission logic here
        // For example, you can send the form data to an API endpoint using axios or fetch.
        const formDataToSubmit=new FormData();
        for(const key in formData){
            formDataToSubmit.append(key,formData[key]);
        }
        // You can handle form submission logic here, like sending data to an API or processing it further.
        // Example: Sending form data to an API endpoint
        axios.post(`${API_BASE_URL}/User/AddUser`,JSON.stringify(formData) ,{
            headers:{
                // 'Content-Type':'multipart/form-data'
                  'Content-Type': 'application/json',
                  Authorization: `Bearer ${token.replace(/"/g, '')}` // Remove quotes if stored with JSON.stringify
            }
        })
        .then(response=>{
            toast("Form submitted successfully", {
                position: "bottom-left",
                type: "success",
                autoClose: 5000,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
              });
            // console.log("Form submitted successfully",response.data);
            // Handle success response

        });
        }
        catch(error){
            console.error("Error during form submission:", error);
            toast("Error during form submission", {
                position: "bottom-left",
                type: "error",
                autoClose: 5000,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
              });
            // Handle error response
        }
        
    }


    return(
       <>
        
      {/* <h2>Example Form</h2>
      <button className="btn btn-danger" onClick={triggerAlert}>
        Show Alert
      </button> */}

        {/* {<AlertModal show={showAlert}  onClose={handleClose} onRetry={handleRetry}/> } */}
    
        <div className="container py-2 profile-form text-dark bg-white rounded shadow-lg animate__animated animate__fadeIn">
            {/* <h2 className="text-center text-danger mb-4">Profile Form</h2> */}
            <form onSubmit={handleSubmit}>
                <div className="text-center mb-4">
                    <label htmlFor="imageUpload" className="image-upload-label">
                        <div className="profile-pic-wrapper">
                            <img
                                src={formData.imagePreview || '/Images/Profile.png'}
                                className="rounded-circle profile-pic border border-danger"
                                alt="Profile"
                            />
                        </div>
                        <input
                            type="file"
                            id="imageUpload"
                            accept="image/*"
                            onChange={handleImageChange}
                            hidden
                        />
                    </label>
                    <small className="d-block text-muted">Click image to upload</small>
                </div>

                <div className="row g-3">
                    {[
                        { label: 'First Name', name: 'firstName', type: 'text' },
                        { label: 'Last Name', name: 'lastName', type: 'text' },
                        { label: 'Personal Number', name: 'personalNr', type: 'text' },
                        { label: 'Email', name: 'email', type: 'email' },
                        { label: 'User Name', name: 'userName', type: 'text' },
                        { label: 'Password', name: 'password', type: 'password' },
                        { label: 'Date of Birth', name: 'dateOfBirth', type: 'date' },
                        { label: 'Phone', name: 'phone', type: 'tel' },
                        { label: 'Address', name: 'address', type: 'textarea' },
                        // { label: 'Skills', name: 'skills', type: 'text' },
                    ].map(({ label, name, type }) => (
                        <div className="col-md-4" key={name}>
                            <label className="form-label">{label}</label>
                            <input
                                type={type}
                                name={name}
                                className="form-control border-danger"
                                required
                                value={formData[name]}
                                onChange={handleChange}
                            />
                        </div>
                    ))}

                    <div className="col-md-4">
                        <label className="form-label">Gender</label>
                        <select
                            className="form-select border-danger"
                            name="gender"
                            value={formData.gender}
                            onChange={handleChange}
                            required
                        >
                            <option value="">Select Gender</option>
                            <option value="Male">Male</option>
                            <option value="Female">Female</option>
                        </select>
                    </div>

                    <div className="col-md-4">
                        <label className="form-label">Role</label>
                        <select
                            className="form-select border-danger"
                            name="role"
                            value={formData.role}
                            onChange={handleChange}
                            required
                        >
                            <option value="">Select Role</option>
                            {roles.map((role, idx) => (
                                <option key={idx} value={role}>{role}</option>
                            ))}
                        </select>
                    </div>
                </div>

                <div className="text-center mt-4">
                    <button type="submit" className="btn btn-primary px-4 py-2">
                        Submit
                    </button>
                </div>
            </form>
        </div>
    </>
);
};

export default Profile;