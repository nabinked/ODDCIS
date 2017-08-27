import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home/Home';
import { Search } from './components/Search/Search';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/search' component={ Search } />
    <Route path='/fetchdata' component={ FetchData } />
</Layout>;
