import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import './Basket.css';
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import { GetImage } from '../../apiServices';

const Basket = ({ location }) => {
    const { state } = location || {};
    const { selectedCourses } = state || {};
    const navigate = useNavigate();

    const [courses, setCourses] = useState([]);

    const [showPaymentForm, setShowPaymentForm] = useState(true);

    const handleTogglePaymentForm = () => {
        setShowPaymentForm(!showPaymentForm);
    };

    useEffect(() => {
        const fetchBasketContent = async () => {
            try {
                const existingBasket = localStorage.getItem("basket");
                const existingBasketArray = existingBasket ? JSON.parse(existingBasket) : [];

                // Fetch image URLs for each course in the basket
                const coursesWithImages = await Promise.all(
                    existingBasketArray.map(async (course) => {
                        const imageResponse = await GetImage(course.courseId);
                        return { ...course, imageUrl: imageResponse.imageUrl };
                    })
                );

                setCourses(coursesWithImages);
            } catch (error) {
                console.error("Error fetching basket content:", error);
            }
        };

        fetchBasketContent();
        document.documentElement.style.setProperty('--payment-display', showPaymentForm ? 'block' : 'none');
    }, [showPaymentForm]);  // Buradaki courses'u kaldırdım



    const handleRemoveFromBasket = (courseId) => {
        try {
            const updatedBasket = courses.filter(course => course.courseId !== courseId);
            localStorage.setItem("basket", JSON.stringify(updatedBasket));
            setCourses(updatedBasket);
        } catch (error) {
            console.error("Error removing course from basket:", error);
        }
    };

    const handleCompleteOrder = () => {
        try {
            // Ödeme işlemleri burada gerçekleştirilebilir
            console.log("Payment details:", cardInfo);

            // Kursları "myCourses" olarak adlandırılan bir anahtar altında localStorage'de kaydet
            const myCourses = localStorage.getItem("myCourses") || "[]";
            const myCoursesArray = JSON.parse(myCourses);

            // Ödeme yapılan kursları ekleyerek güncelle
            courses.forEach(course => {
                if (!myCoursesArray.some(item => item.courseId === course.courseId)) {
                    myCoursesArray.push(course);
                }
            });

            localStorage.setItem("myCourses", JSON.stringify(myCoursesArray));

            // Ödeme tamamlandıktan sonra basket'i temizle
            localStorage.removeItem("basket");
            setCourses([]);

            alert("Order completed!");
            navigate("/mycourses");
        } catch (error) {
            console.error("Error completing order:", error);
        }
    };

    const [cardInfo, setCardInfo] = useState({
        cardNumber: "",
        cardHolder: "",
        expiryDate: "",
        cvv: "",
    });

    const handleChange = (e) => {
        const { id, value } = e.target;
        setCardInfo({ ...cardInfo, [id]: value });
    };

    return (
        <div className="basketPage">
            <div className="basketContent">
                <div className="basketSummary">
                    <div className="orderSummary">Order summary</div>
                    {courses.map((course, index) => (
                        <div key={index} className="myBasket">
                            <div className="basketCourse">
                                <div className="courseImage">
                                    <img src={`https://toygantestbucket.s3.eu-central-1.amazonaws.com/${course.imageUrl}`} alt={course.courseName} />
                                </div>
                                <div className="courseInfo">
                                    <p>{course.courseName}</p>
                                    <button onClick={() => handleRemoveFromBasket(course.courseId)}>Remove from Basket</button>
                                    {/* Other course information */}
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
                <div className="toggle-payment-button">
                    <Button variant="primary" onClick={handleTogglePaymentForm}>
                        {showPaymentForm ? "Go to Payment" : "Back to Basket"}
                    </Button>
                </div>
                {/* Payment form */}
                <div className="payment-container">
                    <div className="payment-body">
                        <h2 className="payment-title">Enter Your Payment Details</h2>
                        <Form>
                            <Form.Group className="mb-4" controlId="cardNumber">
                                <Form.Label>Card Number</Form.Label>
                                <Form.Control
                                    type="text"
                                    value={cardInfo.cardNumber}
                                    onChange={handleChange}
                                    placeholder="Enter your card number"
                                />
                            </Form.Group>

                            <Form.Group className="mb-4" controlId="cardHolder">
                                <Form.Label>Card Holder</Form.Label>
                                <Form.Control
                                    type="text"
                                    value={cardInfo.cardHolder}
                                    onChange={handleChange}
                                    placeholder="Enter the card holder's name"
                                />
                            </Form.Group>

                            <Form.Group className="mb-4" controlId="expiryDate">
                                <Form.Label>Expiry Date</Form.Label>
                                <Form.Control
                                    type="text"
                                    value={cardInfo.expiryDate}
                                    onChange={handleChange}
                                    placeholder="MM/YYYY"
                                />
                            </Form.Group>

                            <Form.Group className="mb-4" controlId="cvv">
                                <Form.Label>CVV</Form.Label>
                                <Form.Control
                                    type="text"
                                    value={cardInfo.cvv}
                                    onChange={handleChange}
                                    placeholder="Enter the CVV"
                                />
                            </Form.Group>
                        </Form>
                    </div>
                </div>
                <div className="completeOrderButton">
                    <Button variant="danger" onClick={handleCompleteOrder}>
                        Complete Order
                    </Button>
                </div>
            </div>
        </div>
    );
};

export default Basket;
