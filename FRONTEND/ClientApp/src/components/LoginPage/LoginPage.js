// import search from "./images/search.jpg";
// import logo from "./images/logo.jpg";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Button from "@mui/material/Button"; // Import the API service function
import "./LoginPage.css";
import { loginUser } from "../../apiServices";

const LoginPage = () => {
    const navigate = useNavigate();

    const [checked, setChecked] = React.useState(false);
    function checkChange(e) {
        setChecked(e.target.checked);
    }
    const [formData, setFormData] = useState({
        UserName: "",
        Password: "",
    });

    const handleChange = (e) => {
        const { id, value } = e.target;
        setFormData({ ...formData, [id]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (!formData.UserName || !formData.Password) {
            console.error("Form data is incomplete. All fields are required.");
            return;
        }

        try {
            const response = await loginUser(formData);
            console.log("Data saved:", response);
            // Handle success or further actions upon successful API call
        } catch (error) {
            console.error("Error saving data:", error);
        }
    };

   
    const handleSigninClick = async () => {
        console.log("Signin button clicked!");
        try {
            const response = await loginUser(formData);
            console.log("Data saved:", response);

            // Assuming a successful response contains a token
            if (response && response.token) {
                navigate("/shop");
            } else {
                // Optional: Show an error message for invalid credentials
                console.error("Invalid credentials. Please try again.");
            }
        } catch (error) {
            console.error("Error saving data:", error);
            // Handle error, show a message, etc.
        }
    };

    return (
        <div className="loginpage">
            <div className="loginbody">
                <div>
                    <Button className="Loginsignin" onClick={handleSigninClick}>
                        Signin
                    </Button>
                </div>
                <div
                    className="forgot-password"
                    onClick={() => navigate("/changepassword")}
                >
                    Forgot password?
                </div>

                <div className="LoginInput-container">
                    <label htmlFor="UserName" id="UserNamelabel">
                        Username
                    </label>
                    <input
                        type="text"
                        id="UserName"
                        className="UserName"
                        value={formData.UserName}
                        onChange={handleChange}
                    />
                </div>
                <div className="LoginInput-container">
                    <label htmlFor="Password" id="Passwordlabel">
                        Password
                    </label>
                    <input
                        type="Password"
                        id="Password"
                        className="Password"
                        value={formData.Password}
                        onChange={handleChange}
                    />
                </div>
                <div className="please-log-in">Please log in into your account</div>
                <b className="Loginsign-in">Sign in</b>
            </div>
            <div className="header">
                <div className="loginemapp" onClick={() => navigate("/")}
                >
                    EMAPP
                </div>
                <div className="loginsearchrectangle" />
                {/* <img className="Loginicon" alt="" src={logo} />
        <img className="loginsearchimage-icon" alt="" src={search} /> */}
                <div className="loginregister">{`Courses `}</div>
                <div className="logincourses">Login</div>
                <div className="logincourses1">{`Courses `}</div>
            </div>
        </div>
    );
};

export default LoginPage;