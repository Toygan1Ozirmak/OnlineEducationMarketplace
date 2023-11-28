import "./ChangePassword.css";
//import search from "./images/search.jpg";
//import logo from "./images/logo.jpg";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { changePasswordUser } from "../../apiServices";

const ChangePassword = () => {
    const navigate = useNavigate();

    const [checked, setChecked] = React.useState(false);
    function checkChange(e) {
        setChecked(e.target.checked);
    }
    const [formData, setFormData] = useState({
        changepasswordmail: "",
        reelpassword: "",
        confirmpassword: "",
    });

    const handleChange = (e) => {
        const { id, value } = e.target;
        setFormData({ ...formData, [id]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await changePasswordUser(formData); // Call the API service function
            console.log("Data saved:", response);
            // Handle success or further actions upon successful API call
        } catch (error) {
            console.error("Error saving data:", error);
        }
    };
    return (
        <div className="changepassword">
            <b className="change-password">
                <span className="change-password-txt-container">
                    <p className="change">Change</p>
                    <p className="change">Password</p>
                </span>
            </b>
            <div className="changepasswordboxes">
                <div class="PasswordInput-container">
                    <label htmlFor="changepasswordmail" id="changepasswordmaillabel">
                        Mail
                    </label>
                    <input
                        type="text"
                        id="changepasswordmail"
                        className="changepasswordmail"
                        value={formData.changepasswordmail}
                        onChange={handleChange}
                    />
                </div>

                <div class="PasswordInput-container">
                    <label htmlFor="reelpassword" id="reelpasswordlabel">
                        Password
                    </label>
                    <input
                        type="text"
                        id="reelpassword"
                        className="reelpassword"
                        value={formData.reelpassword}
                        onChange={handleChange}
                    />
                </div>

                <div class="PasswordInput-container">
                    <label htmlFor="confirmpassword" id="confirmpasswordlabel">
                        Confirm Password
                    </label>
                    <input
                        type="text"
                        id="confirmpassword"
                        className="confirmpassword"
                        value={formData.confirmpassword}
                        onChange={handleChange}
                    />
                </div>

                <div className="submitchangesrectangle" />
                <div className="submitchanges">Submit Changes</div>
            </div>
            <header className="changepasswordheader" id="Header">
                <div className="changepasswordheaderrectangle" />
                <div className="changepasswordemapp" onClick={() => navigate("/")}>
                    EMAPP
                </div>
                <div className="changepasswordsearchrectangle" />
                {/*<img className="changepasswordlogo-icon" alt="" src={logo} />*/}
                {/*<img className="changepasswordsearchicon" alt="" src={search} />*/}
                <div className="changepasswordregister">Register</div>
                <div className="changepasswordlogin">Login</div>
                <div className="changepasswordcourses">Courses</div>
                <div className="changepasswordsearch">search</div>
            </header>
        </div>
    );
};

export default ChangePassword;