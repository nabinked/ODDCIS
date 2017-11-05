// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX
import * as React from 'react'
import { SearchResultItemModel } from './SearchResultitemModel';
import utils from './../../utils'

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
                <h4 className="search-result-item-title">{this.props.result.title}</h4>
            </a>
            <a href={this.props.result.url} target="_blank">

                <small className="search-result-item-url">{this.props.result.url}</small>
            </ a >
            <p className="search-result-item-excerpt">{utils.truncate(this.props.result.excerpt, 300)}</p>
        </div>
    }
}