import React, {Component} from 'react';
import "tabler-react/dist/Tabler.css";
//import { Nav, Container} from "tabler-react";
import CardCategoria from '../components/categoriamedicos/CardCategoria';
import "tabler-react/dist/Tabler.css";
import { Grid, Page} from "tabler-react";
import axios from 'axios';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom'

class CategoriasMedicos extends Component {

    state = { 
        categorias: []
    }

    componentDidMount(){
        let baseUrl = window.location.protocol + "//" + window.location.host + "/"  + "api/EspecialidadeMedica";
        console.log(baseUrl);
        let self = this;
        axios.get(baseUrl)
        .then(res => {
            console.log(res);
            self.setState({
                categorias: res.data
            });
        });
    }

    render(){
        return (
        
            <Grid.Row cards alignItems="center">
                {this.state.categorias.map(item => {
                    return (<Grid.Col key={item.id} md={6} xl={4}>
                        <CardCategoria id={item.id} nome={item.nome_especialidade} descricao={item.descricao_especialidade} />
                    </Grid.Col>);
                })}
            </Grid.Row>
            );
    }
}

export default withRouter(CategoriasMedicos);
