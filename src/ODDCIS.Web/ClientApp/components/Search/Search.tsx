import * as React from 'react';
import { SearchForm } from '../Shared/SearchForm/SearchForm';
import { RouteComponentProps } from 'react-router-dom'
import { SearchResult } from './SearchResult';
import './search.scss';

interface SearchState {
    searchTerm: string
}
interface SearchProps extends RouteComponentProps<any> {

}
export class Search extends React.Component<SearchProps, SearchState> {

    constructor(props: SearchProps) {
        super(props);
    }

    public render() {
        return <div className="search">
            <SearchForm history={this.props.history}/>
            <SearchResult />
        </div>;
    }
}