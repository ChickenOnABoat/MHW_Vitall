import React , { Component } from 'react';
import "tabler-react/dist/Tabler.css";
import { Card, Button, Media, Avatar, Text } from "tabler-react";
import { Link, withRouter } from 'react-router-dom'

class CardAcompanhante extends Component {

    

    render(){
        return (<Card>
                    <Card.Body >
                        <Media>
                            <Avatar
                            size="xxl"
                            className="mr-5"
                            imageURL="demo/faces/female/21.jpg"
                            />
                            <Media.Body>
                                <h5><strong>{this.props.acompanhante.nome}</strong></h5>
                                <h6>Descrição: {this.props.acompanhante.descricao}</h6>
                                
                                
                            </Media.Body>
                        </Media>
                        
                    </Card.Body>
                    <Card.Footer >
                        <Button color="success" size="sm" className="ml-2">
                            Agendar Acompanhante
                        </Button>
                    </Card.Footer>
                </Card>)
    }
}

export default withRouter(CardAcompanhante);