import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { logoutInstance } from './Logout';


export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    handleLogout = async () => {
        if (!this.state.isLoggingOut) {
            this.setState({ isLoggingOut: true });

            try {
                const isLogoutSuccessful = await logoutInstance.logoutUser();

                if (isLogoutSuccessful) {
                    // Clear the basket data from localStorage on logout
                    localStorage.removeItem("basket");

                    // Redirect to the homepage after logout
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
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
                    <NavbarBrand tag={Link} to="/">OEMAPP</NavbarBrand>
                    <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/homepage">Homepage</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/shop">Shop</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/register">Register</NavLink>
                            </NavItem> 
                                <NavItem>
                                    <button className="btn btn-link text-dark" onClick={this.handleLogout}>
                                        Logout
                                    </button>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/basket">Basket</NavLink>
                            </NavItem> 
                            
                        </ul>
                    </Collapse>
                </Navbar>
            </header>
        );
    }
}
