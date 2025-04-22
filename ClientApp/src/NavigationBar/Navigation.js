import React from 'react';
import { Link } from 'react-router-dom'; // Import Link from react-router-dom
import { Navbar, Nav, NavDropdown, Container } from 'react-bootstrap'; // Import Navbar components from react-bootstrap

const Navigation = () => {
    return (
        <Navbar bg="dark" variant="dark" expand="lg">
            <Container>
                {/* Logo in the navbar */}
                <Navbar.Brand as={Link} to="/Home">
                    <img src="/Images/logo.svg" alt="Logo" style={{ width: '50px', height: 'auto' }} />
                </Navbar.Brand>

                {/* Navbar toggle button for mobile view */}
                <Navbar.Toggle aria-controls="navbar-nav" />
                
                {/* Navbar items that collapse on smaller screens */}
                <Navbar.Collapse id="navbar-nav">
                    <Nav className="ml-auto">
                        <Nav.Link as={Link} to="/Home">Home</Nav.Link>
                        <Nav.Link as={Link} to="/About">About</Nav.Link>
                        <Nav.Link as={Link} to="/Services">Services</Nav.Link>
                        <Nav.Link as={Link} to="/Contact">Contact</Nav.Link>
                        {/* Optionally add a dropdown */}
                        <NavDropdown title="More" id="navbar-nav-dropdown">
                            <NavDropdown.Item as={Link} to="/FAQ">FAQ</NavDropdown.Item>
                            <NavDropdown.Item as={Link} to="/Blog">Blog</NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
};

export default Navigation;
