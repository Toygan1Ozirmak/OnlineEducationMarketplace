// MyCourses.js

import React, { useState, useEffect } from "react";

const MyCourses = () => {
    const [myCourses, setMyCourses] = useState([]);

    useEffect(() => {
        // localStorage'den "myCourses" verilerini çek
        const fetchedCourses = localStorage.getItem("myCourses");
        const coursesArray = fetchedCourses ? JSON.parse(fetchedCourses) : [];
        setMyCourses(coursesArray);
    }, []);

    return (
        <div>
            <h2>My Courses</h2>
            <ul>
                {myCourses.map((course, index) => (
                    <li key={index}>{course.courseName}</li>
                ))}
            </ul>
        </div>
    );
};

export default MyCourses;
