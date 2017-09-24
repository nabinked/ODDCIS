import * as React from 'react';
import './search-form.scss';
import { RouteComponentProps } from 'react-router-dom'
import { SearchInput } from './SearchInput';

interface SearchFormState {
    query: string
}
interface SearchFormProps {
    query: string;
}
export class SearchForm extends React.Component<SearchFormProps, SearchFormState>   {
    tags: { id: number; text: string; }[];
    constructor(props: SearchFormProps) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
        this.tags = [{ id: 1, text: "nabin" }];
    }
    public render() {
        return <form action="/search" method="get" onSubmit={this.handleSubmit} className="form-inline search-form">
            <div className="text-center">
                <SearchInput tags={this.tags} />
                <input type="submit"
                    className="btn btn-outline-primary"
                    value="Search"
                />
            </div>
        </form>
    }
    handleInputChange(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({
            query: (event.target as HTMLInputElement).value
        })
    }
    handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        
    }
}
