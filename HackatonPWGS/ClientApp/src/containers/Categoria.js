import React, {Component} from 'react';
import "tabler-react/dist/Tabler.css";
//import { Nav, Container} from "tabler-react";
import CardMedico from '../components/categoriamedicos/CardMedico';
import "tabler-react/dist/Tabler.css";
import { Grid, Page, Form} from "tabler-react";
import axios from 'axios';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom'


class Categoria extends Component {

    state = { 
        id: 0,
        especialidade: null,
        medicos: [],
        pesquisa: ""
    }

    componentDidMount(){
        if(this.props.match.params.id != null){
            let baseUrl = window.location.protocol + "//" + window.location.host + "/"  + "api/EspecialidadeMedica/Medicos/" + this.props.match.params.id;
            console.log(baseUrl);
            let self = this;
            axios.get(baseUrl)
            .then(res => {
                console.log(res);
                self.setState({
                    id: res.data.especialidade.id,
                    especialidade: res.data.especialidade,
                    medicos: res.data.medicos
                });
            });
        }
        
    }

    possuiHabilidade = (medico) =>{
        if(medico.habilidades != null){
            let aux = medico.habilidades.join("");
            if(aux.toLowerCase().includes(this.state.pesquisa.toLowerCase())){
                return true;
            }
        }
        return false;
    }

    handlePesquisaChange = (event) => {
        //console.log(event.target.value);
        this.setState({
            pesquisa: event.target.value
        })
    }

    render(){

        let options = (
            <React.Fragment>
              <Form.Input value={this.state.pesquisa} onChange={this.handlePesquisaChange} icon="search" placeholder="Pesquisar Profissional" label="Pesquisar profissional por nome ou habilidade"/>
            </React.Fragment>
          );
        let filteredMedicos;
        if(this.state.pesquisa.length > 0){
            filteredMedicos = this.state.medicos.filter(medico => medico.nome.toLowerCase().includes(this.state.pesquisa.toLowerCase()) || this.possuiHabilidade(medico));
        }else{
            filteredMedicos = this.state.medicos;
        }

        return (<>
                    <Page.Header
                        title={this.state.especialidade != null ? this.state.especialidade.nome : ""}
                        /* subTitle="1 - 12 of 1713 photos" */
                        options={options}
                    />
                    <Grid.Row cards alignItems="top">
                        {filteredMedicos.map(item => {
                            return (<Grid.Col key={item.id} md={6} xl={4}>
                                        <CardMedico medico={item} />
                                    </Grid.Col>);
                        })}
                    </Grid.Row>
                </>
            );
    }
}

export default withRouter(Categoria);
