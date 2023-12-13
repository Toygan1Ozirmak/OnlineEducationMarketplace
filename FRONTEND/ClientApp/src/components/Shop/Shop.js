import React, { useState, useEffect } from "react";
import Button from "@mui/material/Button";
import { useNavigate } from "react-router-dom";
import { getAllCourses } from '../../apiServices';

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
            <div className="view-all">
                <div className="view-all-child" />
                <div className="view-all1">{`View All `}</div>
            </div>
            <div className="shopcourses">
                {courses.map(course => (
                    <div key={course.courseId} className="course-card">
                        <img src={course.Image} alt={course.title} className="course-image" />
                        {/* Diğer bilgileri göstermek için gerekli HTML ve stil ekleyebilirsiniz */}
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
            <div className="shopcategoriesframe">
                {/* ... (Kategori seçenekleri) ... */}
            </div>
            <div className="shopcategories">Categories</div>
            <header className="shopheader" id="Header">
                {/* ... (Diğer HTML blokları) ... */}
            </header>
        </div>
    );
};

export default Shop;
