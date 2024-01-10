// Reply.jsx
import React, { useState, useEffect } from "react";
import { GetRepliesByReviewId } from '../../apiServices'; // Assuming you have a service to get replies

const Reply = ({ reviewId }) => {
    const [replies, setReplies] = useState([]);

    useEffect(() => {
        const fetchReplies = async () => {
            try {
                const response = await GetRepliesByReviewId(reviewId);
                setReplies(response);
            } catch (error) {
                console.error('Error fetching replies:', error);
            }
        };

        fetchReplies();
    }, [reviewId]);

    return (
        <div className="reply-list">
            <h3>Replies</h3>
            <ul>
                {replies.map(reply => (
                    <li key={reply.replyId} className="reply-card">
                        <div className="reply-details">
                            <p>{reply.replyText}</p>
                            {/* Add any other details you want to display for each reply */}
                        </div>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Reply;
