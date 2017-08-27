import * as React from 'react';
import './search-result.scss';

interface SearchResultState {
    searchTerm: string
}

export class SearchResult extends React.Component<{}, SearchResultState> {

    constructor() {
        super();
    }

    public render() {
        return <div className="search-result">
            This is where you will find the results
        </div>;
    }
}