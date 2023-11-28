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
        name: "",
        surname: "",
        password: "",
        mail: "",
        phone: "",
    });

    const handleChange = (e) => {
        const { id, value } = e.target;
        setFormData({ ...formData, [id]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await registerUser(formData);
            console.log("Data saved:", response);
            // Handle success or further actions upon successful API call
        } catch (error) {
            console.error("Error saving data:", error);
        }
    };

    const navigate = useNavigate(); // Uncommented navigation component

    const handleSignupClick = () => {
        console.log("Signup button clicked!");
        navigate("/myprofile");
    };

    return (
        <div className="register">
            <form onSubmit={handleSubmit}>
                <div className="input-container">
                    <label htmlFor="name" id="nameLabel">
                        Name
                    </label>
                    <input
                        type="text"
                        id="name"
                        className="name"
                        value={formData.firstName}
                        onChange={handleChange}
                    />
                </div>

                <div className="input-container">
                    <label htmlFor="surname" id="surnameLabel">
                        Surname
                    </label>
                    <input
                        type="text"
                        id="surname"
                        className="surname"
                        value={formData.surname}
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
                    <label htmlFor="mail" id="mailLabel">
                        Mail
                    </label>
                    <input
                        type="text"
                        id="mail"
                        className="mail"
                        value={formData.mail}
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

                {/* Commented out button component */}
                <button type="submit">Register</button>

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
                <div className="Registeremapp" onClick={() => { navigate("/") }}>
                    EMAPP
                </div>
                <input type="text" className="searchrectangle" onChange={handleChange} />
                {/* Commented out logo component */}
                {/* <img src={logo} className="icon" alt="" /> */}
                {/* Commented out search icon component */}
                {/* <img src={search} className="searchIcon" alt="" /> */}

                <div className="register-child" />
                <div className="register-item" />
                <div className="register-inner" />
                <div className="courses" onClick={() => { navigate("/courses") }}>
                    <h2>Courses</h2>
                </div>
            </form>
        </div>
    );
};

export default Register;