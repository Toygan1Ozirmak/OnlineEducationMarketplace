import React, { useState, useEffect, useRef } from "react";
import { GetCourseByCourseId, GetVideo } from '../../apiServices';
import { useParams, useNavigate } from 'react-router-dom';
import Reviews from '../Reviews/Reviews';
import coverImage from '../../Uploads/cover.jpg';
import './CourseDetail.css';
import Swal from 'sweetalert2';


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

                // Check if there's a saved time in localStorage
                const savedTime = localStorage.getItem(`videoTime_${courseId}`);
                if (savedTime !== null) {
                    // Display a prompt to resume from the saved time
                    Swal.fire({
                        title: "Resume from where you left off?",
                        showDenyButton: true,
                        confirmButtonText: "Yes",
                        denyButtonText: "No",
                        confirmButtonColor: "green",
                        denyButtonColor: "black",
                    }).then((result) => {
                        if (result.isConfirmed) {
                            // Set the current time of the video to the saved time
                            videoRef.current.currentTime = parseFloat(savedTime);
                        }
                        // Start playing the video
                        videoRef.current.play();
                    });
                }
            } catch (error) {
                console.error("Error fetching course or video:", error);
            }
        };

        fetchData();
    }, [courseId]);

   
    if (!course) {
        return <div>Loading...</div>;
    }

    const handleTimeUpdate = () => {
        const video = videoRef.current;
        if (video && isPlaying) {
            setCurrentTime(video.currentTime);
        }
    };

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
                            onPause={() => {
                                setIsPlaying(false);
                                // Save the current time when the video is paused
                                localStorage.setItem(
                                    `videoTime_${courseId}`,
                                    videoRef.current.currentTime.toString()
                                );
                            }}
                            onTimeUpdate={handleTimeUpdate}
                        >
                            <source src={videoUrl} type="video/mp4" />
                            Your browser does not support the video tag.
                        </video>
                        <progress
                            max={videoRef.current && videoRef.current.duration}
                            value={currentTime}
                        ></progress>
                        <button onClick={handlePlayPause}>
                            {isPlaying ? "Pause" : "Play"}
                        </button>
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