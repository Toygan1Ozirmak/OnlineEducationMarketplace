import "./HomePage.css";
import { useNavigate } from "react-router-dom";
import React, { useState } from "react";
import axios from "axios";
import Button from "@mui/material/Button"; // Import the API service function
//import study from "./images/study.PNG";
//import eng from "./images/Eng.jpg";
//import psy from "./images/psy.jpg";
//import art from "./images/art.jpg";
//import lan from "./images/lan.jpg";
//import acc from "./images/acc.jpg";
//import sci from "./images/sci.jpg";
//import search from "./images/search.jpg";
//import logo from "./images/logo.jpg";

const HomePage = () => {
    const navigate = useNavigate();

    return (
        <div className="homepage">
            <div className="about-us">
                <div className="studyrectangle" />
                <div className="welcome">
                    <div className="welcome-to-oemapp-container">
                        <p className="to">{`Welcome `}</p>
                        <p className="to">{`to `}</p>
                        <p className="to">OEMAPP</p>
                    </div>
                    <div className="sign-up-now-container">
                        <p className="to">
                            Sign up now for the most suitable training among thousands of
                            trainings with OEAMPP, and take yourself one step further with
                            live lessons and courses!
                        </p>
                        <p className="to">&nbsp;</p>
                    </div>
                </div>
                <div className="ourmission">
                    <div className="our-mission">our mission</div>
                    <div className="hundreds-of-instructors">
                        Hundreds of instructors and students were brought together on the
                        same platform. Take your place now!
                    </div>
                </div>
                <div className="infoframe">
                    <div className="experience">
                        <div className="div">10+</div>
                        <div className="years-experience">Years Experience</div>
                    </div>
                    <div className="coursesnumber">
                        <div className="div">29+</div>
                        <div className="years-experience">
                            <p className="to">{`Total `}</p>
                            <p className="to">Course</p>
                        </div>
                    </div>
                    <div className="studentsnumber">
                        <div className="div">50K+</div>
                        <div className="student-active">
                            <p className="to">{`Student `}</p>
                            <p className="to">Active</p>
                        </div>
                    </div>
                </div>
            </div>
            {/*<img src={study} className="study-image" alt="" />*/}

            <button className="browseButton" onClick={() => navigate("/shop")}>
                Browse
            </button>
            <div className="achieve-success-by">
                Achieve success by learning the latest competencies
            </div>
            
            <div className="ourcourse">
                <div className="explore-our-categories">
                    Explore Our Categories Your Path to Success
                </div>
                <div className="scirectangle" />
                <div className="science">Science</div>
                {/*<img className="sci-icon" alt="" src={sci} />*/}
                <div className="accorectangle" />
                <div className="accountancy">Accountancy</div>
                {/*<img className="acc-icon" alt="" src={acc} />*/}
                <div className="languagerectangle" />
                <div className="language">Language</div>
                {/*<img className="lan-icon" alt="" src={lan} />*/}
                <div className="fineartrectangle" />
                <div className="fine-arts">Fine Arts</div>
                {/*<img className="art-icon" alt="" src={art} />*/}
                <div className="psyrectangle" />
                <div className="psychology">Psychology</div>
                {/*<img className="psy-icon" alt="" src={psy} />*/}
                <div className="engineeringrectangle" />
                <div className="engineering">Engineering</div>
                {/*<img className="engineeringimage-icon" alt="" src={eng} />*/}
            </div>
        </div>
    );
};

export default HomePage;