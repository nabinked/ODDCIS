// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX
import * as React from 'react'
import { SearchResultItemModel } from './SearchResultitemModel';

interface SearchResultItemProps {
    result: SearchResultItemModel
}

export class SearchResultItem extends React.Component<SearchResultItemProps, {}> {
    constructor(props: SearchResultItemProps) {
        super(props);
    }
    public render() {
        return <div className="search-result-item">
            <a href={this.props.result.url} target="_blank">
                <h3 className="search-result-item-title">{this.props.result.title}</h3>
            </a>
            <a href={this.props.result.url} target="_blank">

                <small>{this.props.result.url}</small>
            </ a >
            <p>{this.props.result.excerpt}</p>
            <br />
        </div>
    }
}