import React, {Component} from 'react';
import "tabler-react/dist/Tabler.css";
//import { Nav, Container} from "tabler-react";
import "tabler-react/dist/Tabler.css";
import { Grid, Page, Form, Button, Text, Card} from "tabler-react";
import axios from 'axios';
import { connect } from 'react-redux';
import { Link, withRouter, Redirect } from 'react-router-dom'
//import { Calendar, DefaultCalendarHeading, nextMonth, previousMonth,localizedWeekdayNames, localizedYearMonth } from 'react-clean-calendar';
import moment from 'moment';
import CardAcompanhante from '../components/agendamedico/CardAcompanhante';

class ConsultaMarcada extends Component {

    state = { 
        id_agendamento: 0,
        redirect: null,
        nome_medico: "",
        data: "",
        hora_inicio: "",
        hora_fim: "",
        acompanhantes: []
    }

    componentDidMount(){

        
        if(this.props.match.params.id != null){
            let baseUrl = window.location.protocol + "//" + window.location.host + "/"  + "api/Medico/Agendamento/" + this.props.match.params.id;
            console.log(baseUrl);
            let self = this;
            axios.get(baseUrl)
            .then(res => {
                //console.log(res);
                self.setState({
                    id_agendamento: res.data.id,
                    nome_medico: res.data.nome_medico,
                    data: res.data.data,
                    hora_inicio: res.data.hora_inicio,
                    hora_fim: res.data.hora_fim,
                    acompanhantes: res.data.acompanhantes
                });
            });
        }
        
    }

    

    handleMarcarConsulta = (event) => {
        
        /* let dados = {
            id_medico: Number(this.state.id_medico),
            data: this.state.data_selecionada.replaceAll("/", "-"),
            hora: this.state.hora_selecionada
        }

        if(this.state.id_medico != null){
            let baseUrl = window.location.protocol + "//" + window.location.host + "/"  + "api/Medico/AgendarConsulta";
            console.log(baseUrl);
            let self = this;
            axios.post(baseUrl, dados)
            .then(res => {
                console.log(res);
                if(res.data.status == 0){
                    self.setState({
                        redirect: '/especialidades'
                    });
                }else{
                    
                }
            });
        } */

    }

    render(){

        if (this.state.redirect) {
            return <Redirect to={this.state.redirect} />
          }
        
        return (<>
                    <Page.Header
                        title="Confirmação de Agendamento de Consulta"
                    />
                    <Grid.Row >
                        <Card>
                            <Card.Body>
                                
                                <h5>Sua consulta foi marcada com sucesso!</h5>
                                <h5>Médico: {this.state.nome_medico}</h5>
                                <h5>Data: {this.state.data}</h5>
                                <h5>Hora Início: {this.state.hora_inicio}</h5>
                                <h5>Hora Término: {this.state.hora_fim}</h5>
                            
                                <Grid.Row>
                                    <h5>Deseja agendar um acompanhante para auxiliá-lo durante a consulta?</h5>
                                    <Grid.Row cards alignItems="top">
                                        {this.state.acompanhantes.map(item => {
                                            return (<Grid.Col key={item.id} md={6} xl={4}>
                                                        <CardAcompanhante acompanhante={item} />
                                                    </Grid.Col>);
                                        })}
                                    </Grid.Row>
                                </Grid.Row>
                            </Card.Body>
                            <Card.Footer>
                            </Card.Footer>
                        </Card>
                    </Grid.Row>
                    <Grid.Row>
                        
                        
                    </Grid.Row>
                </>
            );
    }
}

export default withRouter(ConsultaMarcada);
