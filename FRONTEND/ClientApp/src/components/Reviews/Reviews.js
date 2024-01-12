import React, { useState, useEffect } from "react";
import { GetReviewsByCourseId } from '../../apiServices';

const Reviews = ({ courseId }) => {
    const [reviews, setReviews] = useState([]);

    useEffect(() => {
        const fetchReviews = async () => {
            try {
                const response = await GetReviewsByCourseId(courseId);
                setReviews(response);
            } catch (error) {
                console.error('Error fetching reviews:', error);
            }
        };

        fetchReviews();
    }, [courseId]); 

    return (
        <div className="review-list">
            <h2>Reviews</h2>
            <ul>
                {reviews.map(review => (
                    <li key={review.id} className="review-card">
                        <div className="review-details">
                            <p>{` ${review.comment}`}</p>
                            <p>{`Puan: ${review.point}`}</p>
                        </div>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Reviews;
