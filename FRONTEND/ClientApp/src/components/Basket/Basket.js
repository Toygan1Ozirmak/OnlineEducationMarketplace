import React, { useEffect, useState } from "react";
import './Basket.css';

const Basket = ({ location }) => {
    const { state } = location || {};
    const { selectedCourses } = state || [];

    const [courses, setCourses] = useState([]);

    useEffect(() => {
        // Fetch basket content from localStorage
        const fetchBasketContent = () => {
            try {
                const existingBasket = localStorage.getItem("basket");
                const existingBasketArray = existingBasket ? JSON.parse(existingBasket) : [];
                setCourses(existingBasketArray);
            } catch (error) {
                console.error("Error fetching basket content:", error);
            }
        };

        fetchBasketContent();
    }, []); // Run only once when the component mounts

    return (
        <div className="basketPage">
            <div className="basketContent">
                <div className="basketSummary">
                    <div className="orderSummary">Order summary</div>
                    {courses.map((course, index) => (
                        <div key={index} className="myBasket">
                            <div className="basketCourse">
                                <div className="courseImage">
                                    <img src={course.courseImage} alt={course.courseName} />
                                </div>
                                <div className="courseInfo">
                                    {/*<h1>{course.courseId}</h1>*/}
                                    <p>{course.courseName}</p>
                                    {/* Other course information */}
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );

};

export default Basket;
