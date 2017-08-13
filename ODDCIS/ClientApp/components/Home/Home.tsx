import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom'
import { SearchForm } from '../Shared/SearchForm/SearchForm';
import './home.scss';

interface HomeProps extends RouteComponentProps<any> {
    history: any
}
export class Home extends React.Component<HomeProps, {}> {
    constructor() {
        super();
    }

    public render() {
        return <div className="home">
            <SearchForm history={this.props.history} />
        </div>;
    }
}