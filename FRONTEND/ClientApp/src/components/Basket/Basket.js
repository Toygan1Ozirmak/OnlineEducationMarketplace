import "./Basket.css";
import { useNavigate } from "react-router-dom";
import React, { useState } from "react";
//import Basketsearch from "./images/search.jpg";
//import Basketlogo from "./images/logo.jpg";

const Basket = () => {
    const navigate = useNavigate();

    return (
        <div className="basketPage">
            <div className="basketmlandda">
                <div className="machine-learning-and">
                    Machine Learning and Data Analysis
                </div>
                <div className="Basketdiv">{`$5.99 `}</div>
                <div className="basketmlframe">
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
                            <p className="basic-data-structure-and">
                                Basic data-structure and
                            </p>
                            <p className="basic-data-structure-and">algorithm</p>
                        </i>
                    </div>
                    {/*<img className="logo-icon" alt="" src="Logo.png" />*/}
                    <div className="illustrator-card" />
                </div>
            </div>
            <div className="basketwebdev">
                <div className="webdevelopment">Web Development</div>
                <div className="div1">
                    <p className="basic-data-structure-and">{`$12.99 `}</p>
                </div>
                <div className="basketwebframe">
                    <div className="machine-learning-wrapper">
                        <i className="machine-learning">Web Development</i>
                    </div>
                    <div className="basic-data-structure-and-algor-wrapper">
                        <i className="basic-data-structure-and1">{`Developing web applications `}</i>
                    </div>
                    {/*<img className="logo-icon" alt="" src="Logo.png" />*/}
                    <div className="illustrator-card1" />
                </div>
            </div>
            <div className="basketsummary">
                <div className="ordersummary">Order summary</div>
                <div className="subtotal">Subtotal</div>
                <div className="div2">$18.98</div>
                <div className="shipping">Shipping</div>
                <div className="div3">$3.99</div>
                <div className="tax">Tax</div>
                <div className="div4">$2.00</div>
                <div className="total">Total</div>
                <div className="div5">$24.97</div>
                <div className="paymentbutton">
                    <div className="continue-to-payment">Continue to payment</div>
                    {/*<img className="basketicon" alt="" src="BasketIcon.svg" />*/}
                </div>
            </div>
            <div className="basketpageheading">
                <div className="Basketitems">3 items</div>
                <div className="basketPageText">Basket</div>
                <div className="divider" />
            </div>

            <header className="basketheader" id="Header">
                <div className="basketheaderrectangle" />
                <div className="basketemapp" onClick={() => navigate("/")}>
                    EMAPP
                </div>
                <input className="basketsearchrectangle" type="text" />
                {/*<img className="basketlogo-icon" alt="" src={Basketlogo} />*/}
                {/*<img className="basketsearchicon" alt="" src={Basketsearch} />*/}
                <div className="basketcourses" onClick={() => navigate("/shop")}>
                    Courses
                </div>
            </header>
        </div>
    );
};

export default Basket;