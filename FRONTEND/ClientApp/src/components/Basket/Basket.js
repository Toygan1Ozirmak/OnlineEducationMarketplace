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

    const handleRemoveFromBasket = (courseId) => {
        try {
            const updatedBasket = courses.filter(course => course.courseId !== courseId);
            localStorage.setItem("basket", JSON.stringify(updatedBasket));
            setCourses(updatedBasket);
        } catch (error) {
            console.error("Error removing course from basket:", error);
        }
    };

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
                                    <p>{course.courseName}</p>
                                    <button onClick={() => handleRemoveFromBasket(course.courseId)}>Remove from Basket</button>
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
