import React, { useState, useEffect, useRef } from "react";
import { GetCourseByCourseId, GetVideo, GetImage } from '../../apiServices';
import { useParams, useNavigate } from 'react-router-dom';
import Reviews from '../Reviews/Reviews';
import coverImage from '../../Uploads/cover.jpg';
import Swal from 'sweetalert2';
import { Container, Row, Col, Button, Progress, Card } from 'reactstrap';

import 'bootstrap/dist/css/bootstrap.min.css';
import './CourseDetail.css';


const CourseDetail = () => {
    const { courseId } = useParams();
    const navigate = useNavigate();
    const [course, setCourse] = useState(null);
    const [videoUrl, setVideoUrl] = useState(null);
    const [imageUrl, setImageUrl] = useState(null);
    const [isPlaying, setIsPlaying] = useState(false);
    const [currentTime, setCurrentTime] = useState(0);
    const videoRef = useRef(null);
    const [updateProgress, setUpdateProgress] = useState(false);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);


    useEffect(() => {
        const fetchData = async () => {
            try {
                const [courseResponse, videoResponse, imageResponse] = await Promise.all([
                    GetCourseByCourseId(courseId),
                    GetVideo(courseId),
                    GetImage(courseId)
                ]);

                setCourse(courseResponse);
                setVideoUrl(videoResponse.videoUrl);
                setImageUrl(imageResponse.imageUrl);


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
        <Container className="mt-4">
            <Row>
                <Col lg="6" className="d-flex">
                    <Card className="course-card flex-grow-1">
                        <div className="course-image-container">
                            <img src={`https://toygantestbucket.s3.eu-central-1.amazonaws.com/${imageUrl}`} alt={course.title} className="img-fluid rounded mb-3" />
                            {videoUrl && (
                                <div className="mt-3">
                                    <video
                                        ref={videoRef}
                                        width="100%"
                                        controls
                                        onPlay={() => setIsPlaying(true)}
                                        onPause={() => {
                                            setIsPlaying(false);
                                            localStorage.setItem(
                                                `videoTime_${courseId}`,
                                                videoRef.current.currentTime.toString()
                                            );
                                        }}
                                        onTimeUpdate={handleTimeUpdate}
                                    >
                                        <source src={`https://toygantestbucket.s3.eu-central-1.amazonaws.com/${videoUrl}`} type="video/mp4" />

                                        Your browser does not support the video tag.
                                    </video>


                                    <div className="d-flex justify-content-between align-items-center mt-3">
                                        <Progress
                                            max={videoRef.current && videoRef.current.duration}
                                            value={currentTime}
                                            className="w-75"
                                        ></Progress>
                                    </div>
                                </div>
                            )}
                        </div>
                    </Card>
                </Col>
                <Col lg="6" className="d-flex">
                    <Card className="course-details-card flex-grow-1 p-4 d-flex flex-column justify-content-between">
                        <div className="course-details">
                            <h1 className="display-4 mb-3">{course.title}</h1>
                            <p className="lead">{course.description}</p>
                            <div className="text-muted">
                                <p>{`Course Length: ${course.courseLength}`}</p>
                                <p>{`Created Date: ${course.createdDate}`}</p>
                                <p>{`Status: ${course.courseStatus ? 'Active' : 'Inactive'}`}</p>
                            </div>
                        </div>
                        <div className="add-to-basket mt-3">
                            <Button
                                onClick={handleAddToBasket}
                                color="danger"
                                block
                            >
                                Add to Basket
                            </Button>
                        </div>
                    </Card>
                </Col>
            </Row>
            <Row className="mt-4">
                <Col lg="12">
                    <Card className="review-card-container p-4">
                        <h2 className="mb-4">Student Reviews</h2>
                        <Reviews courseId={courseId} />
                    </Card>
                </Col>
            </Row>
        </Container>
    );


};
export default CourseDetail;