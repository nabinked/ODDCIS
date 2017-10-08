import * as React from 'react'
import { SearchForm } from '../Shared/SearchForm/SearchForm'
import { RouteComponentProps } from 'react-router-dom'
import { SearchResult } from './SearchResult'
import './search.scss'
import { parse } from 'query-string'
import * as H from 'history';
import { RdfNode } from './../Shared/SearchForm/SearchInput'

interface SearchState {
    rdfTermTags: Array<RdfNode>;
}
interface SearchProps extends RouteComponentProps<any> {
    query: string;
}
export class Search extends React.Component<SearchProps, SearchState> {

    constructor(props: SearchProps) {
        super(props);
        this.state = {
            rdfTermTags: []
        }
    }
    public render() {
        return <div className="search">
            <div className="search-form">
                <SearchForm {...this.props} />
            </div>
            <hr />
            <div className="search-result">
                <SearchResult query={this.props.location.search} />
            </div>
        </div>;
    }
}