import React, { useState, useEffect } from "react";
import { GetCourseByCourseId, GetVideo } from '../../apiServices';
import { useParams, useNavigate } from 'react-router-dom';
import Reviews from '../Reviews/Reviews';
import coverImage from '../../Uploads/cover.jpg';
import './CourseDetail.css';

const CourseDetail = () => {
    const { courseId } = useParams();
    const navigate = useNavigate();
    const [course, setCourse] = useState(null);
    const [videoUrl, setVideoUrl] = useState(null);

    useEffect(() => {
        const fetchCourse = async () => {
            try {
                const response = await GetCourseByCourseId(courseId);
                setCourse(response);

                // Video URL'i al ve state'e ata
                const videoResponse = await GetVideo();
                setVideoUrl(videoResponse);
            } catch (error) {
                console.error('Error fetching course or video:', error);
            }
        };

        fetchCourse();
    }, [courseId]);

    if (!course) {
        return <div>Loading...</div>;
    }

    const handleAddToBasket = () => {
        const basketKey = "basket";
        const existingBasket = localStorage.getItem(basketKey);
        const existingBasketArray = existingBasket ? JSON.parse(existingBasket) : [];

        // Check if the course is already in the basket
        const isCourseInBasket = existingBasketArray.some(item => item.courseId === courseId);

        if (isCourseInBasket) {
            alert("This course is already in your basket!");
            console.log("Course not added to basket: Already exists");
        } else {
            try {
                // Add the course to the basket
                const updatedBasket = [...existingBasketArray, { courseId, courseName: course.title, courseImage: coverImage }];
                localStorage.setItem(basketKey, JSON.stringify(updatedBasket));

                // Display alert after successful addition
                alert("Course added to basket!");
                console.log("Course added to basket:", updatedBasket);

                // Redirect to the basket page after successful addition
                navigate("/basket", { state: { selectedCourses: updatedBasket } });
            } catch (error) {
                // Handle errors, e.g., display an error alert
                alert("Error adding course to basket. Please try again.");
                console.error("Error adding course to basket:", error);
            }
        }
    };




    return (
        <div className="course-detail-container">
            <div className="course-image-container">
                <img src={coverImage} alt={course.title} className="course-image" />
                {videoUrl && (
                    <video width="500" controls>
                        <source src={videoUrl} type="video/mp4" />
                        Your browser does not support the video tag.
                    </video>
                )}
            </div>
            <div className="course-details-card">
                <div className="course-details">
                    <h1>{course.title}</h1>
                    <p>{course.description}</p>
                    <p>{`Course Length: ${course.courseLength}`}</p>
                    <p>{`Created Date: ${course.createdDate}`}</p>
                    <p>{`Status: ${course.courseStatus ? 'Active' : 'Inactive'}`}</p>
                    <div className="add-to-basket">
                        <button onClick={handleAddToBasket}>Add to Basket</button>
                    </div>
                </div>
            </div>
            <div className="review-card-container">
                <Reviews courseId={courseId} />
            </div>
        </div>
    );
};

export default CourseDetail;