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
                const [courseResponse/*, videoResponse*/, imageResponse] = await Promise.all([
                    GetCourseByCourseId(courseId),
                    /*GetVideo(courseId),*/
                    GetImage(courseId)
                ]);

                setCourse(courseResponse);
                /*setVideoUrl(videoResponse.videoUrl);*/
                setImageUrl(imageResponse.imageUrl);


                // Check if there's a saved time in localStorage
                const savedTime = localStorage.getItem(`videoTime_${courseId}`);
                if (savedTime !== null) {
                   
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

  

    const handleAddToBasket = () => {
        const basketKey = "basket";
        const existingBasket = localStorage.getItem(basketKey);
        const existingBasketArray = existingBasket ? JSON.parse(existingBasket) : [];

        // Check if the course is already in the basket
        const isCourseInBasket = existingBasketArray.some(item => item.courseId === courseId);

        if (isCourseInBasket) {
            // Display an error alert if the course is already in the basket
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'This course is already in your basket!',
                confirmButtonColor: '#d9534f',
            });
            console.log("Course not added to basket: Already exists");
            return; // Hata durumu için fonksiyonu burada sonlandır
        }

        // Check if the course is already in myCourses array
        const myCourses = localStorage.getItem("myCourses") || "[]";
        const myCoursesArray = JSON.parse(myCourses);

        const isCourseInMyCourses = myCoursesArray.some(item => item.courseId === courseId);

        if (isCourseInMyCourses) {
            // Display an error alert if the course is already in myCourses array
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'This course is already in your courses!',
                confirmButtonColor: '#d9534f',
            });
            console.log("Course not added to basket: Already in myCourses");
            return; // Hata durumu için fonksiyonu burada sonlandır
        }

        try {
            // Add the course to the basket
            const updatedBasket = [...existingBasketArray, { courseId, courseName: course.title, courseImage: coverImage }];
            localStorage.setItem(basketKey, JSON.stringify(updatedBasket));

            // Display success alert after successful addition
            Swal.fire({
                icon: 'success',
                title: 'Success!',
                text: 'Course added to basket!',
                confirmButtonColor: '#5bc0de',
            });
            console.log("Course added to basket:", updatedBasket);

            // Redirect to the basket page after successful addition
            navigate("/basket", { state: { selectedCourses: updatedBasket } });
        } catch (error) {
            // Handle errors, e.g., display an error alert
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Error adding course to basket. Please try again.',
                confirmButtonColor: '#d9534f',
            });
            console.error("Error adding course to basket:", error);
        }
    };


    return (
        <Container className="mt-4">
            <Row>
                <Col lg="8" className="d-flex">
                    <Card className="course-card flex-grow-1 h-100">
                        <div className="course-image-container">
                            <img
                                src={`https://toygantestbucket.s3.eu-central-1.amazonaws.com/${imageUrl}`}
                                alt={course.title}
                                className="img-fluid rounded mb-3 h-100"
                                style={{
                                    objectFit: 'cover',
                                    width: '100%',
                                    height: '100%',
                                    objectPosition: '50% 0%', // Centered horizontally, aligned to the top vertically
                                }}
                            />
                            {videoUrl && (
                                <div className="mt-3">
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
                <Col lg="4" className="d-flex">
                    <Card className="course-details-card flex-grow-1 p-4 d-flex flex-column justify-content-between h-100">
                        <div className="course-details">
                            <h1 className="display-4 mb-3">{course.title}</h1>
                            <p className="lead">{course.description}</p>
                            <div className="text-muted">
                                <p>{`Course Length: ${course.courseLength}`}</p>
                                <p>{`Status: ${course.courseStatus ? 'Active' : 'Inactive'}`}</p>
                            </div>
                        </div>
                        <div className="add-to-basket mt-3">
                            <Button onClick={handleAddToBasket} color="primary" block>
                                Add to Basket
                            </Button>
                        </div>
                    </Card>
                </Col>
            </Row>
            <Row className="mt-4">
                <Col lg="12">
                    <Card className="review-card-container p-4">
                        <Reviews courseId={courseId} />
                    </Card>
                </Col>
            </Row>
        </Container>
    );
};

export default CourseDetail;