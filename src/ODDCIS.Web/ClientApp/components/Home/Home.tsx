import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom'
import { SearchForm } from '../Shared/SearchForm/SearchForm';
import { parse } from 'query-string'

import './home.scss';

interface HomeProps extends RouteComponentProps<any> {
}
export class Home extends React.Component<HomeProps, {}> {
    constructor() {
        super();
    }
    getQuery(location) {
        return location ? parse(location.search).query : ""
    }
    public render() {
        return <div className="home">
            <SearchForm query={this.getQuery(this.props.location)} {...this.props} />
        </div>;
    }
}