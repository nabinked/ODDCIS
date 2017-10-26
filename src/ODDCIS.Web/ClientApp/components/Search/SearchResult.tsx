import * as React from 'react';
import './search-result.scss';
import { Loader } from '../Shared/Loader/Loader'
import { ExecutedQuery } from './ExecutedQuery'
import { SearchResultItemList } from './SearchResultItemList'
import { SearchResultItem } from './SearchResultItem'
import { SearchResultItemModel, SearchResultItemListModel } from './SearchResultitemModel';
import { RouteComponentProps } from 'react-router-dom'
import 'isomorphic-fetch';

interface SearchResultState {
    loading: boolean,
    result: SearchResultItemListModel
}

interface SearchResultProps {
    query: string;
}

export class SearchResult extends React.Component<SearchResultProps, SearchResultState> {

    constructor() {
        super();
        this.state = { result: null, loading: true };
    }
    fetchResults(query: string) {
        fetch('/api/search' + query)
            .then(response => response.json() as Promise<SearchResultItemListModel>)
            .then(data => {
                this.setState({ result: data, loading: false, });
            });
    };
    public componentDidMount() {
        this.fetchResults(this.props.query)
    }
    public componentWillReceiveProps(nextProps:SearchResultProps) {
        this.fetchResults(nextProps.query);
    }
    public render() {
        return <div className="search-result">
            {
                this.state.loading ?
                    <Loader /> :
                    <div>
                        <ExecutedQuery executedSparqlQuery={this.state.result.executedSparqlQuery} requestedSemanticQuery={this.state.result.requestedSemanticQuery} />
                        <hr />
                        <SearchResultItemList results={this.state.result.results} />
                    </div>
            }
        </div>;
    }
}
