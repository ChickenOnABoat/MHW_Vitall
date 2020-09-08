import React, { Component } from 'react';
import { Grid, Page, Form, Button, Text, Card} from "tabler-react";

import { Link, withRouter } from 'react-router-dom'


class CardSelect extends Component {

    render(){
        return(<Card color={this.props.selecionavel ? "green" : ""} side>
                    <Card.Body>
                        <h1>{this.props.titulo}</h1>
                    </Card.Body>
                    {this.props.selecionavel ? (<Card.Footer className="ml-auto">
                                                    <Link className="btn btn-sm btn-success ml-2" to={'/'} ><Text color="white">Selecionar</Text></Link>
                                                </Card.Footer>) : null}
                </Card>)
    }
}

export default withRouter(CardSelect);