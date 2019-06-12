import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Dashboard from './pages/dashboard';
import Counter from './pages/counter';
import FetchData from './pages/fetchdata';

export default () => (
  <Layout>
    <Route exact path='/' component={Dashboard} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
  </Layout>
);
