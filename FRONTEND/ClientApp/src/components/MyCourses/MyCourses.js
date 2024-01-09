import React, { useState, useEffect } from "react";
import { Card, Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const MyCourses = () => {
    const [myCourses, setMyCourses] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        // localStorage'den "myCourses" verilerini çek
        const fetchedCourses = localStorage.getItem("myCourses");
        const coursesArray = fetchedCourses ? JSON.parse(fetchedCourses) : [];
        setMyCourses(coursesArray);
    }, []);

    return (
        <div className="mycoursesPage">
            <div className="mycoursesContent">
                <div className="mycourses">Order summary

                    {myCourses.map((course, index) => (
                        <div key={index} className="mycourses">
                            <div className="basketCourse">
                                <div className="courseImage">
                                    <img src={course.courseImage} alt={course.courseName} />
                                </div>
                                <div className="courseInfo">
                                    <p>{course.courseName}</p>

                                    {/* Other course information */}
                                </div>
                                <Button onClick={() => navigate(`/mycourses/${course.courseId}`)} variant="danger">
                                    View Details
                                </Button>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
};

export default MyCourses;
