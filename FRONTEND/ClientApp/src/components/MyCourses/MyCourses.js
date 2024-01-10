import React, { useState, useEffect } from "react";
import { Card, Button, ProgressBar } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';

const MyCourses = () => {
    const [myCourses, setMyCourses] = useState([]);
    const [totalProgress, setTotalProgress] = useState(0);
    const [averageWatchedRatio, setAverageWatchedRatio] = useState(0); // Yeni state ekledik
    const navigate = useNavigate();

    const calculateTotalProgress = () => {
        const fetchedCourses = localStorage.getItem("myCourses");
        const coursesArray = fetchedCourses ? JSON.parse(fetchedCourses) : [];
        setMyCourses(coursesArray);

        const totalProgressValue = coursesArray.reduce((total, course) => {
            const courseId = course.courseId;
            const courseProgress = localStorage.getItem(`courseProgress_${courseId}`);
            console.log(`Course ${courseId} Progress:`, courseProgress);
            return total + (courseProgress ? parseFloat(courseProgress) : 0);
        }, 0);

        const boundedTotalProgress = Math.min(totalProgressValue, coursesArray.length);
        setTotalProgress(boundedTotalProgress);
    };


    const calculateWatchedRatio = () => {
        const watchedRatios = myCourses.map((course) => {
            const courseId = course.courseId;
            const watchedRatioKey = `watchedRatio_${courseId}`;
            const watchedRatio = localStorage.getItem(watchedRatioKey);

            console.log(`Watched Ratio for Course ${courseId}:`, watchedRatio);

            return watchedRatio !== null ? parseFloat(watchedRatio) : 0;
        });

        const totalWatchedRatio = watchedRatios.reduce((total, ratio) => total + ratio, 0);
        const averageWatchedRatio = myCourses.length > 0 ? totalWatchedRatio / myCourses.length : 0;

        // Set the average watched ratio in the state
        setAverageWatchedRatio(averageWatchedRatio);

        return averageWatchedRatio;
    };







    useEffect(() => {
        calculateTotalProgress();
    }, []); // Boş bağımlılık dizisi, sadece bir kere çalışmasını sağlar

    useEffect(() => {
        calculateWatchedRatio();
    }, [myCourses]);

    return (
        <div className="mycoursesPage">
            <div className="mycoursesContent">
                <div className="mycourses">
                    <h1>My Courses</h1>
                    {myCourses.map((course, index) => (
                        <div key={index} className="mycourses">
                            <div className="basketCourse">
                                <div className="courseImage">
                                    <img src={course.courseImage} alt={course.courseName} />
                                </div>
                                <div className="courseInfo">
                                    <p>{course.courseName}</p>
                                    {/* Diğer kurs bilgileri */}
                                </div>
                                <Button onClick={() => navigate(`/mycourses/${course.courseId}`)} variant="danger">
                                    View Details
                                </Button>
                            </div>
                        </div>
                    ))}
                </div>
                {totalProgress > 0 && (
                    <div className="totalProgress">
                        <h2>Total Progress</h2>
                        <ProgressBar max={myCourses.length} now={totalProgress} />
                        <p>{`${(totalProgress / myCourses.length * 100).toFixed(2)}% completed`}</p>
                    </div>
                )}

                {/*<div className="watchedRatio">*/}
                {/*    <h2>Average Watched Ratio</h2>*/}
                {/*    <p>{`Watched ratio for all courses: ${(averageWatchedRatio * 100).toFixed(2)}%`}</p>*/}
                {/*</div>*/}
            </div>
        </div>
    );
};

export default MyCourses;
