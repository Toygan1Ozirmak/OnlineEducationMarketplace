import React, { useState, useEffect } from "react";
import { Link, Routes, Route, useNavigate } from "react-router-dom";
import { getAllCourses } from '../../apiServices';
import { Card, Button } from "react-bootstrap";
import coverImage from '../../Uploads/cover.jpg';
import MachineLearningPage from "../Categories/MachineLearning/MachineLearning";
import CourseDetail from "../CourseDetail/CourseDetail";
import UIUXPage from "../Categories/UI-UX/UI-UX";
import SoftwareTestingPage from "../Categories/SoftwareTesting/SoftwareTesting";
import "./Shop.css";

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
            </div>

            <div className="shopcourses">
                {courses.map(course => (
                    <Card key={course.courseId} className="course-card">
                        <Card.Img variant="top" src={coverImage} alt={course.title} className="course-image" />
                        <Card.Body>
                            <Card.Title>{course.title}</Card.Title>
                            <Card.Text>{course.description}</Card.Text>
                            <Card.Text>{`Course Length: ${course.courseLength}`}</Card.Text>
                            <Card.Text>{`Created Date: ${course.createdDate}`}</Card.Text>
                            <Card.Text>{`Status: ${course.courseStatus ? 'Active' : 'Inactive'}`}</Card.Text>
                            <Card.Text>{`Category ID: ${course.categoryId}`}</Card.Text>
                            <Button onClick={() => navigate(`/course/${course.courseId}`)} variant="danger">
                                View Details
                            </Button>
                        </Card.Body>
                    </Card>
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
