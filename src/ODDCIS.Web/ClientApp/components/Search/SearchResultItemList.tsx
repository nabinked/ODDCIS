﻿import * as React from 'react';
import { SearchResultItem } from './SearchResultItem';
import { SearchResultItemModel } from './SearchResultitemModel';

interface SearchResultListProps {
    results: SearchResultItemModel[]
}

export class SearchResultItemList extends React.Component<SearchResultListProps, {}>{
    constructor() {
        super();
    }
    public render() {
        return <div>
            <p>
                {this.props.results ?
                    this.props.results.length + " result(s) found"
                    : "No result found"}
            </p>
            {
                this.props.results && this.props.results.length ?
                    this.props.results.map(result => {
                        return <SearchResultItem key={result.url} result={result} />
                    }) : ""
            }
        </div>
    }
}