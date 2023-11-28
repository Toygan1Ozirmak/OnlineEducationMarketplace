import "./LoginPage.css";
import { useNavigate } from "react-router-dom";
import React, { useState } from "react";
// import search from "./images/search.jpg";
// import logo from "./images/logo.jpg";
import { loginUser } from "../../apiServices";
import Button from "@mui/material/Button"; // Import the API service function

const LoginPage = () => {
    const navigate = useNavigate();

    const [checked, setChecked] = React.useState(false);
    function checkChange(e) {
        setChecked(e.target.checked);
    }
    const [formData, setFormData] = useState({
        loginmail: "",
        loginpassword: "",
    });

    const handleChange = (e) => {
        const { id, value } = e.target;
        setFormData({ ...formData, [id]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await loginUser(formData); // Call the API service function
            console.log("Data saved:", response);
            // Handle success or further actions upon successful API call
        } catch (error) {
            console.error("Error saving data:", error);
        }
    };

    const handleSigninClick = () => {
        console.log("Signin button clicked!");
        // Redirect to MyProfile page
        navigate("/");
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
                    <label htmlFor="loginmail" id="loginmaillabel">
                        Mail
                    </label>
                    <input
                        type="text"
                        id="loginmail"
                        className="loginmail"
                        value={formData.loginmail}
                        onChange={handleChange}
                    />
                </div>
                <div className="LoginInput-container">
                    <label htmlFor="loginpassword" id="loginpasswordlabel">
                        Password
                    </label>
                    <input
                        type="text"
                        id="loginpassword"
                        className="loginpassword"
                        value={formData.loginpassword}
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