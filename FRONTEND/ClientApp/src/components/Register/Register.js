// Register.js
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import { registerUser } from "../../apiServices";
import "./Register.css";

const Register = () => {
    const [checked, setChecked] = useState(false); // Burada setChecked fonksiyonunu ekledik.

    const [formData, setFormData] = useState({
        firstName: "",
        lastName: "",
        password: "",
        email: "",
        phone: "",
        username: "",
        userBio: "",
    });

    const handleChange = (e) => {
        const { id, value } = e.target;
        setFormData({ ...formData, [id]: value });
    };

    const checkChange = (e) => {
        setChecked(e.target.checked);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        // Form validation logic can be added here

        try {
            const response = await registerUser(formData);
            console.log("Data saved:", response);
            // Handle success or further actions upon successful API call
        } catch (error) {
            console.error("Error saving data:", error);
            // Handle error, show a message, etc.
        }
    };

    const navigate = useNavigate();

    const handleSignupClick = async () => {
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
        <div className="register-container">
            <div className="register-body">
                <img
                    src="https://toygantestbucket.s3.eu-central-1.amazonaws.com/monovi-logo-grey.png"
                    alt="Monovi Logo"
                    className="logo-image"
                />
                <h2 className="register-title">Create a new account</h2>
                <Form onSubmit={handleSubmit}>
                    <div className="input-container">
                        <label htmlFor="firstName">First Name</label>
                        <input
                            type="text"
                            id="firstName"
                            className="firstName"
                            value={formData.firstName}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="input-container">
                        <label htmlFor="lastName">Last Name</label>
                        <input
                            type="text"
                            id="lastName"
                            className="lastName"
                            value={formData.lastName}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="input-container">
                        <label htmlFor="password">Password</label>
                        <input
                            type="password"
                            id="password"
                            className="password"
                            value={formData.password}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="input-container">
                        <label htmlFor="email">Email</label>
                        <input
                            type="text"
                            id="email"
                            className="email"
                            value={formData.email}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="input-container">
                        <label htmlFor="phone">Phone</label>
                        <input
                            type="text"
                            id="phone"
                            className="phone"
                            value={formData.phone}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="input-container">
                        <label htmlFor="username">Username</label>
                        <input
                            type="text"
                            id="username"
                            className="username"
                            value={formData.username}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="input-container">
                        <label htmlFor="userBio">User Bio</label>
                        <input
                            type="text"
                            id="userBio"
                            className="userBio"
                            value={formData.userBio}
                            onChange={handleChange}
                        />
                    </div>

                     <div className="policy">
                        <label>
                            <input
                                type="checkbox"
                                className="checkBox"
                                onChange={checkChange}
                            />
                            Agree to the terms of use and privacy policy
                        </label>
                    </div>

                    <Button variant="danger" className="signup" onClick={handleSignupClick}>
                        Signup
                    </Button>

                   

                    {/*<div className="please-create-a">Please create a new account</div>*/}
                    {/*<b className="sign-up1">*/}
                    {/*    <p className="sign-up2">Sign up</p>*/}
                    {/*</b>*/}
                </Form>
            </div>
        </div>
    );
};

export default Register;
