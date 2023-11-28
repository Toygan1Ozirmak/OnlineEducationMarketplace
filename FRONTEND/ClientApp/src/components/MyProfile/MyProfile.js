import "./MyProfile.css";
import { useNavigate } from "react-router-dom";
import React, { useState } from "react";
import axios from "axios";
// import { registerUser } from "./apiServices";
//import search from "./images/search.jpg";
//import logo from "./images/logo.jpg";

const MyProfile = () => {
    const navigate = useNavigate();

    return (
        <div className="myprofile">
            <div className="MPprofilesection">
                <div className="MPsubmitrectangle" />
                <div className="MPsubmit-changes">Submit Changes</div>
                <div className="bio">Bio</div>
                <div className="biorectangle" />
                <div className="MPphoneNumber">Phone</div>
                <div className="MPphonerectangle" />
                <div className="MPmail">Mail</div>
                <div className="MPmailrectangle" />
                <div className="surname1">Surname</div>
                <div className="MPsurnamerectangle" />
                <div className="name1">Name</div>
                <div className="MPnamerectangle" />
            </div>
            {/*<img className="pp-1-icon" alt="" src="pp 1.png" />*/}
            <div className="my-profile">My Profile</div>
            <div className="section">
                <div className="notifications">Notifications</div>
                <div className="privacy">Privacy</div>
                <div className="payment-method">Payment Method</div>
                <div className="subscription">Subscription</div>
                <div className="security">Security</div>
                <div className="photo">Photo</div>
                <div className="profile">Profile</div>
            </div>
            <div className="header1">
                <div className="MPsearchrectangle" />
                <div className="basketrectangle1" />
                <div className="basket1">Basket (3)</div>
                <div className="header-child" />
                <div className="header-item" />
                <div className="header-inner" />
                <div className="line-div1" />
                <div className="MPcourses">Courses</div>
                {/*<img className="search-icon1" alt="" src={search} />*/}
                <div className="MPemapp" onClick={() => navigate("/")}>
                    EMAPP
                </div>
                {/*<img className="icon1" alt="" src={logo} />*/}
            </div>
        </div>
    );
};

export default MyProfile;