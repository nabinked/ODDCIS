import * as React from 'react';
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
            {
                this.props.results && this.props.results.length ?
                    this.props.results.map(result => {
                        return <SearchResultItem key={result.url} result={result} />
                    }) : "No result found"
            }
        </div>
    }
}