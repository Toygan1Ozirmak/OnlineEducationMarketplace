import React, { useState, useEffect } from "react";
import { GetCoursesByCategoryId } from '../../../apiServices';
import Button from "@mui/material/Button";
import { Link, Routes, Route, useNavigate } from "react-router-dom";
import coverImage from '../../../Uploads/cover.jpg';
import "./MachineLearning.css"; 
import  SoftwareTestingPage from "../SoftwareTesting/SoftwareTesting";
import  UIUXPage  from "../UI-UX/UI-UX";
import CourseDetail from "../../CourseDetail/CourseDetail";
import Shop from "../../Shop/Shop";


const MachineLearningPage = ({ match }) => {
    const categoryId = 1; // Belirli bir kategori ID'si, örneğin 1
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
        <div className="machine-learning-page">
            <div className="category"><Link to="/shop">All</Link></div>
            <div className="category"><Link to="/shop/ui-ux">UI/UX</Link></div>
            <div className="category"><Link to="/shop/software-testing">Software Testing</Link></div>

            <h1>Machine Learning Courses</h1>

            <div className="machine-learning-courses">
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
                <Route path="/courses/software-testing/:categoryId/:courseId/*" element={<SoftwareTestingPage />} />
                <Route path="/course/:courseId" element={<CourseDetail />} />
                {/* Diğer sayfalar için benzer Route tanımlamaları... */}
            </Routes>
        </div>
    );
};

export default MachineLearningPage;
