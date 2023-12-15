import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Button from "@mui/material/Button";
import "./Register.css";
import { registerUser } from "../../apiServices";

const Register = () => {
    const [checked, setChecked] = useState(false);
    function checkChange(e) {
        setChecked(e.target.checked);
    }

    const [formData, setFormData] = useState({
        firstName: "",
        lastName: "",
        password: "",
        email: "",
        phone: "",
        username: "",
        userBio: "",
        roles: ["Instructor"],

    });

    const handleChange = (e) => {
        const { id, value } = e.target;
        setFormData({ ...formData, [id]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (!formData.firstName || !formData.lastName || !formData.password || !formData.email || !formData.phone || !formData.username || !formData.userBio) {
            console.error("Form data is incomplete. All fields are required.");
            return;
        }
        
        try {
            const response = await registerUser(formData);
            console.log("Data saved:", response);
            // Handle success or further actions upon successful API call
        } catch (error) {
            console.error("Error saving data:", error);
        }
    };

    const navigate = useNavigate(); // Uncommented navigation component

    const handleSignupClick = async () => {
        console.log("Signup button clicked!");

        

        try {
            const response = await registerUser(formData);
            console.log("Data saved:", response);
            // Handle success or further actions upon successful API call
            navigate("/login");
        } catch (error) {
            console.error("Error saving data:", error);
            // Handle error, show a message, etc.
        }
    };

    return (
        <div className="register">
            <form onSubmit={handleSubmit}>
                <div className="input-container">
                    <label htmlFor="firstName" id="firstNameLabel">
                        Firstname
                    </label>
                    <input
                        type="text"
                        id="firstName"
                        className="firstName"
                        value={formData.firstName}
                        onChange={handleChange}
                    />
                </div>

                <div className="input-container">
                    <label htmlFor="lastName" id="lastNameLabel">
                        Lastname
                    </label>
                    <input
                        type="text"
                        id="lastName"
                        className="lastName"
                        value={formData.lastName}
                        onChange={handleChange}
                    />
                </div>
                <div className="input-container">
                    <label htmlFor="password" id="passwordLabel">
                        Password
                    </label>
                    <input
                        type="password"
                        id="password"
                        className="password"
                        value={formData.password}
                        onChange={handleChange}
                    />
                </div>

                <div className="input-container">
                    <label htmlFor="email" id="emailLabel">
                        EMail
                    </label>
                    <input
                        type="text"
                        id="email"
                        className="email"
                        value={formData.email}
                        onChange={handleChange}
                    />
                </div>
                <div className="input-container">
                    <label htmlFor="phone" id="phoneLabel">
                        Phone
                    </label>
                    <input
                        type="text"
                        id="phone"
                        className="phone"
                        value={formData.phone}
                        onChange={handleChange}
                    />
                </div>
                <div className="input-container">
                    <label htmlFor="username" id="usernameLabel">
                        Username
                    </label>
                    <input
                        type="text"
                        id="username"
                        className="username"
                        value={formData.username}
                        onChange={handleChange}
                    />
                </div>
                <div className="input-container">
                    <label htmlFor="userBio" id="userBioLabel">
                        UserBio
                    </label>
                    <input
                        type="text"
                        id="userBio"
                        className="userBio"
                        value={formData.userBio}
                        onChange={handleChange}
                    />
                </div>

             
                <div>
                    {/* Uncommented Button component with navigation function */}
                    <Button className="signup" onClick={handleSignupClick}>
                        Signup
                    </Button>
                </div>

                <div>
                    <div className="policy">Agree the terms of use and privacy policy</div>
                    <input
                        value="test"
                        type="checkbox"
                        className="checkBox"
                        onChange={checkChange}
                    />
                </div>

                <div className="please-create-a">Please create a new account</div>
                <b className="sign-up1">
                    <p className="sign-up2">Sign up</p>
                </b>
                
            </form>
        </div>
    );
};

export default Register;