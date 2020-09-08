import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import CategoriasMedicos from './containers/CategoriasMedicos';
import Categoria from './containers/Categoria';
import AgendaMedico from './containers/AgendaMedico';
import ConsultaMarcada from './containers/ConsultaMarcada';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/Especialidades' component={CategoriasMedicos} />
        <Route path='/Especialidades/:id' component={Categoria} />
        <Route exact path='/Medicos/MarcarConsulta/:id' component={AgendaMedico} />
        <Route exact path='/Medicos/ConsultaMarcada/:id' component={ConsultaMarcada} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    </Layout>
);
