import * as React from 'react';
import { NavbarBrand, NavbarToggler, Collapse } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import "tabler-react/dist/Tabler.css";
import { Nav, Container} from "tabler-react";

export default class NavMenu extends React.PureComponent<{}, { isOpen: boolean }> {
    public state = {
        isOpen: false
    };

    public render() {
        return (
            <header>
                <Nav>
                        {/* <NavbarBrand tag={Link} to="/">HackatonPWGS</NavbarBrand> */}
                        {/* <NavbarToggler onClick={this.toggle} className="mr-2"/> */}
                            
                            <Nav.Item>
                                <Nav.Link tag={Link} className="text-dark" to="/">Home</Nav.Link>
                            </Nav.Item>
                            <Nav.Item>
                                <Nav.Link tag={Link} className="text-dark" to="/counter">Counter</Nav.Link>
                            </Nav.Item>
                            <Nav.Item>
                                <Nav.Link tag={Link} className="text-dark" to="/fetch-data">Fetch data</Nav.Link>
                            </Nav.Item>
                </Nav>
            </header>
        );
    }

    private toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }
}
