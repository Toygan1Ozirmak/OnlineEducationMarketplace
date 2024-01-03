import React, { useState, useEffect, useRef } from "react";
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
    const [isPlaying, setIsPlaying] = useState(false);
    const [currentTime, setCurrentTime] = useState(0);
    const videoRef = useRef(null);
    const [updateProgress, setUpdateProgress] = useState(false);


    useEffect(() => {
        const fetchData = async () => {
            try {
                const courseResponse = await GetCourseByCourseId(courseId);
                setCourse(courseResponse);

                const videoResponse = await GetVideo();
                setVideoUrl(videoResponse);
            } catch (error) {
                console.error('Error fetching course or video:', error);
            }
        };

        fetchData();
    }, [courseId]);

    useEffect(() => {
        const savedTime = localStorage.getItem(`videoTime_${courseId}`);
        if (savedTime !== null) {
            setCurrentTime(parseFloat(savedTime));
            setUpdateProgress(true);
        } else {
            setUpdateProgress(false);
        }
    }, [courseId]);

    useEffect(() => {
        const video = videoRef.current;

        if (video) {
            // Video yüklenip oynatıldığında
            video.addEventListener("loadeddata", () => {
                video.addEventListener("play", () => {
                    setIsPlaying(true);
                    setUpdateProgress(true);
                });
                video.addEventListener("pause", () => {
                    setIsPlaying(false);
                    setUpdateProgress(false);
                    localStorage.setItem(`videoTime_${courseId}`, video.currentTime.toString());
                });

                const intervalId = setInterval(() => {
                    if (updateProgress && video.currentTime !== currentTime) {
                        setCurrentTime(video.currentTime);
                    }
                }, 1000);

                return () => {
                    video.removeEventListener("play", () => {
                        setIsPlaying(true);
                        setUpdateProgress(true);
                    });
                    video.removeEventListener("pause", () => {
                        setIsPlaying(false);
                        setUpdateProgress(false);
                        localStorage.setItem(`videoTime_${courseId}`, video.currentTime.toString());
                    });
                    clearInterval(intervalId);
                };
            });
        }
    }, [videoRef, setIsPlaying, setCurrentTime, updateProgress, currentTime, courseId]);

    const handlePlayPause = () => {
        const video = videoRef.current;
        if (video) {
            if (video.paused) {
                video.play();
                setIsPlaying(true);
            } else {
                video.pause();
                setIsPlaying(false);
                // Save the current time when the video is paused
                localStorage.setItem(`videoTime_${courseId}`, video.currentTime.toString());
            }
        }
    };

    const handleTimeUpdate = () => {
        const video = videoRef.current;
        if (video && isPlaying) {
            setCurrentTime(video.currentTime);
        }
    };

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
                    <div>
                        <video
                            ref={videoRef}
                            width="500"
                            controls
                            onPlay={() => setIsPlaying(true)}
                            onPause={() => setIsPlaying(false)}
                            onTimeUpdate={handleTimeUpdate}
                        >
                            <source src={videoUrl} type="video/mp4" />
                            Your browser does not support the video tag.
                        </video>
                        <progress max={videoRef.current && videoRef.current.duration} value={currentTime}></progress>
                        <button onClick={handlePlayPause}>{isPlaying ? "Pause" : "Play"}</button>
                    </div>
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