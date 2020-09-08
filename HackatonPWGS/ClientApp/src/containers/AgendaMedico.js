import React, {Component} from 'react';
import "tabler-react/dist/Tabler.css";
//import { Nav, Container} from "tabler-react";
import CardMedico from '../components/categoriamedicos/CardMedico';
import "tabler-react/dist/Tabler.css";
import { Grid, Page, Form, Button, Text, Card} from "tabler-react";
import axios from 'axios';
import { connect } from 'react-redux';
import { Link, withRouter, Redirect } from 'react-router-dom'
import CardSelect from '../components/agendamedico/CardSelect';
//import { Calendar, DefaultCalendarHeading, nextMonth, previousMonth,localizedWeekdayNames, localizedYearMonth } from 'react-clean-calendar';
import moment from 'moment';


class AgendaMedico extends Component {

    state = { 
        id_medico: 0,
        nome_medico: "",
        pesquisa: "",
        proximas_datas: [],
        horariosdisponiveis: [],
        data_selecionada: "",
        hora_selecionada: "",
        redirect: null
    }

    componentDidMount(){

        
        if(this.props.match.params.id != null){
            let baseUrl = window.location.protocol + "//" + window.location.host + "/"  + "api/Medico/Calendario/" + this.props.match.params.id;
            console.log(baseUrl);
            let self = this;
            axios.get(baseUrl)
            .then(res => {
                //console.log(res);
                self.setState({
                    id_medico: res.data.id_medico,
                    nome_medico: res.data.nome_medico,
                    proximas_datas: res.data.dias_atendimento
                });
            });
        }
        
    }

    onDataSelecionada = () =>{
        if(this.state.id_medico != null){
            let baseUrl = window.location.protocol + "//" + window.location.host + "/"  + "api/Medico/Calendario/" + this.state.id_medico + "/" + this.state.data_selecionada.replaceAll("/", "-");
            console.log(baseUrl);
            let self = this;
            axios.get(baseUrl)
            .then(res => {
                console.log(res);
                self.setState({
                    horariosdisponiveis: res.data.horarios
                });
            });
        }
    }


    handleDataSelecionada = (event) => {
        console.log(event.target.value);
        this.setState({
            data_selecionada: event.target.value
        }, this.onDataSelecionada);
    }
    
    handleHoraSelecionada = (event) => {
        this.setState({
            hora_selecionada: event.target.value
        });
    }

    handlePesquisaChange = (event) => {
        //console.log(event.target.value);
        this.setState({
            pesquisa: event.target.value
        })
    }

    handleMarcarConsulta = (event) => {
        
        let dados = {
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
                        redirect: '/Medicos/ConsultaMarcada/' + res.data.id_agendamento
                    });
                }else{
                    alert("Não deu certo");
                }
            });
        }

    }

    render(){

        if (this.state.redirect) {
            return <Redirect to={this.state.redirect} />
          }
        
        return (<>
                    <Page.Header
                        title="Marcar Consulta"
                        subTitle={this.state.nome_medico}
                    />
                    <Grid.Row >
                        <Card>
                            <Card.Body>
                                <Grid.Row>
                                    <Grid.Col md={4} xl={4} >
                                        <Form.Group label="Selecione a Data:">
                                            <Form.Select value={this.state.data_selecionada} onChange={this.handleDataSelecionada}>
                                                <option>Escolher...</option>
                                                {this.state.proximas_datas != null ? this.state.proximas_datas.map((item, index) => {
                                                    return (<option key={index} value={item}>{item}</option>)
                                                }) : null}
                                                
                                            </Form.Select>
                                        </Form.Group>
                                    </Grid.Col>
                                    <Grid.Col md={4} xl={4} >
                                        <Form.Group label="Selecione o Horário:">
                                            <Form.Select onChange={this.handleHoraSelecionada} value={this.state.hora_selecionada}>
                                                <option>Escolher...</option>
                                                {this.state.horariosdisponiveis != null ? this.state.horariosdisponiveis.map((item, index) => {
                                                    return (<option key={index} value={item}>{item}</option>)
                                                }) : null}
                                            </Form.Select>
                                        </Form.Group>
                                    </Grid.Col>
                                </Grid.Row>
                            </Card.Body>
                            <Card.Footer>
                                <Button onClick={this.handleMarcarConsulta} color="success" size="md" className="ml-2">
                                    Confirmar
                                </Button>
                            </Card.Footer>
                        </Card>
                    </Grid.Row>
                    <Grid.Row>
                        
                        
                    </Grid.Row>
                </>
            );
    }
}

export default withRouter(AgendaMedico);
