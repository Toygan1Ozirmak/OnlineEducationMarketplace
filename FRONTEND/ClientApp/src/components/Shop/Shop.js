import React, { useState, useEffect } from "react";
import Button from "@mui/material/Button";
import { Link, Routes, Route, useNavigate } from "react-router-dom";
import { getAllCourses } from '../../apiServices';
import coverImage from '../../Uploads/cover.jpg';
import "./Shop.css";
import MachineLearningPage from "../Categories/MachineLearning/MachineLearning";
import CourseDetail from "../CourseDetail/CourseDetail";
import UIUXPage from "../Categories/UI-UX/UI-UX";
import SoftwareTestingPage from "../Categories/SoftwareTesting/SoftwareTesting";

const Shop = () => {
    const navigate = useNavigate();
    const [courses, setCourses] = useState([]);

    useEffect(() => {
        const fetchCourses = async () => {
            try {
                const response = await getAllCourses();
                setCourses(response);
            } catch (error) {
                console.error('Error fetching courses:', error);
            }
        };

        fetchCourses();
    }, []);

    return (
        <div className="shop">
            <div className="shopcategoriesframe">
                {/* Kategori seçenekleri */}
                <div className="category"><Link to="/shop">All</Link></div>
                <div className="category"><Link to="/shop/machine-learning">Machine Learning</Link></div>
                <div className="category"><Link to="/shop/ui-ux">UI/UX</Link></div>
                <div className="category"><Link to="/shop/software-testing">Software Testing</Link></div>
                {/* ... Diğer kategoriler */}
            </div>
            
            <div className="shopcourses">
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
            <header className="shopheader" id="Header">
                {/* ... (Diğer HTML blokları) ... */}
            </header>
            <Routes>
                
                <Route path="/courses/machine-learning/:categoryId/:courseId/*" element={<MachineLearningPage />} />
                <Route path="/courses/ui-ux/:categoryId/:courseId/*" element={<UIUXPage />} />
                <Route path="/courses/software-testing/:categoryId/:courseId/*" element={<SoftwareTestingPage />} />
                <Route path="/course/:courseId" element={<CourseDetail />} />
                {/* Diğer sayfalar için benzer Route tanımlamaları... */}
            </Routes>
        </div>
    );
};

export default Shop;
