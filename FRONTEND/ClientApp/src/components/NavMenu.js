// NavMenu.js
import React, { Component } from 'react';
import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { logoutInstance } from './Logout';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.state = {
            expanded: false,
        };
    }

    handleLogout = async () => {
        if (!this.state.isLoggingOut) {
            this.setState({ isLoggingOut: true });

            try {
                const isLogoutSuccessful = await logoutInstance.logoutUser();

                if (isLogoutSuccessful) {
                    localStorage.removeItem("basket");
                    window.location.href = '/';
                    console.log("User logged out successfully.");
                }
            } catch (error) {
                console.error("Logout Error:", error);
            } finally {
                this.setState({ isLoggingOut: false });
            }
        }
    };

    render() {
        return (
            <header>
                <Navbar bg="light" expand="lg">
                    <Navbar.Brand as={Link} to="/">OEMAPP</Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="mr-auto">
                            <Nav.Link as={Link} to="/homepage">Homepage</Nav.Link>
                            <Nav.Link as={Link} to="/shop">Shop</Nav.Link>
                            <Nav.Link as={Link} to="/register">Register</Nav.Link>
                            <Nav.Link as={Link} to="/basket">Basket</Nav.Link>
                            <Nav.Link className="text-danger" onClick={this.handleLogout}>Logout</Nav.Link>
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>
            </header>
        );
    }
}
