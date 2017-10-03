import * as React from 'react'
import {SearchForm} from '../Shared/SearchForm/SearchForm'
import { RouteComponentProps } from 'react-router-dom'
import { SearchResult } from './SearchResult'
import './search.scss'
import { parse } from 'query-string'
import * as H from 'history';


interface SearchState {
    searchTerm: string
}
interface SearchProps extends RouteComponentProps<any> {

}
export class Search extends React.Component<SearchProps, SearchState> {
    constructor(props: SearchProps) {
        super(props);
    }
    public getQuery(location: H.Location) {
        return parse(location.search).query;
    }
    public render() {
        return <div className="search">
            <SearchForm query={this.getQuery(this.props.location)} {...this.props} />
            <SearchResult query={this.getQuery(this.props.location)} />
        </div>;
    }
}