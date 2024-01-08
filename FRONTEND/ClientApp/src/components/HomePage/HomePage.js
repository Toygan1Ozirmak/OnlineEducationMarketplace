import React from "react";
import { useNavigate } from "react-router-dom";
import { Button, Card, Col, Container, Row } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

const HomePage = () => {
    const navigate = useNavigate();

    const handleSoftwareTestingButtonClick = () => {
        navigate("/shop/software-testing");
    };

    const handleMachineLearningButtonClick = () => {
        navigate("/shop/machine-learning");
    };

    const handleUIUXButtonClick = () => {
        navigate("/shop/ui-ux");
    };

    return (
        <Container fluid className="mt-4" style={{ backgroundColor: "#f2f2f2", minHeight: "90vh" }}>
            <Card bg="light" text="dark">
                <Card.Body>
                    <Row>
                        <Col md={6}>
                            <img
                                src="https://toygantestbucket.s3.eu-central-1.amazonaws.com/homepage.jpg"
                                alt="Study"
                                className="img-fluid rounded"
                            />
                        </Col>
                        <Col md={6}>
                            <h1 className="display-4 text-danger">Welcome to OEMAPP</h1>
                            <p className="lead text-dark">
                                Sign up now for the most suitable training among thousands of
                                trainings with OEAMPP, and take yourself one step further with
                                live lessons and courses!
                            </p>
                            <hr className="my-4" />
                            <p className="text-dark">
                                Achieve success by learning the latest competencies. Hundreds
                                of instructors and students were brought together on the same
                                platform. Take your place now!
                            </p>
                            <div className="text-center mt-4">
                                <Button
                                    variant="danger"
                                    size="lg"
                                    onClick={() => navigate("/shop")}
                                    style={{ backgroundColor: "#ff4d4d", border: "none" }}
                                >
                                    Explore Courses
                                </Button>
                            </div>
                        </Col>
                    </Row>

                    <Row className="mt-4">
                        <Col md={4}>
                            <Card bg="danger" text="white" className="mb-3">
                                <Card.Body>
                                    <h2 className="card-title">10+</h2>
                                    <p className="card-text">Years Experience</p>
                                </Card.Body>
                            </Card>
                        </Col>
                        <Col md={4}>
                            <Card bg="danger" text="white" className="mb-3">
                                <Card.Body>
                                    <h2 className="card-title">29+</h2>
                                    <p className="card-text">Total Courses</p>
                                </Card.Body>
                            </Card>
                        </Col>
                        <Col md={4}>
                            <Card bg="danger" text="white" className="mb-3">
                                <Card.Body>
                                    <h2 className="card-title">50K+</h2>
                                    <p className="card-text">Student Active</p>
                                </Card.Body>
                            </Card>
                        </Col>
                    </Row>
                </Card.Body>
            </Card>

            <div className="text-center mt-4">
                <h2 className="text-danger mb-4">Explore Our Categories - Your Path to Success</h2>
                <Row className="mt-3">
                    <Col md={4}>
                        <Card bg="danger" text="white" className="mb-3">
                            <Card.Body>
                                <h2 className="card-title">Machine Learning</h2>
                                <Button
                                    variant="danger"
                                    size="lg"
                                    block
                                    onClick={handleMachineLearningButtonClick}
                                    style={{ backgroundColor: "#ff4d4d", border: "none" }}
                                >
                                    Explore
                                </Button>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col md={4}>
                        <Card bg="danger" text="white" className="mb-3">
                            <Card.Body>
                                <h2 className="card-title">UI/UX</h2>
                                <Button
                                    variant="danger"
                                    size="lg"
                                    block
                                    onClick={handleUIUXButtonClick}
                                    style={{ backgroundColor: "#ff4d4d", border: "none" }}
                                >
                                    Explore
                                </Button>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col md={4}>
                        <Card bg="danger" text="white" className="mb-3">
                            <Card.Body>
                                <h2 className="card-title">Software Testing</h2>
                                <Button
                                    variant="danger"
                                    size="lg"
                                    block
                                    onClick={handleSoftwareTestingButtonClick}
                                    style={{ backgroundColor: "#ff4d4d", border: "none" }}
                                >
                                    Explore
                                </Button>
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>
            </div>
        </Container>
    );
};

export default HomePage;