﻿import React, { useState, useEffect } from "react";
import { GetCoursesByCategoryId, GetImage } from '../../../apiServices';
import { Link, Routes, Route, useNavigate } from "react-router-dom";
import coverImage from '../../../Uploads/cover.jpg';
import "./MachineLearning.css"; 
import  SoftwareTestingPage from "../SoftwareTesting/SoftwareTesting";
import  UIUXPage  from "../UI-UX/UI-UX";
import CourseDetail from "../../CourseDetail/CourseDetail";
import Shop from "../../Shop/Shop";
import { Card, Button } from "react-bootstrap";


const MachineLearningPage = ({ match }) => {
    const categoryId = 1; // Belirli bir kategori ID'si, örneğin 1
    const [courses, setCourses] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchCoursesByCategory = async () => {
            try {
                const response = await GetCoursesByCategoryId(categoryId);

                // Fetch image URLs for each course
                const coursesWithImages = await Promise.all(
                    response.map(async (course) => {
                        const imageResponse = await GetImage(course.courseId);
                        return { ...course, imageUrl: imageResponse.imageUrl };
                    })
                );

                setCourses(coursesWithImages);
            } catch (error) {
                console.error('Error fetching courses by category:', error);
            }
        };

        fetchCoursesByCategory();
    }, [categoryId]);

    return (
        <div className="machine-learning-page">
            <div className="category" style={{ backgroundColor: "#001f3f" }} ><Link to="/shop" style={{ color: "#ccc" }} >All</Link></div>
            <div className="category" style={{ backgroundColor: "#001f3f" }} ><Link to="/shop/ui-ux" style={{ color: "#ccc" }} >UI/UX</Link></div>
            <div className="category" style={{ backgroundColor: "#001f3f" }} ><Link to="/shop/software-testing" style={{ color: "#ccc" }} >Software Testing</Link></div>
            <div style={{ textAlign: 'left' }}>
                <img
                    src="https://toygantestbucket.s3.eu-central-1.amazonaws.com/machine-learning_icon.png"
                    alt="Machine Learning Icon"
                    style={{ width: "200px", height: "200px" }}
                />
            </div>

            <h1>Machine Learning Courses</h1>
            

            <div className="machine-learning-courses">
                {courses.map(course => (
                    <div key={course.courseId} className="course-card">
                        <img
                            src={`https://toygantestbucket.s3.eu-central-1.amazonaws.com/${course.imageUrl}`}
                            alt={course.title}
                            className="course-image"
                        />
                        <Card.Body>
                            <Card.Title>{course.title}</Card.Title>
                            <Card.Text>{course.description}</Card.Text>
                            <Card.Text>{`Course Length: ${course.courseLength}`}</Card.Text>
                            <Card.Text>{`Created Date: ${course.createdDate}`}</Card.Text>
                            <Card.Text>{`Status: ${course.courseStatus ? 'Active' : 'Inactive'}`}</Card.Text>
                            <Card.Text>{`Category ID: ${course.categoryId}`}</Card.Text>
                            <div style={{ marginBottom: "10px" }}> {/* Adjust the margin as needed */}
                            <Button onClick={() => navigate(`/course/${course.courseId}`)} variant="danger">
                                View Details
                                </Button>
                            </div>
                        </Card.Body>
                        
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
