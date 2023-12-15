import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Button from "@mui/material/Button";
import { loginUser } from "../../apiServices";
import "./LoginPage.css";

const LoginPage = () => {
    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        UserName: "",
        Password: "",
    });

    const [loginError, setLoginError] = useState(false);

    const handleChange = (e) => {
        const { id, value } = e.target;
        setFormData({ ...formData, [id]: value });
        setLoginError(false); // Her değişiklikte login hatasını sıfırla
    };

    const handleSigninClick = async () => {
        try {
            const response = await loginUser(formData);

            if (response && response.token) {
                // Token varsa
                localStorage.setItem("isLoggedIn", "true");
                console.log("Giriş Başarılı");
                console.log(response.token);
                navigate("/homepage");
                
                
            } else {
                console.error("Token not found in the response.");
                setLoginError(true);
            }
        } catch (error) {
            console.error("Error during login:", error);
            
        }
    };



    return (
        <div className="loginpage">
            <div className="loginbody">
                <Button className="Loginsignin" onClick={handleSigninClick}>
                    Signin
                </Button>

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
                        type="password"
                        id="Password"
                        className="Password"
                        value={formData.Password}
                        onChange={handleChange}
                    />
                </div>
                {loginError && (
                    <div className="login-error">Invalid credentials. Please try again.</div>
                )}
                <div className="please-log-in">Please log in into your account</div>
                <b className="Loginsign-in">Sign in</b>
            </div>
            
        </div>
    );
};

export default LoginPage;
