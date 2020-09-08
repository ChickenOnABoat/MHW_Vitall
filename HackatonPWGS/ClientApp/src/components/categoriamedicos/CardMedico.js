import React , { Component } from 'react';
import "tabler-react/dist/Tabler.css";
import { Card, Button, Media, Avatar, Text } from "tabler-react";
import { Link, withRouter } from 'react-router-dom'

class CardMedico extends Component {

    state={
        collapse: true
    }

    toggleCollapse = (event) =>{
        let aux = this.state.collapse;
        this.setState({
            collapse: !aux
        });
    }

    render(){
        return (<Card>
                    <Card.Body >
                        <Media>
                            <Avatar
                            size="xxl"
                            className="mr-5"
                            imageURL="demo/faces/male/21.jpg"
                            />
                            <Media.Body>
                                <h5><strong>{this.props.medico.nome}</strong></h5>
                                <h6>Atende em: </h6>
                                {this.props.medico.locaisAtendimento.map(item => {
                                    return (<p key={item.id}>{item.nome}</p>)
                                })}
                                
                            </Media.Body>
                        </Media>
                        {this.props.medico.habilidades.length > 0 ? 
                               <> <strong>Informações Adicionais:</strong> {this.props.medico.habilidades.map((item, index) => (<span key={index} >{item};</span>))}</>  : null}
                    </Card.Body>
                    <Card.Footer className="ml-auto">
                        <Link className="btn btn-sm btn-success ml-2" to={'/Medicos/MarcarConsulta/' + this.props.medico.id} ><Text color="white">Marcar Consulta</Text></Link>
                    </Card.Footer>
                </Card>)
    }
}

export default withRouter(CardMedico);