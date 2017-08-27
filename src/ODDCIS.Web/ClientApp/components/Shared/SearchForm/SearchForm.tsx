import * as React from 'react';
import './search-form.scss';
import { RouteComponentProps } from 'react-router-dom'

interface FormState {
    searchTerm: string
}
interface SearchFormProps extends RouteComponentProps<any> {
    history: any
}
export class SearchForm extends React.Component<SearchFormProps, FormState>   {
    constructor() {
        super();
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }
    public render() {
        return <form action="/search" onSubmit={this.handleSubmit} className="form-inline search-form">
            <div className="form-group text-center">
                <input
                    type="text"
                    className="form-control search-input"
                    placeholder="enter search term"
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
            searchTerm: (event.target as HTMLInputElement).value
        })
    }
    handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        this.props.history.push('/search')
    }
}
