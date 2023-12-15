import React, { useState, useEffect } from "react";
import { GetCoursesByCategoryId } from '../apiServices';
import Button from "@mui/material/Button";
import { Link, useNavigate } from "react-router-dom";
import coverImage from '../Uploads/cover.jpg';
import "./MachineLearning.css"; // Örnek bir stil dosyası

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
        </div>
    );
};

export default MachineLearningPage;
