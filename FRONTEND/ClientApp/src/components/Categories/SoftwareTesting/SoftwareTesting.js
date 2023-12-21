import React, { useState, useEffect } from "react";
import { GetCoursesByCategoryId } from '../../../apiServices';
import Button from "@mui/material/Button";
import { Link, Routes, Route, useNavigate } from "react-router-dom";
import coverImage from '../../../Uploads/cover.jpg';
import "./SoftwareTesting.css"; 
import MachineLearningPage from "../MachineLearning/MachineLearning";
import UIUXPage from "../UI-UX/UI-UX";
import CourseDetail from "../../CourseDetail/CourseDetail";
import Shop from "../../Shop/Shop";

const SoftwareTestingPage = ({ match }) => {
    const categoryId = 3; // Belirli bir kategori ID'si
    const [courses, setCourses] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchCoursesByCategory = async () => {
            try {
                const response = await GetCoursesByCategoryId(categoryId);
                setCourses(response);
            } catch (error) {
                console.error('Error fetching courses by category:', error);
            }
        };

        fetchCoursesByCategory();
    }, [categoryId]);

    return (
        <div className="software-testing-page">
            <div className="category"><Link to="/shop">All</Link></div>
            <div className="category"><Link to="/shop/machine-learning">Machine Learning</Link></div>
            <div className="category"><Link to="/shop/ui-ux">UI/UX</Link></div>
            <h1>Software Testing Courses</h1>
            <div className="software-testing-courses">
                {courses.map(course => (
                    <div key={course.courseId} className="course-card">
                        <img src={coverImage} alt={course.title} className="course-image" />
                        <div className="course-details">
                            <h3>{course.title}</h3>
                            <p>{course.description}</p>
                            <p>{`Course Length: ${course.courseLength}`}</p>
                            <p>{`Created Date: ${course.createdDate}`}</p>
                            <p>{`Status: ${course.courseStatus ? 'Active' : 'Inactive'}`}</p>
                            <p>{`Category ID: ${course.categoryId}`}</p>
                            <Button onClick={() => navigate(`/course/${course.courseId}`)} variant="contained">
                                View Details
                            </Button>
                        </div>
                    </div>
                ))}
            </div>
            <Routes>
                <Route path="/shop" element={<Shop />} />
                <Route path="/courses/ui-ux/:categoryId/:courseId/*" element={<UIUXPage />} />
                <Route path="/courses/machine-learning/:categoryId/:courseId/*" element={<MachineLearningPage />} />
                <Route path="/course/:courseId" element={<CourseDetail />} />
                {/* Diğer sayfalar için benzer Route tanımlamaları... */}
            </Routes>
        </div>
    );
};

export default SoftwareTestingPage;
