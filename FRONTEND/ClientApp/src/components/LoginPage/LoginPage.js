import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
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

    const handleRegisterClick = () => {
        // /register sayfasına yönlendirme
        navigate("/register");
    };


    return (
        <div className="login-container">
            <div className="login-body">
                 <img
                    src="https://toygantestbucket.s3.eu-central-1.amazonaws.com/monovi-logo-grey.png"
                    alt="Monovi Logo"
                    className="logo-image"
                />
                <h2 className="login-title">Please log in to your account</h2>
                <Form>
                    <Form.Group className="mb-4" controlId="UserName">
                        <Form.Label>Username</Form.Label>
                        <Form.Control
                            type="text"
                            value={formData.UserName}
                            onChange={handleChange}
                            placeholder="Enter your username"
                        />
                    </Form.Group>

                    <Form.Group className="mb-4" controlId="Password">
                        <Form.Label>Password</Form.Label>
                        <Form.Control
                            type="password"
                            value={formData.Password}
                            onChange={handleChange}
                            placeholder="Enter your password"
                        />
                    </Form.Group>

                    <Button variant="danger" onClick={handleSigninClick} className="login-signin">
                        Sign In
                    </Button>

                    <div className="register-link">
                        <p>Don't have an account?</p>
                        <Button variant="link" onClick={handleRegisterClick}>
                            Register
                        </Button>
                    </div>
                </Form>

                {loginError && <div className="login-error">Invalid credentials. Please try again.</div>}
                
            </div>
        </div>
    );
};

export default LoginPage;