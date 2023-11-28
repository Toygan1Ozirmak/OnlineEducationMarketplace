import "./Shop.css";
import React, { useState } from "react";
import Button from "@mui/material/Button"; // Import the API service function
import { useNavigate } from "react-router-dom";
//import search from "./images/search.jpg";
//import logo from "./images/logo.jpg";

const Shop = () => {
    const navigate = useNavigate();

    return (
        <div className="shop">
            <div className="view-all">
                <div className="view-all-child" />
                <div className="view-all1">{`View All `}</div>
            </div>
            <div className="shopcourses">
                <div className="webdevwithc">
                    <div className="frame-parent">
                        <div className="machine-learning-wrapper">
                            <i className="machine-learning">Web Development</i>
                        </div>
                        <div className="basic-data-structure-and-algor-wrapper">
                            <i className="basic-data-structure-and">{`Developing web applications `}</i>
                        </div>
                        {/*<img className="logo-icon" alt="" src="Logo.png" />*/}
                    </div>
                    <div className="machine-learning-and-data-anal-parent">
                        <i className="machine-learning-and">Web Development with C#</i>
                        <div className="copyright-parent">
                            {/*<img className="copyright-icon" alt="" src="copyright.svg" />*/}
                            <i className="shams-tabrez">Shams Tabrez</i>
                        </div>
                        <i className="lessons-7">12 lessons • 7 quiz</i>
                    </div>
                </div>
                <div className="fundamentalsiot">
                    <div className="school">
                        {/*<img className="school-icon" alt="" src="school.svg" />*/}
                    </div>
                    <i className="fundamental-to-iot">Fundamental to IoT</i>
                    <i className="overview-of-available">
                        Overview of available development boards
                    </i>
                    <div className="lessons-parent">
                        <i className="shams-tabrez">5 lessons</i>
                        <i className="i">•</i>
                        <i className="shams-tabrez">4 quizes</i>
                    </div>
                    <div className="copyright-group">
                        {/*<img className="copyright-icon" alt="" src="copyright.svg" />*/}
                        <i className="shams-tabrez">Shams Tabrez</i>
                    </div>
                </div>
                <div className="mlandda">
                    <div className="frame-parent">
                        <div className="machine-learning-wrapper">
                            <i className="machine-learning">
                                <span>M</span>
                                <span className="achine">{`achine `}</span>
                                <span>L</span>
                                <span className="achine">earning</span>
                            </i>
                        </div>
                        <div className="basic-data-structure-and-algor-wrapper">
                            <i className="basic-data-structure-and-container">
                                <p className="algorithm">Basic data-structure and</p>
                                <p className="algorithm">algorithm</p>
                            </i>
                        </div>
                        {/*<img className="logo-icon" alt="" src="Logo.png" />*/}
                    </div>
                    <div className="machine-learning-and-data-anal-parent">
                        <i className="machine-learning-and1">
                            Machine Learning and Data analysis
                        </i>
                        <div className="copyright-parent">
                            {/*<img className="copyright-icon" alt="" src="copyright.svg" />*/}
                            <i className="shams-tabrez">Shams Tabrez</i>
                        </div>
                        <i className="lessons-7">12 lessons • 7 quiz</i>
                    </div>
                </div>
            </div>
            <div className="shopcategoriesframe">
                <div className="all">
                    <div className="shopall">
                        <div className="machinelearningtext">All</div>
                    </div>
                </div>
                <div className="machinelearning">
                    <div className="shopall">
                        <div className="machinelearningtext">Machine Learning</div>
                    </div>
                </div>
                <div className="machinelearning">
                    <div className="shopall">
                        <div className="machinelearningtext">UI/UX</div>
                    </div>
                </div>
                <div className="machinelearning">
                    <div className="shopall">
                        <div className="machinelearningtext">English</div>
                    </div>
                </div>
                <div className="machinelearning">
                    <div className="shopall">
                        <div className="machinelearningtext">Biology</div>
                    </div>
                </div>
            </div>
            <div className="shopcategories">Categories</div>
            <header className="shopheader" id="Header">
                <div className="changepasswordheaderrectangle" />
                <div className="changePasswordemapp" onClick={() => navigate("/")}>
                    EMAPP
                </div>
                <input className="changepasswordsearchrectangle" type="text" />
                {/*<img className="changepasswordlogo-icon" alt="" src={logo} />*/}
                {/*<img className="changepasswordsearchicon" alt="" src={search} />*/}

                <div className="changepasswordcourses">Courses</div>
                <button className="shopbasketrect" onClick={() => navigate("/basket")}>
                    Basket (3)
                </button>
            </header>
        </div>
    );
};

export default Shop;