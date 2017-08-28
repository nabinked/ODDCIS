import * as React from 'react';
import './search-result.scss';
import { Loader } from '../Shared/Loader/Loader'
import { SearchResultItemList } from './SearchResultItemList'
import { RouteComponentProps } from 'react-router-dom'
import 'isomorphic-fetch';

interface Result {
    title: string;
    url: string;
    excerpt: string;
}

interface SearchResultState {
    loading: boolean,
    results: SearchResultItem[]
}

export class SearchResult extends React.Component<RouteComponentProps<any> | any, SearchResultState> {

    constructor() {
        super();
        this.state = { results: [], loading: true };
        fetch('/api/search' + this.props.location.search)
            .then(response => response.json() as Promise<SearchResult[]>)
            .then(data => {
                this.setState({ results: data, loading: false });
            });
    }

    public render() {
        return <div className="search-result">
            {
                this.state.loading ?
                    <Loader /> :
                    <SearchResultItemList results={this.state.results} />
            }
        </div>;
    }
}
