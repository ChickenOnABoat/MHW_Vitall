import React , { Component } from 'react';
import "tabler-react/dist/Tabler.css";
import { Card, Button, Text } from "tabler-react";
import { Link, withRouter } from 'react-router-dom';


class CardCategoria extends Component {

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
        let idcard = this.props.id;

        return (<Card className={ this.state.collapse ? "card card-collapsed" : "card" }>
                    <Card.Header>
                    <Card.Title>{this.props.nome}</Card.Title>
                    <Card.Options>
                        <Button onClick={this.toggleCollapse} color="primary" size="sm" className="ml-2">
                            Descrição
                        </Button>
                        {/* <Button color="success" size="sm" className="ml-2"> */}
                            <Link className="btn btn-sm btn-success ml-2" to={'/Especialidades/' + idcard} ><Text color="white">Selecionar</Text></Link>
                        {/* </Button> */}
                    </Card.Options>
                    </Card.Header>
                    <Card.Body >
                        {this.props.descricao}
                    </Card.Body>
                </Card>)
    }
}

export default withRouter(CardCategoria);