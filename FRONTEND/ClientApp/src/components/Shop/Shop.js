import React, { useState, useEffect } from "react";
import { Link, Routes, Route, useNavigate } from "react-router-dom";
import { getAllCourses, GetCourseByCourseId, GetImage } from '../../apiServices';
import { Card, Button } from "react-bootstrap";
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
                const coursesResponse = await getAllCourses();

                // Fetch image URLs for each course
                const coursesWithImages = await Promise.all(
                    coursesResponse.map(async (course) => {
                        const imageResponse = await GetImage(course.courseId);
                        return { ...course, imageUrl: imageResponse.imageUrl };
                    })
                );

                console.log(coursesWithImages); // Log the updated courses to the console
                setCourses(coursesWithImages);
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
                <div className="category" style={{ backgroundColor: "#001f3f" }}><Link to="/shop" style={{ color: "#ccc" }}>All</Link></div>
                <div className="category" style={{ backgroundColor: "#001f3f" }}><Link to="/shop/machine-learning" style={{ color: "#ccc" }}>Machine Learning</Link></div>
                <div className="category" style={{ backgroundColor: "#001f3f" }}><Link to="/shop/ui-ux" style={{ color: "#ccc" }}>UI/UX</Link></div>
                <div className="category" style={{ backgroundColor: "#001f3f" }}><Link to="/shop/software-testing" style={{ color: "#ccc" }}>Software Testing</Link></div>
            </div>

            <div className="shopcourses">
                {courses.map(course => (
                    <Card key={course.courseId} className="course-card">
                        <img
                            src={`https://toygantestbucket.s3.eu-central-1.amazonaws.com/${course.imageUrl}`}
                            alt={course.title}
                            className="course-image"
                        />
                        <Card.Body>
                            <Card.Title>{course.title}</Card.Title>
                            <Card.Text>{course.description}</Card.Text>
                            <Card.Text>{`Course Length: ${course.courseLength}`}</Card.Text>
                            <Card.Text>{`Status: ${course.courseStatus ? 'Active' : 'Inactive'}`}</Card.Text>
                            <Card.Text>{`Category ID: ${course.categoryId}`}</Card.Text>
                            <div style={{ marginBottom: "10px" }}> {/* Adjust the margin as needed */}
                                <Button onClick={() => navigate(`/course/${course.courseId}`)} variant="danger">
                                    View Details
                                </Button>
                            </div>
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
