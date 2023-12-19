// CourseDetail.jsx
import React, { useState, useEffect } from "react";
import { GetCourseByCourseId } from '../../apiServices';
import { useParams } from 'react-router-dom';
import Reviews from '../Reviews/Reviews';
import coverImage from '../../Uploads/cover.jpg';
import './CourseDetail.css';

const CourseDetail = () => {
    const { courseId } = useParams();
    const [course, setCourse] = useState(null);

    useEffect(() => {
        const fetchCourse = async () => {
            try {
                const response = await GetCourseByCourseId(courseId);
                setCourse(response);
            } catch (error) {
                console.error('Error fetching course:', error);
            }
        };

        fetchCourse();
    }, [courseId]);

    if (!course) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <div>
                <img src={coverImage} alt={course.title} className="course-image" />
            </div>
            <div>
                <h1>{course.title}</h1>
                <p>{course.description}</p>
                <p>{`Course Length: ${course.courseLength}`}</p>
                <p>{`Created Date: ${course.createdDate}`}</p>
                <p>{`Status: ${course.courseStatus ? 'Active' : 'Inactive'}`}</p>
                
            </div>

            {/* Reviews bileşenini kullanarak yorumları göster */}
            <Reviews courseId={courseId} />
        </div>
    );
};

export default CourseDetail;
