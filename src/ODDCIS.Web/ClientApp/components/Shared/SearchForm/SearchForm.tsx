import * as React from 'react';
import './search-form.scss';
import { parse } from 'query-string'
import { RouteComponentProps } from 'react-router-dom'

interface SearchFormState {
    query: string
}
interface SearchFormProps extends RouteComponentProps<{}> {

}
export class SearchForm extends React.Component<SearchFormProps | any, SearchFormState>   {
    constructor(props: SearchFormProps) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
        this.state = {
            query: this.props.location ? parse(this.props.location.search).query : ""
        }
    }
    public render() {
        return <form action="/search" method="get" onSubmit={this.handleSubmit} className="form-inline search-form">
            <div className="form-group text-center">
                <input
                    type="text"
                    className="form-control search-input"
                    placeholder="enter search term"
                    value={this.state.query}
                    onChange={this.handleInputChange}
                />
                <input type="submit"
                    className="btn btn-outline-primary"
                    value="Search"
                />
            </div>
        </form>
    }
    handleInputChange(event: React.ChangeEvent<HTMLInputElement>) {
        console.log('input change');
        this.setState({
            query: (event.target as HTMLInputElement).value
        })
    }
    handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        this.props.history.push('/search?query=' + this.state.query)
    }
}
