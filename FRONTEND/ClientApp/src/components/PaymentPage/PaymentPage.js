import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import "./PaymentPage.css";

const PaymentPage = () => {
    const navigate = useNavigate();

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

    const handlePaymentClick = () => {
        // Ödeme işlemleri burada gerçekleştirilebilir
        console.log("Payment details:", cardInfo);
        navigate("/confirmation"); // Ödeme onay sayfasına yönlendirme
    };

    return (
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

                    <Button
                        variant="success"
                        onClick={handlePaymentClick}
                        className="payment-button"
                    >
                        Make Payment
                    </Button>
                </Form>
            </div>
        </div>
    );
};

export default PaymentPage;
