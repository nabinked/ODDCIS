import * as React from 'react';
import './search-result.scss';
import { Loader } from '../Shared/Loader/Loader'
import { SearchResultItemList } from './SearchResultItemList'
import { SearchResultItem } from './SearchResultItem'
import { SearchResultItemModel, SearchResultItemListModel } from './SearchResultitemModel';
import { RouteComponentProps } from 'react-router-dom'
import 'isomorphic-fetch';

interface SearchResultState {
    loading: boolean,
    results: SearchResultItemListModel
}

interface SearchResultProps {
    query: string;
}

export class SearchResult extends React.Component<SearchResultProps, SearchResultState> {

    constructor() {
        super();
        this.state = { results: null, loading: true };
    }
    fetchResults(query) {
        fetch('/api/search?query=' + query)
            .then(response => response.json() as Promise<SearchResultItemListModel>)
            .then(data => {
                this.setState({ results: data, loading: false });
            });
    };
    public componentDidMount() {
        this.fetchResults(this.props.query)
    }
    public componentWillReceiveProps(nextProps){
        this.fetchResults(nextProps.query);
     }
    public render() {
        return <div className="search-result">
            {
                this.state.loading ?
                    <Loader /> :
                    <div>
                        <SearchResultItemList results={this.state.results.results} />
                    </div>
            }
        </div>;
    }
}
